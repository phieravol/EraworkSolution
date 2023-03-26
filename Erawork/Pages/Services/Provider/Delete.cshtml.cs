using AppModules.Services.Admin;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Erawork.Pages.Services.Provider
{
    public class DeleteModel : PageModel
    {
        private readonly IManageServices manageServices;
        private readonly UserManager<AppUser> userManager;
        public DeleteModel(IManageServices manageServices, UserManager<AppUser> userManager)
        {
            this.manageServices = manageServices;
            this.userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public Service service { get; set; }


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
            service = await manageServices.GetServiceByIdAsync(Id);
            if (service == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await manageServices.DeleteServiceAsync(Id);
            return RedirectToPage("./Index");
        }
    }
}
