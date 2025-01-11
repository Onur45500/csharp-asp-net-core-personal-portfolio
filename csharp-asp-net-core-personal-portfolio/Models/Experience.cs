using System.Collections.Generic;

namespace csharp_asp_net_core_personal_portfolio.Models
{
    public class Experience
    {
        public required string Title { get; set; }
        public required string Company { get; set; }
        public required string Type { get; set; }
        public required string Duration { get; set; }
        public required List<string> Responsibilities { get; set; }
        public string? CompanyDetailsUrl { get; set; }
        public bool IsEntrepreneurship { get; set; }
    }
}
