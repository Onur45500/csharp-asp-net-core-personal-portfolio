using System.Collections.Generic;
using csharp_asp_net_core_personal_portfolio.Models;

namespace csharp_asp_net_core_personal_portfolio.Services
{
    public class ProjectService
    {
        public List<Project> GetProjects()
        {
            return new List<Project>
            {
                new Project
                {
                    Title = "Transcriber AI",
                    Description = "An AI-powered transcription service that converts audio to text with high accuracy. Features include multi-language support, speaker diarization, and custom vocabulary.",
                    Technologies = new List<string>
                    {
                        "AI/ML",
                        "Audio Processing",
                        "Web Development"
                    },
                    Links = new List<ProjectLink>
                    {
                        new() { Title = "GitHub", Url = "https://github.com/username/transcriber-ai" },
                        new() { Title = "Live Demo", Url = "https://transcriber-ai.example.com" }
                    }
                },
                new Project
                {
                    Title = "Four Brothers",
                    Description = "A simple front website for a restaurant",
                    Technologies = new List<string>
                    {
                        "Web Development",
                        "UI/UX Design"
                    },
                    Links = new List<ProjectLink>
                    {
                        new() { Title = "Website", Url = "https://fourbrothers.example.com" }
                    }
                },
                new Project
                {
                    Title = "Taco Ta Crêpe",
                    Description = "A simple front website for a restaurant.",
                    Technologies = new List<string>
                    {
                        "Web Development",
                        "UI/UX Design"
                    },
                    Links = new List<ProjectLink>
                    {
                        new() { Title = "Website", Url = "https://tacotacrepe.example.com" }
                    }
                },
                new Project
                {
                    Title = "Fratelli Orléans",
                    Description = "A simple front website for a restaurant.",
                    Technologies = new List<string>
                    {
                        "Web Development",
                        "UI/UX Design"
                    },
                    Links = new List<ProjectLink>
                    {
                        new() { Title = "Website", Url = "https://fratelliorleans.example.com" }
                    }
                }
            };
        }
    }
}
