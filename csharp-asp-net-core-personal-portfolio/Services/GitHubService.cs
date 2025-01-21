using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using csharp_asp_net_core_personal_portfolio.Models;
using Octokit;
using DotNetEnv;

namespace csharp_asp_net_core_personal_portfolio.Services
{
    public class GitHubService
    {
        private readonly GitHubClient _client;
        private readonly string _username;
        private readonly IMemoryCache _cache;
        private const string CacheKey = "github_repos";

        public GitHubService(IMemoryCache cache)
        {
            _cache = cache;
            Env.Load();
            _username = System.Environment.GetEnvironmentVariable("GITHUB_USERNAME") ?? "Onur45500";
            var token = System.Environment.GetEnvironmentVariable("GITHUB_TOKEN");

            if (string.IsNullOrEmpty(token))
            {
                throw new InvalidOperationException("GitHub token is not configured. Please set GITHUB_TOKEN environment variable.");
            }

            _client = new GitHubClient(new ProductHeaderValue("portfolio"))
            {
                Credentials = new Credentials(token)
            };
        }

        public async Task<List<GitHubProject>> GetPublicRepositoriesAsync(ProjectFilter filter = ProjectFilter.All)
        {
            if (_cache.TryGetValue(CacheKey, out List<GitHubProject> cachedProjects))
            {
                return FilterProjects(cachedProjects, filter);
            }

            try
            {
                var repositories = await GetRepositoriesWithRetryAsync();
                var projects = new List<GitHubProject>();

                foreach (var repo in repositories.Where(r => !r.Fork && !string.IsNullOrEmpty(r.Description)))
                {
                    projects.Add(new GitHubProject
                    {
                        Name = repo.Name,
                        Description = repo.Description ?? "",
                        HtmlUrl = repo.HtmlUrl,
                        Language = repo.Language ?? "Not specified",
                        StargazersCount = repo.StargazersCount,
                        ForksCount = repo.ForksCount,
                        CreatedAt = repo.CreatedAt.DateTime,
                        UpdatedAt = repo.UpdatedAt.DateTime
                    });
                }

                // Cache results for 1 hour
                _cache.Set(CacheKey, projects, TimeSpan.FromHours(1));
                
                return FilterProjects(projects, filter);
            }
            catch (RateLimitExceededException ex)
            {
                Console.WriteLine($"GitHub API rate limit exceeded: {ex.Message}");
                return new List<GitHubProject>
                {
                    new GitHubProject
                    {
                        Name = "GitHub Projects",
                        Description = "Unable to fetch GitHub projects at this time. Please try again later.",
                        HtmlUrl = string.Empty,
                        Language = string.Empty,
                        StargazersCount = 0,
                        ForksCount = 0,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GitHub API error: {ex.Message}");
                return new List<GitHubProject>
                {
                    new GitHubProject
                    {
                        Name = "GitHub Projects",
                        Description = "Unable to fetch GitHub projects at this time. Please try again later.",
                        HtmlUrl = string.Empty,
                        Language = string.Empty,
                        StargazersCount = 0,
                        ForksCount = 0,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }
                };
            }
        }

        private async Task<IReadOnlyList<Repository>> GetRepositoriesWithRetryAsync(int retryCount = 3)
        {
            int attempt = 0;
            while (true)
            {
                try
                {
                    return await _client.Repository.GetAllForUser(_username);
                }
                catch (RateLimitExceededException) when (attempt < retryCount)
                {
                    attempt++;
                    var delay = TimeSpan.FromSeconds(Math.Pow(2, attempt)); // Exponential backoff
                    await Task.Delay(delay);
                }
            }
        }

        private List<GitHubProject> FilterProjects(List<GitHubProject> projects, ProjectFilter filter)
        {
            var filteredProjects = filter switch
            {
                ProjectFilter.All => projects,
                ProjectFilter.CSharp => projects.Where(p => p.Name.ToLower().StartsWith("csharp")).ToList(),
                ProjectFilter.React => projects.Where(p => p.Name.ToLower().StartsWith("react")).ToList(),
                ProjectFilter.Others => projects.Where(p => 
                    !p.Name.ToLower().StartsWith("csharp") && 
                    !p.Name.ToLower().StartsWith("react")).ToList(),
                _ => projects
            };
            
            return filteredProjects.OrderByDescending(p => p.UpdatedAt).ToList();
        }
    }
}
