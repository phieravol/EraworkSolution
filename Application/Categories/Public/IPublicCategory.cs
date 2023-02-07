using AppModules.Categories.DTOs;
using AppModules.GeneralDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModules.Categories.Public
{
    public interface IPublicCategory
    {
        PageViewModel<CategoryViewModel> GetAllCategories();
        PageViewModel<CategoryViewModel> GetCategoriesResult(string keyword);
    }
}
