using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.EntityDbContext;
using Data.Models;
using AppModules.Categories.Manage;

namespace Erawork.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Data.EntityDbContext.EraWorkContext _context;
        private readonly ILogger<IndexModel> _logger;
        private readonly IManageCategory _manageCategory;
        
        public IndexModel(
            Data.EntityDbContext.EraWorkContext context, 
            ILogger<IndexModel> logger,
            IManageCategory manageCategory

        ) {
            _context = context;
            _logger = logger;
            _manageCategory = manageCategory;
        }

        public IList<Category> Category { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public string CurrentKeyword { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; } = 3;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;

        /**
         * Display items in a page with search & paging
         * Return a void or IActionResult
         */
        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Category = await _manageCategory.GetPaginatedResult(CurrentKeyword, CurrentPage, PageSize);
                Count = await _manageCategory.GetCount();
            }
        }
    }
}
