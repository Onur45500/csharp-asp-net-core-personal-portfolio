using csharp_asp_net_core_personal_portfolio.Models;
using csharp_asp_net_core_personal_portfolio.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectFilter = csharp_asp_net_core_personal_portfolio.Models.ProjectFilter;

namespace csharp_asp_net_core_personal_portfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ExperienceService _experienceService;
        private readonly EntrepreneurshipService _entrepreneurshipService;
        private readonly EducationService _educationService;
        private readonly SkillsService _skillsService;
        private readonly ProjectService _projectService;
        private readonly GitHubService _githubService;

        public required List<Experience> Experiences { get; set; }
        public required Experience Entrepreneurship { get; set; }
        public required List<Education> Educations { get; set; }
        public required Skills Skills { get; set; }
        public required List<Project> Projects { get; set; }
        public required List<GitHubProject> GitHubProjects { get; set; }

        public IndexModel(
            ExperienceService experienceService, 
            EntrepreneurshipService entrepreneurshipService,
            EducationService educationService,
            SkillsService skillsService,
            ProjectService projectService,
            GitHubService githubService)
        {
            _experienceService = experienceService;
            _entrepreneurshipService = entrepreneurshipService;
            _educationService = educationService;
            _skillsService = skillsService;
            _projectService = projectService;
            _githubService = githubService;
        }

        public async Task OnGetAsync()
        {
            Experiences = _experienceService.GetExperiences();
            Entrepreneurship = _entrepreneurshipService.GetEntrepreneurship();
            Educations = _educationService.GetEducations();
            Skills = _skillsService.GetSkills();
            Projects = _projectService.GetProjects();
            GitHubProjects = await _githubService.GetPublicRepositoriesAsync();
        }
    }
}
