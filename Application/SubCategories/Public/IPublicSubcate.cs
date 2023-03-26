using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.SubCatesViewModel;

namespace AppModules.SubCategories.Public
{
    public interface IPublicSubcate
    {
        Task<List<SubCategory>>? ActiveSubCatesById(int CategoryId);
        Task<List<SubCateVM>> GetSubCatesByCateId(int cateId);
    }
}
