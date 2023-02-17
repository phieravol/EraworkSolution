using AppModules.Categories.Manage;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Core.Types;
using ViewModels.CategoryVM.Admin;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Erawork.Pages.Admin.Categories
{
    public class UpdateModel : PageModel
    {
        private readonly IManageCategory _manageCategory;

        public UpdateModel(IManageCategory manageCategory)
        {
            _manageCategory = manageCategory;
        }

        [BindProperty (SupportsGet = true)]
        public int Id { get; set; }
        
        [BindProperty]
        public UpdateCategoryViewModel UpdateVM { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var currentCategory = await _manageCategory.GetCategoryByIdAsync(Id);

            if (currentCategory == null)
            {
                return NotFound();
            }

            UpdateVM = new UpdateCategoryViewModel
            {
                CategoryName = currentCategory.CategoryName,
                CategoryDescription = currentCategory.CategoryDescription,
                isCategoryActive = currentCategory.isCategoryActive,
                CategoryImage = currentCategory.CategoryImage,
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var currentCategory = await _manageCategory.GetCategoryByIdAsync(Id);

            if (currentCategory == null)
            {
                return NotFound();
            }
            currentCategory.CategoryId = Id;
            currentCategory.CategoryName = UpdateVM.CategoryName;
            currentCategory.CategoryDescription = UpdateVM.CategoryDescription;
            currentCategory.isCategoryActive = UpdateVM.isCategoryActive;
            currentCategory.CategoryImage = UpdateVM.CategoryImage;

            await _manageCategory.UpdateCategoryAsync(currentCategory);

            return RedirectToPage("./Index");
        }
    }
}
