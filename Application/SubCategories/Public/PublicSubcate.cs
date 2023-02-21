using Data.EntityDbContext;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModules.SubCategories.Public
{
    public class PublicSubcate : IPublicSubcate
    {
        private readonly EraWorkContext context;

        public PublicSubcate(EraWorkContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all active SubCategory by category Id
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<SubCategory>> ActiveSubCatesById(int CategoryId)
        {
            int test = CategoryId;
            var query = from sub in context.SubCategories
                        where sub.isSubCateActive == true && sub.CategoryId == CategoryId
                        select sub;
            List<SubCategory> SubCates = await query.ToListAsync();
            return SubCates;
        }
    }
}
