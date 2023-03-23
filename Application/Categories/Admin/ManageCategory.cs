using Data.EntityDbContext;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ViewModels.CategoryVM.Admin;
using ViewModels.CategoryVM.Public;

namespace AppModules.Categories.Manage
{
    public class ManageCategory : IManageCategory
    {
        private readonly EraWorkContext context;
        public ManageCategory(EraWorkContext context)
        {
            this.context = context;
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
            context.Categories.Add(NewCategory);
            await context.SaveChangesAsync();
        }

        public async Task<string?> SaveImageAsync(IFormFile? categoryImage)
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
			return await context.Categories.ToListAsync();
		}

		/// <summary>
		/// Get all Categories by search keyword
		/// </summary>
		/// <param name="searchTerm"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task<List<CategoryViewModel>> GetCategoriesByTermAsync(string searchTerm)
		{
            var query = from c in context.Categories
                        join sub in context.SubCategories
                        on c.CategoryId equals sub.CategoryId into subJoined
                        from cateJoined in subJoined.DefaultIfEmpty()
                        group cateJoined by new { 
                            c.CategoryId, 
                            c.CategoryName,
                            c.CategoryDescription,
                            c.CategoryImage,
                            c.isCategoryActive
                        } into joinedGroup
                        select new CategoryViewModel() {
                            CategoryId = joinedGroup.Key.CategoryId,
                            CategoryName = joinedGroup.Key.CategoryName,
                            CategoryDescription= joinedGroup.Key.CategoryDescription,
                            CategoryImage = joinedGroup.Key.CategoryImage,
                            isCategoryActive = joinedGroup.Key.isCategoryActive,
                            TotalSubs = joinedGroup.Count(cateJoin => cateJoin!= null),
                        };
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.CategoryName.Contains(searchTerm));
            }
            return await query.ToListAsync();
		}

        public async Task DelCategoryAsync(int? id)
        {
            Category category = await GetCategoryByIdAsync(id);
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int? id)
        {
            var Category = from c in context.Categories
                           where c.CategoryId == id
                           select c;
            Category? category = Category.FirstOrDefault();
            return category;
        }

        public async Task UpdateCategoryAsync(Category NewCategory)
        {
            Category category = await GetCategoryByIdAsync(NewCategory.CategoryId);
            context.Categories.Update(NewCategory);
            await context.SaveChangesAsync();
        }
    }
}
