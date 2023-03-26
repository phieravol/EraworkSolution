using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.SubCatesViewModel;
using ViewModels.SubCatesViewModel.Admin;

namespace AppModules.SubCategories.Admin
{
    public interface IManageSubcates
    {
        Task<List<SubCateVM>> PagingSubcategoriesAsync(SubcatePagingRequest request, int? id);
        Task CreateSubcateAsync(SubcateCreateRequest request);
        Task<List<SubCategory>>? GetSubCatesAsync();
        Task<SubCategory> GetSubCateByIdAsync(int? id);
        Task UpdateSubcateAsync(SubCategory NewsSubcate);
        Task<string> SaveSubcateImageAsync(IFormFile? categoryImage);
        Task DelSubcateAsync(int? id);
    }
}
