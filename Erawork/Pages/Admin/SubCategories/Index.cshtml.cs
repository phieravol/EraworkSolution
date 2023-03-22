using AppModules.Categories.Manage;
using AppModules.SubCategories.Admin;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ViewModels.SubCatesViewModel;
using ViewModels.SubCatesViewModel.Admin;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Erawork.Pages.Admin.SubCategories
{
    public class IndexModel : PageModel
    {
        private readonly IManageSubcates manageSubcates;
        private readonly IManageCategory manageCategory;
        public IndexModel(IManageSubcates manageSubcates, IManageCategory manageCategory)
        {
            this.manageSubcates = manageSubcates;
            this.manageCategory = manageCategory;
        }

        [BindProperty (SupportsGet = true)]
        public SubcatePagingRequest pagingRequest { get; set; }
        
        [BindProperty (SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        public SubcateCreateRequest createRequest { get; set; }

        public List<SubCateVM> subcates { get; set; }
        public List<Category> categories { get; set; }
        public int TotalPages { get; set; }

        public bool HasPreviousPage
        {
            get
            {
                return (pagingRequest.CurrentPage > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (pagingRequest.CurrentPage < TotalPages);
            }
        }

        public async Task OnGetAsync()
        {
            categories = await manageCategory.GetCategoriesAsync();
            subcates = await manageSubcates.PagingSubcategoriesAsync(pagingRequest, id);
            List<SubCategory> listSubCate = await manageSubcates.GetSubCatesAsync();
            TotalPages = (int)Math.Ceiling(subcates.Count() / (double)pagingRequest.PageSize);
          
        }

        public async Task<IActionResult> OnPostAsync()
        {
            categories = await manageCategory.GetCategoriesAsync();
            await manageSubcates.CreateSubcateAsync(createRequest);
            
            return Page();
        }
    }
}
