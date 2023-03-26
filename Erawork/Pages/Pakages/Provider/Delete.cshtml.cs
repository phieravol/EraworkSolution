using AppModules.Pakages.Provider;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Erawork.Pages.Pakages.Provider
{
    public class DeleteModel : PageModel
    {
        private readonly IManagePakages managePakages;
        private readonly UserManager<AppUser> userManager;
        public DeleteModel(IManagePakages managePakages, UserManager<AppUser> userManager)
		{
			this.managePakages = managePakages;
            this.userManager = userManager;
		}

		[BindProperty(SupportsGet = true)] public int Pakage { get; set; }
		[BindProperty] public int Name { get; set; }
        [BindProperty] public Pakage DeletePackage { get; set; }

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

            DeletePackage = await managePakages.GetPakageByIdAsync(Pakage);

			return Page();
        }

		public async Task<IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid)
			{
				await managePakages.DeletePagageAsync(DeletePackage.PakageId);
			}
			return RedirectToPage("./Index");
		}
	}
}
