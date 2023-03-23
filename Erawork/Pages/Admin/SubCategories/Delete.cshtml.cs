using AppModules.SubCategories.Admin;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewModels.CategoryVM.Admin;

namespace Erawork.Pages.Admin.SubCategories
{
    public class DeleteModel : PageModel
    {
        private readonly IManageSubcates manageSub;

        public DeleteModel(IManageSubcates manageSub)
        {
            this.manageSub = manageSub;
        }

        [BindProperty(SupportsGet = true)] public int Id { get; set; }
        [BindProperty(SupportsGet = true)] public int CateId { get; set; }
        public SubCategory subCategory { get; set; }

        /// <summary>
        /// Redirect user to confirm delete page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync()
        {
            subCategory = await manageSub.GetSubCateByIdAsync(Id);

            if (subCategory == null)
            {
                return NotFound();
            }

            return Page();
        }

        /// <summary>
        /// Delete a subcategory by Id
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            await manageSub.DelSubcateAsync(Id);
            return RedirectToPage("./Index");
        }
    }
}
