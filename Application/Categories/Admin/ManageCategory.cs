using Data.EntityDbContext;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.CategoryVM.Admin;

namespace AppModules.Categories.Manage
{
    public class ManageCategory : IManageCategory
    {
        private readonly EraWorkContext _context;
        public ManageCategory(EraWorkContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create a new category
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task CreateCategoryAsync(CreateCategoryRequest request)
        {
            if (request.isCategoryActive==null)
            {
                request.isCategoryActive = false;
            }
            var NewCategory = new Category
            {
                CategoryName = request.CategoryName,
                CategoryDescription = request.CategoryDescription,
                isCategoryActive = request.isCategoryActive,
                CategoryImage = await SaveImageAsync(request.CategoryImage)
            };
        }

        private Task<byte[]> SaveImageAsync(object imageFile)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<Category>> GetCategoriesAsync()
		{
			return await _context.Categories.ToListAsync();
		}

		/// <summary>
		/// Get all Categories by search keyword
		/// </summary>
		/// <param name="searchTerm"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task<List<Category>> GetCategoriesByTermAsync(string searchTerm)
		{
			return await _context.Categories.Where(c => c.CategoryName.Contains(searchTerm)).ToListAsync();
		}
	}
}
