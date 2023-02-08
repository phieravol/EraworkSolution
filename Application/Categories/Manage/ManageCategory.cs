using AppModules.Categories.DTOs;
using AppModules.GeneralDTOs;
using Data.EntityDbContext;
using Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
                CategoryName = request.CategoryName,
                CategoryImage = request.CategoryImage,
                isCategoryActive = request.isCategoryActive,
                CategoryDescription = request.CategoryDescription

            };
            _context.Categories.AddAsync(Category);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCategory(int CategoryId)
        {
            var Category = await _context.Categories.FindAsync(CategoryId);
            if (Category==null)
            {
                throw new Exception($"Can not find Category has Id = {CategoryId}");
            }
            _context.Categories.Remove(Category);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResultBase<CategoryViewModel>> GetCategoriesPagging(CategoryPagingRequest request)
        {
            //1. select join
            var query = from c in _context.Categories
                        select c;
            //2. Filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.CategoryName.Contains(request.Keyword));
            }

            //3. Paging
            int totalRows = await query.CountAsync();
            int recordsRange = (request.CurrentPage - 1) * request.PageSize;

            var PageIndexData = await query.Skip(recordsRange)
                .Take(request.PageSize)
                .Select(x => new CategoryViewModel()
                {
                    CategoryId = x.CategoryId,
                    CategoryName = x.CategoryName,
                    isCategoryActive = x.isCategoryActive,
                    CategoryImage = x.CategoryImage,
                    CategoryDescription = x.CategoryDescription
                }).ToListAsync();

            var pageResult = new PagedResultBase<CategoryViewModel>()
            {
                TotalRecords = totalRows,
                Items = PageIndexData
            };

            return pageResult;
        }

        public async Task<int> UpdateCategory(CategoryUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
