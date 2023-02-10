using AppModules.GeneralDTOs;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModules.Categories.Manage
{
    public interface IManageCategory
    {
        Task<List<Category>> GetPaginatedResult(string CurrentKeyword, int currentPage, int pageSize = 3);
        Task<int> GetCount();

    }
}
