using System.Collections.Generic;
using csharp_asp_net_core_personal_portfolio.Models;

namespace csharp_asp_net_core_personal_portfolio.Services
{
    public class SkillsService
    {
        public Skills GetSkills()
        {
            return new Skills
            {
                TechnicalSkills = new List<string>
                {
                    "C# .NET",
                    "JavaScript/TypeScript",
                    "React.js",
                    "Node.js",
                    "Python"
                },
                SoftSkills = new List<string>
                {
                    "Problem Solving",
                    "Team Leadership",
                    "Communication"
                }
            };
        }
    }
}
