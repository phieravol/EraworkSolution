using Data.Models;
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
        Task<List<SubCateVM>> PagingSubcategoriesAsync(SubcatePagingRequest request);
        Task CreateSubcateAsync(SubcateCreateRequest request);
        Task<List<SubCategory>>? GetSubCatesAsync();
    }
}
