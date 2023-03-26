using AppModules.Services.Admin;
using AppModules.SubCategories.Admin;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ViewModels.ServiceViewModel;
using ViewModels.ServiceViewModel.Admin;

namespace Erawork.Pages.Services.Provider
{
    public class CreateModel : PageModel
    {
        private readonly IManageServices manageServices;
        private readonly IManageSubcates manageSubcates;
        private readonly UserManager<AppUser> userManager;
        public CreateModel(IManageServices manageServices, IManageSubcates manageSubcates, UserManager<AppUser> userManager)
        {
            this.manageServices = manageServices;
            this.manageSubcates= manageSubcates;
            this.userManager = userManager;
        }

        [BindProperty] public ServicesCreateRequest? createRequest { get; set; }
        public List<SubCategory>? subCategories { get; set; }

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
            subCategories = await manageSubcates.GetSubCatesAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            
            if (ModelState.IsValid)
            {
                // 1. Get User Session
                string? rawUser = HttpContext.Session.GetString("User");
                AppUser? User = JsonConvert.DeserializeObject<AppUser>(rawUser);

                if (ModelState.IsValid && User != null)
                {
                    await manageServices.CreateServiceAsync(createRequest, User);
                }
            }
            return new RedirectToPageResult("./Index");
        }
    }
}
