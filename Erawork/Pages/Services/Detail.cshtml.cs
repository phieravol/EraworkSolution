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

        [BindProperty(SupportsGet = true)] public int id { get; set; }
        public ServicesVM Services { get; set; }
		public List<Pakage> PakagesByService { get; set; }
		public async Task<IActionResult> OnGetAsync()
        {
            Services = await publicServices.GetServiceDetailAsync(id);

            PakagesByService = managePakages.GetPakagesService(Services.ServiceId);

            if (PakagesByService!= null)
			{
                Services.Pakages = PakagesByService;
            }
            return Page();
        }
    }
}
