using AppModules.Categories.Manage;
using Data.EntityDbContext;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using ViewModels.CategoryVM.Admin;
using Microsoft.AspNetCore.Http;
using ViewModels.CategoryVM.Public;

namespace Erawork.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly IManageCategory _categoryManage;
        private readonly EraWorkContext _context;
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(IManageCategory categorFactory, EraWorkContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _categoryManage = categorFactory;
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public CategoryPagingVM ViewModel { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        [BindProperty]
        public CreateCategoryViewModel? createCategoryVM { get; set; }

        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? pageNumber { get; set; }

        public bool HasPreviousPage
        {
            get
            {
                return (ViewModel.CurrentPage > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (ViewModel.CurrentPage < TotalPages);
            }
        }

        public async Task OnGetAsync()
        {
            Categories = await _categoryManage.GetCategoriesByTermAsync(ViewModel.searchTerm);
            TotalPages = (int)Math.Ceiling(Categories.Count() / (double)ViewModel.PageSize);
            Categories = Categories.Skip((ViewModel.CurrentPage - 1) * ViewModel.PageSize).Take(ViewModel.PageSize).ToList();
        }

        /// <summary>
        /// Create a new category with async
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostCreateAsync()
        {
            await _categoryManage.CreateCategoryAsync(createCategoryVM);
            return new RedirectToPageResult("./Index");
        }
    }
}
