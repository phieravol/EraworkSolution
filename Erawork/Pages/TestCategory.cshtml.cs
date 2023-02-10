using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.EntityDbContext;
using Data.Models;

namespace Erawork.Pages
{
    public class TestCategoryModel : PageModel
    {
        private readonly Data.EntityDbContext.EraWorkContext _context;

        public TestCategoryModel(Data.EntityDbContext.EraWorkContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Category = await _context.Categories.ToListAsync();
            }
        }
    }
}
