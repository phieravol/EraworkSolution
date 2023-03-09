using AppModules.Pakages.Provider;
using AppModules.Services.Public;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewModels.ServiceViewModel;

namespace Erawork.Pages.Services
{
    public class DetailModel : PageModel
    {
        private readonly IPublicServices publicServices;
		private readonly IManagePakages managePakages;
		public DetailModel(IPublicServices publicServices, IManagePakages managePakages)
		{
			this.publicServices = publicServices;
			this.managePakages = managePakages;
		}

        [BindProperty(SupportsGet = true)] public int DetailId { get; set; }
        public ServicesVM Services { get; set; }
		public async Task<IActionResult> OnGetAsync()
        {
            Services = await publicServices.GetServiceDetailAsync(DetailId);
			Services.Pakages = managePakages.GetPakagesService(Services.ServiceId);
			if (Services == null)
			{
				HttpContext.Response.Clear();
				HttpContext.Response.StatusCode = 404;

				HttpContext.Response.Redirect("/Errors/Error404");
			}

			return Page();
        }
    }
}
