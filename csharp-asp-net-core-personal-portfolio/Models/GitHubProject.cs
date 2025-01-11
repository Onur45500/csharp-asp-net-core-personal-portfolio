using System;

namespace csharp_asp_net_core_personal_portfolio.Models
{
    public class GitHubProject
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string HtmlUrl { get; set; }
        public required string Language { get; set; }
        public int StargazersCount { get; set; }
        public int ForksCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
