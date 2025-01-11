using csharp_asp_net_core_personal_portfolio.Models;
using System.Collections.Generic;

namespace csharp_asp_net_core_personal_portfolio.Services
{
    public class EducationService
    {
        public List<Education> GetEducations()
        {
            return new List<Education>
            {
                new Education
                {
                    Degree = "Computer Engineer",
                    Institution = "CESI Engineering School",
                    Duration = "2022 - 2025",
                    Description = "In apprenticeship",
                },
                new Education
                {
                    Degree = "Computer Engineer",
                    Institution = "CESI Engineering School", 
                    Duration = "2019 - 2022",
                    Description = "Option computer science",
                },
                new Education
                {
                    Degree = "High School",
                    Institution = "Bernard Palissy",
                    Duration = "2019 - 2022",
                    Description = "Option English and traveled to England",
                },
                new Education
                {
                    Degree = "Middle School", 
                    Institution = "Ernest Bildstein",
                    Duration = "2019 - 2022",
                    Description = "Option mathematical and archeology",
                }
            };
        }
    }
}
