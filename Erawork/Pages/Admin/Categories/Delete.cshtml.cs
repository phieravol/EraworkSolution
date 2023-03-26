using AppModules.Categories.Manage;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using ViewModels.CategoryVM.Admin;

namespace Erawork.Pages.Admin.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly IManageCategory manageCategory;
        private readonly UserManager<AppUser> userManager;

        public DeleteModel(IManageCategory manageCategory, UserManager<AppUser> userManager)
        {
            this.manageCategory = manageCategory;
            this.userManager = userManager;
        }

        [BindProperty (SupportsGet =true)]
        public DelViewModel DelViewModel { get; set; }

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
                if (Role[0] != "Admin")
                {
                    return RedirectToPage("/Forbidden");
                }
            }
            DelViewModel.Category = await manageCategory.GetCategoryByIdAsync(DelViewModel.Id);

            if (DelViewModel.Category == null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            await manageCategory.DelCategoryAsync(DelViewModel.Id);
            return RedirectToPage("./Index");
        }
    }
}
