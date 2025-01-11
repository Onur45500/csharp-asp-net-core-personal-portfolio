using System.Collections.Generic;

namespace csharp_asp_net_core_personal_portfolio.Models
{
    public class ProjectLink
    {
        public required string Title { get; set; }
        public required string Url { get; set; }
    }

    public class Project
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required List<string> Technologies { get; set; }
        public List<ProjectLink> Links { get; set; } = new();
    }
}
