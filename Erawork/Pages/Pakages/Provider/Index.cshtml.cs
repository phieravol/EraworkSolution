using AppModules.Pakages.Provider;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ViewModels.ServiceViewModel;

namespace Erawork.Pages.Pakages.Provider
{
    public class IndexModel : PageModel
    {
        private readonly IManagePakages managePakages;

		public IndexModel(IManagePakages managePakages)
		{
			this.managePakages = managePakages;
		}

		[BindProperty] public AppUser user { get; set; }
		public List<ServicesVM> ServicePakages { get; set; }
		public async Task<IActionResult> OnGetAsync()
        {
			//1. get user session
			string? rawUser = HttpContext.Session.GetString("User");
			if (rawUser != null)
			{
				user = JsonConvert.DeserializeObject<AppUser>(rawUser);

			}
			if (user == null)
			{
				HttpContext.Response.Clear();
				HttpContext.Response.StatusCode = 404;
				HttpContext.Response.Redirect("/Errors/Error404");
			}

			//2. get all services
			ServicePakages = await managePakages.GetServicesUser(user);

			//3. get all pakages of each pakage
			foreach (var item in ServicePakages)
			{
				item.Pakages = managePakages.GetPakagesService(item.ServiceId);
			}
			return Page();
        }
    }


}
