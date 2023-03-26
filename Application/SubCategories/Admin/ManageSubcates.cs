using AppModules.Categories.Manage;
using Data.EntityDbContext;
using Data.Models;
using Microsoft.AspNetCore.Http;
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
                SubcateImage = await SaveSubcateImageAsync(request.SubcateImage),
                Category = cate
            };

            await context.SubCategories.AddAsync(subCategory);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete SubCategory by SubCategory Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DelSubcateAsync(int? id)
        {
            SubCategory Subcategory = await GetSubCateByIdAsync(id);
            context.SubCategories.Remove(Subcategory);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Get subcategory by Subcategory Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SubCategory> GetSubCateByIdAsync(int? id)
        {
            var Subcate = from c in context.SubCategories
                           where c.SubCateId == id
                           select c;
            SubCategory? Subcategory = Subcate.FirstOrDefault();
            return Subcategory;
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
        public async Task<List<SubCateVM>> PagingSubcategoriesAsync(SubcatePagingRequest request, int? id)
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
            if (id is not null)
            {
                query = query.Where(x => x.cate.CategoryId == id);

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

        /// <summary>
        /// Add Subcategory Image
        /// </summary>
        /// <param name="subCateImage"></param>
        /// <returns></returns>
        public async Task<string> SaveSubcateImageAsync(IFormFile? subCateImage)
        {
            if (subCateImage != null && subCateImage.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(subCateImage.FileName)}";
                var filePath = Path.Combine("wwwroot", "assets/images/subcates", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await subCateImage.CopyToAsync(fileStream);
                }

                return $"assets/images/subcates/{fileName}";
            }
            return null;
        }


        /// <summary>
        /// Update Subcategory
        /// </summary>
        /// <param name="NewSub"></param>
        /// <returns></returns>
        public async Task UpdateSubcateAsync(SubCategory NewSub)
        {
            SubCategory Subcategory = await GetSubCateByIdAsync(NewSub.SubCateId);
            context.SubCategories.Update(Subcategory);
            await context.SaveChangesAsync();
        }
    }
}
