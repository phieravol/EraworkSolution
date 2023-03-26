using AppModules.Categories.Manage;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using ViewModels.CategoryVM.Admin;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Erawork.Pages.Admin.Categories
{
    public class UpdateModel : PageModel
    {
        private readonly IManageCategory manageCategory;
        private readonly UserManager<AppUser> userManager;

        public UpdateModel(IManageCategory manageCategory, UserManager<AppUser> userManager)
        {
            this.manageCategory = manageCategory;
            this.userManager = userManager;
        }

        [BindProperty (SupportsGet = true)]
        public int Id { get; set; }
        
        [BindProperty]
        public UpdateCategoryViewModel UpdateVM { get; set; }

        [BindProperty]
        public IFormFile? Image { get; set; }

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
            var currentCategory = await manageCategory.GetCategoryByIdAsync(Id);

            if (currentCategory == null)
            {
                return NotFound();
            }

            UpdateVM = new UpdateCategoryViewModel
            {
                CategoryId = Id,
                CategoryName = currentCategory.CategoryName,
                CategoryDescription = currentCategory.CategoryDescription,
                isCategoryActive = currentCategory.isCategoryActive
            };
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Category currentCategory = await manageCategory.GetCategoryByIdAsync(Id);

            if (currentCategory == null)
            {
                return NotFound();
            }
            currentCategory.CategoryId = Id;
            currentCategory.CategoryName = UpdateVM.CategoryName;
            currentCategory.CategoryDescription = UpdateVM.CategoryDescription;
            currentCategory.isCategoryActive = UpdateVM.isCategoryActive;
            currentCategory.CategoryImage = await manageCategory.SaveImageAsync(UpdateVM.CategoryImage);

            await manageCategory.UpdateCategoryAsync(currentCategory);

            return RedirectToPage("./Index");
        }
    }
}
