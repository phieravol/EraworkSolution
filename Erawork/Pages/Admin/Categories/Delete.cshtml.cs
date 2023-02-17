using AppModules.Categories.Manage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Core.Types;
using ViewModels.CategoryVM.Admin;

namespace Erawork.Pages.Admin.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly IManageCategory _manageCategory;

        public DeleteModel(IManageCategory manageCategory)
        {
            _manageCategory = manageCategory;
        }

        [BindProperty (SupportsGet =true)]
        public DeleteCategoryViewModel DelViewModel { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            DelViewModel.Category = await _manageCategory.GetCategoryByIdAsync(DelViewModel.Id);

            if (DelViewModel.Category == null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync()
        {
            await _manageCategory.DelCategoryAsync(DelViewModel.Id);
            return RedirectToPage("./Index");
        }
    }
}
