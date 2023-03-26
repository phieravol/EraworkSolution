using AppModules.SubCategories.Public;
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
        private readonly EraWorkContext context;
        private readonly IPublicSubcate publicSubcate;
        public PublicCategory(EraWorkContext context, IPublicSubcate publicSubcate)
        {
            this.context = context;
            this.publicSubcate = publicSubcate;
        }

        /// <summary>
        /// Get All Category activating
        /// </summary>
        /// <returns></returns>
        public async Task<List<Category>> GetActiveCategoriesAsync()
        {
            var query = from c in context.Categories
                        where c.isCategoryActive == true
                        select c;
            List<Category> categories = await query.ToListAsync();
			foreach (var cate in categories)
            {
                List<SubCategory>? subCates = await publicSubcate.ActiveSubCatesById(cate.CategoryId);
                cate.SubCategories = subCates;
			}
			return categories;
        }
    }
}
