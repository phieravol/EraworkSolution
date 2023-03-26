using AppModules.Categories.Manage;
using AppModules.Categories.Public;
using AppModules.Services.Public;
using AppModules.SubCategories.Public;
using Data.EntityDbContext;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewModels.SubCatesViewModel;

namespace Erawork.Pages.Admin.Categories
{
    public class DetailModel : PageModel
    {
        private readonly IPublicSubcate publicSubcate;
        private readonly IPublicServices publicServices;
        private readonly IManageCategory serviceCategory;

        public DetailModel(IPublicSubcate publicSubcate, IPublicServices publicServices, IManageCategory serviceCategory)
        {
            this.publicSubcate = publicSubcate;
            this.publicServices = publicServices;
            this.serviceCategory = serviceCategory;
        }

        [BindProperty(SupportsGet = true)] public int CateId { get; set; }
        public List<SubCateVM> subCategories { get; set; }
        public string? CategoryName { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (CateId.ToString()=="" || CateId.ToString().Length==0)
            {
                return NotFound();
            }
            //get Category name
            var Cate = await serviceCategory.GetCategoryByIdAsync(CateId);
            CategoryName = Cate.CategoryName;

            //get all subcategories of this cate
            subCategories = await publicSubcate.GetSubCatesByCateId(CateId);

            
            return Page();
        }
    }
}
