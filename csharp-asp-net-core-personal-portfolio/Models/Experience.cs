using System.Collections.Generic;

namespace csharp_asp_net_core_personal_portfolio.Models
{
    public class Experience
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public string Type { get; set; }
        public string Duration { get; set; }
        public List<string> Responsibilities { get; set; }
        public string CompanyDetailsUrl { get; set; }
        public bool IsEntrepreneurship { get; set; }
    }
}
