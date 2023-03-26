using AppModules.Pakages.Provider;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ViewModels.ServiceViewModel;

namespace Erawork.Pages.Pakages.Provider
{
    public class IndexModel : PageModel
    {
        private readonly IManagePakages managePakages;
        private readonly UserManager<AppUser> userManager;
        public IndexModel(IManagePakages managePakages, UserManager<AppUser> userManager)
		{
			this.managePakages = managePakages;
			this.userManager = userManager;
		}

		[BindProperty] public AppUser user { get; set; }
		public List<ServicesVM> ServicePakages { get; set; }
		public async Task<IActionResult> OnGetAsync()
        {
            //get user session
            string? rawUser = HttpContext.Session.GetString("User");
            AppUser? user = null;
            if (rawUser != null)
            {
                user = JsonConvert.DeserializeObject<AppUser>(rawUser);
            }
            if (user == null)
            {
                return RedirectToPage("/User/Login");
            }
            else
            {
                var Role = await userManager.GetRolesAsync(user);
                if (Role[0] != "Provider")
                {
                    return RedirectToPage("/Forbidden");
                }
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
