using Data.EntityDbContext;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModules.Categories.Public
{
    public class PublicCategory : IPublicCategory
    {
        private readonly EraWorkContext _context;

        public PublicCategory(EraWorkContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get All Category activating
        /// </summary>
        /// <returns></returns>
        public async Task<List<Category>> GetActiveCategoriesAsync()
        {
            var query = from c in _context.Categories
                        where c.isCategoryActive == true
                        select c;
            List<Category> categories = await query.ToListAsync();
            return categories;
        }
    }
}
