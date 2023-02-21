using AppModules.SubCategories.Admin;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewModels.CategoryVM.Admin;
using ViewModels.SubCatesViewModel.Admin;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Erawork.Pages.Admin.SubCategories
{
    public class UpdateModel : PageModel
    {
        private readonly IManageSubcates manageSub;

        public UpdateModel(IManageSubcates manageSub)
        {
            this.manageSub = manageSub;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public SubcateUpdateRequest UpdateRequest { get; set; }

        [BindProperty]
        public IFormFile? Image { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
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
