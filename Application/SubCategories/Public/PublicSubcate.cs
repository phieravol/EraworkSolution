using AppModules.Services.Public;
using Data.EntityDbContext;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.SubCatesViewModel;

namespace AppModules.SubCategories.Public
{
    public class PublicSubcate : IPublicSubcate
    {
        private readonly EraWorkContext context;
        private readonly IPublicServices publicServices;

        public PublicSubcate(EraWorkContext context, IPublicServices publicServices)
        {
            this.context = context;
            this.publicServices = publicServices;
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

        public async Task<List<SubCateVM>> GetSubCatesByCateId(int cateId)
        {
            var query = from sub in context.SubCategories
                        where sub.isSubCateActive == true && sub.CategoryId == cateId
                        select sub;
            List<SubCateVM> subCates = await query.Select(x => new SubCateVM()
            {
                SubCateId = x.SubCateId,
                SubcateName = x.SubcateName,
                SubcateDesc = x.SubcateDesc,
                SubcateImage = x.SubcateImage,
                isSubCateActive = x.isSubCateActive,
                CategoryId = cateId,
            }).ToListAsync();

            if (subCates.Count != 0)
            {
                foreach (var item in subCates)
                {
                    item.Services = await publicServices.GetServiceBySubcateAsync(item.SubCateId);
                }
            }
            return subCates;
        }
    }
}
