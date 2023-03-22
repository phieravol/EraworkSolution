using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.CategoryVM.Admin;
using ViewModels.CategoryVM.Public;

namespace AppModules.Categories.Manage
{
    public interface IManageCategory
    {
		Task<List<CategoryViewModel>> GetCategoriesByTermAsync(string searchTerm);
		Task<List<Category>> GetCategoriesAsync();
        Task CreateCategoryAsync(CreateCategoryViewModel request);

        Task DelCategoryAsync(int? id);
        Task<Category> GetCategoryByIdAsync(int? id);
        Task<string> SaveImageAsync(IFormFile? categoryImage);
        Task UpdateCategoryAsync(Category currentCategory);
    }
}
