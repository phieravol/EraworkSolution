using AppModules.Categories.Manage;
using Data.EntityDbContext;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using ViewModels.CategoryVM.Admin;

namespace Erawork.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly IManageCategory _categoryManage;
		private readonly EraWorkContext _context;

		public IndexModel(IManageCategory categorFactory, EraWorkContext context)
		{
			_context = context;
			_categoryManage = categorFactory;
		}

        [BindProperty(SupportsGet = true)]
        public CategoryPagingVM ViewModel { get; set; }

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
			if (!string.IsNullOrEmpty(ViewModel.searchTerm))
			{
				var categories = await _categoryManage.GetCategoriesByTermAsync(ViewModel.searchTerm);
				ViewModel.categories = categories;
			}
			else
			{
				var categories = await _categoryManage.GetCategoriesAsync();
				ViewModel.categories = categories;
			}

			TotalPages = (int)Math.Ceiling(ViewModel.categories.Count() / (double)ViewModel.PageSize);

			ViewModel.categories = ViewModel.categories.Skip((ViewModel.CurrentPage - 1) * ViewModel.PageSize).Take(ViewModel.PageSize).ToList();
		}
	}
}
