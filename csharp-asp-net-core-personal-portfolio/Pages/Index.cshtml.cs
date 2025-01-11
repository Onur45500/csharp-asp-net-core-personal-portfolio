using csharp_asp_net_core_personal_portfolio.Models;
using csharp_asp_net_core_personal_portfolio.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace csharp_asp_net_core_personal_portfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ExperienceService _experienceService;
        private readonly EntrepreneurshipService _entrepreneurshipService;
        private readonly EducationService _educationService;
        private readonly SkillsService _skillsService;
        private readonly ProjectService _projectService;

        public List<Experience> Experiences { get; set; }
        public Experience Entrepreneurship { get; set; }
        public List<Education> Educations { get; set; }
        public Skills Skills { get; set; }
        public List<Project> Projects { get; set; }

        public IndexModel(
            ExperienceService experienceService, 
            EntrepreneurshipService entrepreneurshipService,
            EducationService educationService,
            SkillsService skillsService,
            ProjectService projectService)
        {
            _experienceService = experienceService;
            _entrepreneurshipService = entrepreneurshipService;
            _educationService = educationService;
            _skillsService = skillsService;
            _projectService = projectService;
        }

        public void OnGet()
        {
            Experiences = _experienceService.GetExperiences();
            Entrepreneurship = _entrepreneurshipService.GetEntrepreneurship();
            Educations = _educationService.GetEducations();
            Skills = _skillsService.GetSkills();
            Projects = _projectService.GetProjects();
        }
    }
}
