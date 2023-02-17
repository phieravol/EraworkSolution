using Data.EntityDbContext;
using Data.Models;
using Microsoft.AspNetCore.Http;
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
        /// <param name="createViewModel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task CreateCategoryAsync(CreateCategoryViewModel createViewModel)
        {
            if (createViewModel.isCategoryActive==null)
            {
                createViewModel.isCategoryActive = false;
            }
            var NewCategory = new Category
            {
                CategoryName = createViewModel.CategoryName,
                CategoryDescription = createViewModel.CategoryDescription,
                isCategoryActive = createViewModel.isCategoryActive,
                CategoryImage = await SaveImageAsync(createViewModel.CategoryImage)
            };
            createViewModel.category = NewCategory;
            _context.Categories.Add(NewCategory);
            await _context.SaveChangesAsync();
        }

        private async Task<string> SaveImageAsync(IFormFile? categoryImage)
        {
            if (categoryImage != null && categoryImage.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(categoryImage.FileName)}";
                var filePath = Path.Combine("wwwroot", "assets/images/categories", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await categoryImage.CopyToAsync(fileStream);
                }

                return $"assets/images/categories/{fileName}";
            }
            return null;
        }



        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<Category>>? GetCategoriesAsync()
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

        public async Task DelCategoryAsync(int? id)
        {
            Category category = await GetCategoryByIdAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int? id)
        {
            var Category = from c in _context.Categories
                           where c.CategoryId == id
                           select c;
            Category? category = Category.FirstOrDefault();
            return category;
        }

        public async Task UpdateCategoryAsync(Category NewCategory)
        {
            Category category = await GetCategoryByIdAsync(NewCategory.CategoryId);
            _context.Categories.Update(NewCategory);
            await _context.SaveChangesAsync();
        }
    }
}
