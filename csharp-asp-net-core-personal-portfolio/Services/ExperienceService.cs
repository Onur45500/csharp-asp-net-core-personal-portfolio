using csharp_asp_net_core_personal_portfolio.Models;
using System.Collections.Generic;

namespace csharp_asp_net_core_personal_portfolio.Services
{
    public class ExperienceService
    {
        public List<Experience> GetExperiences()
        {
            return new List<Experience>
            {
                new Experience
                {
                    Title = "Developer C# .NET",
                    Company = "Hexvia",
                    Type = "Apprenticeship",
                    Duration = "November 2024 - Present",
                    Responsibilities = new List<string>
                    {
                        "Modified company software EPONA by integrating Datatable library",
                        "Implemented data storage in JSON format",
                        "Integrated High Charts library for statistics generation",
                        "Developed API with C# .NET Swagger and JWT authentication",
                        "Implemented OAuth 2.0 with Microsoft Azure integration"
                    }
                },
                new Experience
                {
                    Title = "Developer C# .NET",
                    Company = "Lambda Health System",
                    Type = "Internship",
                    Duration = "July 2024 - October 2024",
                    Responsibilities = new List<string>
                    {
                        "Developed HL7 FHIR API server",
                        "Created console application for patient data migration",
                        "Prototyped and implemented new software features"
                    }
                },
                new Experience
                {
                    Title = "Web Developer",
                    Company = "Valloire-Habitat",
                    Type = "Internship",
                    Duration = "April 2022 - July 2022",
                    Responsibilities = new List<string>
                    {
                        "Migrated Windev web application to web-based version",
                        "Developed company web portal with Bootstrap",
                        "Implemented SSO authentication",
                        "Performed unit testing and security enhancements"
                    }
                },
                new Experience
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
                },
                new Experience
                {
                    Title = "Services Offered",
                    Company = "AKMESE",
                    Type = "Services",
                    Duration = "Since September 2021",
                    Responsibilities = new List<string>
                    {
                        "Custom Web Application Development",
                        "API Development and Integration",
                        "Cloud Solutions Implementation",
                        "Business Process Automation",
                        "Technical Consulting"
                    }
                }
            };
        }
    }
}
