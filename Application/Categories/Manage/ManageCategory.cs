using AppModules.Categories.DTOs;
using AppModules.GeneralDTOs;
using Data.EntityDbContext;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModules.Categories.Manage
{
    public class ManageCategory : IManageCategory
    {
        private readonly EraWorkContext _context;
        public ManageCategory(EraWorkContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCategory(CategoryCreateRequest request)
        {
            var Category = new Category()
            {
                CategoryName = request.Name,
            };
            _context.Categories.Add(Category);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCategory(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public async Task<PageViewModel<CategoryViewModel>> GetCategoryPagging(string Keyword, int PageIndex, int PageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateCategory(CategoryUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
