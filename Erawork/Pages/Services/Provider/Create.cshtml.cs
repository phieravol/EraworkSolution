using AppModules.Services.Admin;
using AppModules.SubCategories.Admin;
using Data.Models;
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

        public CreateModel(IManageServices manageServices, IManageSubcates manageSubcates)
        {
            this.manageServices = manageServices;
            this.manageSubcates= manageSubcates;
        }

        [BindProperty] public ServicesCreateRequest? createRequest { get; set; }
        public List<SubCategory>? subCategories { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
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
