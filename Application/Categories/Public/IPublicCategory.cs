using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModules.Categories.Public
{
    public interface IPublicCategory
    {
        Task<List<Category>> GetActiveCategoriesAsync();
    }
}
