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

        public List<Experience> Experiences { get; set; }
        public Experience Entrepreneurship { get; set; }
        public List<Education> Educations { get; set; }

        public IndexModel(
            ExperienceService experienceService, 
            EntrepreneurshipService entrepreneurshipService,
            EducationService educationService)
        {
            _experienceService = experienceService;
            _entrepreneurshipService = entrepreneurshipService;
            _educationService = educationService;
        }

        public void OnGet()
        {
            Experiences = _experienceService.GetExperiences();
            Entrepreneurship = _entrepreneurshipService.GetEntrepreneurship();
            Educations = _educationService.GetEducations();
        }
    }
}
