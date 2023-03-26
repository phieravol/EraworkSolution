using AppModules.Pakages.Provider;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ViewModels.PakageViewModel.Provider;

namespace Erawork.Pages.Pakages.Provider
{
    public class CreateModel : PageModel
    {

        private readonly IManagePakages managePakages;
        private readonly UserManager<AppUser> userManager;
        public CreateModel(IManagePakages managePakages, UserManager<AppUser> userManager)
        {
            this.managePakages = managePakages;
        }

        [BindProperty] public PakageCreateRequest createRequest { get; set; }

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

			await managePakages.CreatePakageAsync(createRequest);

			return RedirectToPage("./Index");
        }
    }
}
