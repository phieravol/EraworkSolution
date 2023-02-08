using AppModules.Categories.DTOs;
using AppModules.GeneralDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModules.Categories.Manage
{
    public interface IManageCategory
    {
        Task<int> CreateCategory(CategoryCreateRequest request);
        Task<int> UpdateCategory(CategoryUpdateRequest request);
        Task<int> DeleteCategory(int CategoryId);
        Task<PagedResultBase<CategoryViewModel>> GetCategoriesPagging(CategoryPagingRequest request);

    }
}
