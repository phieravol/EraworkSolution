using AppModules.Categories.Manage;
using Data.EntityDbContext;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.SubCatesViewModel;
using ViewModels.SubCatesViewModel.Admin;

namespace AppModules.SubCategories.Admin
{
    public class ManageSubcates : IManageSubcates
    {
        private readonly EraWorkContext context;
        private readonly IManageCategory manageCategory;

        /// <summary>
        /// Constructor to manage SubCategory
        /// </summary>
        /// <param name="context"></param>
        /// <param name="manageCategory"></param>
        public ManageSubcates(EraWorkContext context, IManageCategory manageCategory)
        {
            this.context = context;
            this.manageCategory = manageCategory;
        }

        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task CreateSubcateAsync(SubcateCreateRequest request)
        {
            Category cate = await manageCategory.GetCategoryByIdAsync(request.CategoryId);

            SubCategory subCategory = new SubCategory()
            {
                SubcateName = request.SubcateName,
                isSubCateActive = request.isSubCateActive,
                SubcateDesc = request.SubcateDesc,
                SubcateImage = request.SubcateImage,
                Category = cate
            };

            await context.SubCategories.AddAsync(subCategory);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Listing all subcategory
        /// </summary>
        /// <returns></returns>
        public async Task<List<SubCategory>> GetSubCatesAsync()
        {
            return await context.SubCategories.ToListAsync();
        }


        /// <summary>
        /// Listing category with search and paging
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<SubCateVM>> PagingSubcategoriesAsync(SubcatePagingRequest request)
        {
            //1. get all
            var query = from sub in context.SubCategories
                        join cate in context.Categories on sub.CategoryId equals cate.CategoryId
                        select new { sub, cate };

            //2. search
            if (!string.IsNullOrEmpty(request.searchTerm))
            {
                query = query.Where(x => x.sub.SubcateName.Contains(request.searchTerm));
            }

            //4. paging
            int totalRow = await query.CountAsync();
            
            var data = query.Skip((request.CurrentPage - 1)*request.PageSize).Take(request.PageSize)
                .Select(x=> new SubCateVM()
                {
                    SubCateId = x.sub.SubCateId,
                    SubcateName = x.sub.SubcateName,
                    SubcateImage = x.sub.SubcateImage,
                    SubcateDesc= x.sub.SubcateDesc,
                    isSubCateActive = x.sub.isSubCateActive,
                    CategoryId= x.sub.CategoryId,
                    CategoryName = x.cate.CategoryName
                });
            return await data.ToListAsync();
        }
    }
}
