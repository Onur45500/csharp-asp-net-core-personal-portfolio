using Microsoft.AspNetCore.Mvc.RazorPages;
using csharp_asp_net_core_personal_portfolio.Services;
using csharp_asp_net_core_personal_portfolio.Models;

namespace csharp_asp_net_core_personal_portfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ExperienceService _experienceService;
        private readonly EntrepreneurshipService _entrepreneurshipService;
        
        public List<Experience> Experiences { get; set; }
        public Experience Entrepreneurship { get; set; }
        public List<Experience> Services { get; set; }

        public IndexModel(
            ExperienceService experienceService,
            EntrepreneurshipService entrepreneurshipService)
        {
            _experienceService = experienceService;
            _entrepreneurshipService = entrepreneurshipService;
        }

        public void OnGet()
        {
            Experiences = _experienceService.GetExperiences();
            Entrepreneurship = _entrepreneurshipService.GetEntrepreneurship();
            Services = _entrepreneurshipService.GetServices();
        }
    }
}
