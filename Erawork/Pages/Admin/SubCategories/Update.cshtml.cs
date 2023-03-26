using AppModules.SubCategories.Admin;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ViewModels.CategoryVM.Admin;
using ViewModels.SubCatesViewModel.Admin;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Erawork.Pages.Admin.SubCategories
{
    public class UpdateModel : PageModel
    {
        private readonly IManageSubcates manageSub;
        private readonly UserManager<AppUser> userManager;
        public UpdateModel(IManageSubcates manageSub, UserManager<AppUser> userManager)
        {
            this.manageSub = manageSub;
            this.userManager = userManager;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public SubcateUpdateRequest UpdateRequest { get; set; }

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

            var currentSubCategory = await manageSub.GetSubCateByIdAsync(Id);
            if (currentSubCategory == null)
            {
                return NotFound();
            }
            UpdateRequest = new SubcateUpdateRequest
            {
                SubcateId = Id,
                SubcateName = currentSubCategory.SubcateName,
                isSubCateActive = currentSubCategory.isSubCateActive,
                SubcateDesc = currentSubCategory.SubcateDesc,
                CategoryId= currentSubCategory.CategoryId,
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            SubCategory currentCategory = await manageSub.GetSubCateByIdAsync(Id);

            if (currentCategory == null)
            {
                return NotFound();
            }
            currentCategory.SubCateId = Id;
            currentCategory.SubcateName = UpdateRequest.SubcateName;
            currentCategory.SubcateDesc = UpdateRequest.SubcateDesc;
            currentCategory.isSubCateActive = UpdateRequest.isSubCateActive;
            currentCategory.SubcateImage = await manageSub.SaveSubcateImageAsync(UpdateRequest.SubcateImage);

            await manageSub.UpdateSubcateAsync(currentCategory);

            return RedirectToPage("./Index");
        }
    }
}
