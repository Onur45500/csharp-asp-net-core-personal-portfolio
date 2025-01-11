using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using csharp_asp_net_core_personal_portfolio.Models;
using Octokit;
using DotNetEnv;

namespace csharp_asp_net_core_personal_portfolio.Services
{
    public class GitHubService
    {
        private readonly GitHubClient _client;
        private readonly string _username;

        public GitHubService()
        {
            Env.Load();
            _username = System.Environment.GetEnvironmentVariable("GITHUB_USERNAME") ?? "Onur45500";
            var token = System.Environment.GetEnvironmentVariable("GITHUB_TOKEN");

            _client = new GitHubClient(new ProductHeaderValue("portfolio"));
            if (!string.IsNullOrEmpty(token))
            {
                _client.Credentials = new Credentials(token);
            }
        }

        public async Task<List<GitHubProject>> GetPublicRepositoriesAsync(ProjectFilter filter = ProjectFilter.All)
        {
            var repositories = await _client.Repository.GetAllForUser(_username);
            var projects = new List<GitHubProject>();

            foreach (var repo in repositories.Where(r => !r.Fork && !string.IsNullOrEmpty(r.Description)))
            {
                var project = new GitHubProject
                {
                    Name = repo.Name,
                    Description = repo.Description ?? "",
                    HtmlUrl = repo.HtmlUrl,
                    Language = repo.Language ?? "Not specified",
                    StargazersCount = repo.StargazersCount,
                    ForksCount = repo.ForksCount,
                    CreatedAt = repo.CreatedAt.DateTime,
                    UpdatedAt = repo.UpdatedAt.DateTime
                };

                bool includeProject = filter switch
                {
                    ProjectFilter.All => true,
                    ProjectFilter.CSharp => repo.Name.ToLower().StartsWith("csharp"),
                    ProjectFilter.React => repo.Name.ToLower().StartsWith("react"),
                    ProjectFilter.Others => !repo.Name.ToLower().StartsWith("csharp") && 
                                         !repo.Name.ToLower().StartsWith("react"),
                    _ => true
                };

                if (includeProject)
                {
                    projects.Add(project);
                }
            }

            return projects.OrderByDescending(p => p.UpdatedAt).ToList();
        }
    }
}
