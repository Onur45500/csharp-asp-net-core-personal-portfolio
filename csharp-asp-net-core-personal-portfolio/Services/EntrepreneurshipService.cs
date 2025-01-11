using System.Collections.Generic;
using csharp_asp_net_core_personal_portfolio.Models;

namespace csharp_asp_net_core_personal_portfolio.Services
{
    public class EntrepreneurshipService
    {
        public Experience GetEntrepreneurship()
        {
            return new Experience
            {
                Title = "AKMESE",
                Company = "Entrepreneurship",
                Type = "Micro-company",
                Duration = "Since September 2021",
                Responsibilities = new List<string>
                {
                    "Founded and managing a micro-company specialized in creating modern, responsive websites and web applications for businesses.",
                    "Web Development",
                    "Consulting",
                    "Business Solutions"
                },
                CompanyDetailsUrl = "https://www.societe.com/societe/akmese-902780014.html",
                IsEntrepreneurship = true
            };
        }
    }
}
