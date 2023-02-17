using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.CategoryVM.Admin;

namespace AppModules.Categories.Manage
{
    public interface IManageCategory
    {
		Task<List<Category>> GetCategoriesByTermAsync(string searchTerm);
		Task<List<Category>> GetCategoriesAsync();
        Task CreateCategoryAsync(CreateCategoryViewModel request);

        Task DelCategoryAsync(int? id);
        Task<Category> GetCategoryByIdAsync(int? id);
        
    }
}
