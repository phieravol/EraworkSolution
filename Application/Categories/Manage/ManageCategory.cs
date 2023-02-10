using AppModules.GeneralDTOs;
using Data.EntityDbContext;
using Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModules.Categories.Manage
{
    public class ManageCategory : IManageCategory
    {
        private readonly EraWorkContext _context;
        public ManageCategory(EraWorkContext context)
        {
            _context = context;
        }

        public async Task<int> GetCount()
        {
            var data = await GetData();
            return data.Count;
        }

        public async Task<List<Category>> GetPaginatedResult(string CurrentKeyword, int currentPage, int pageSize = 3)
        {
            var data = await GetData();
            return data.OrderBy(d => d.CategoryId).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        private async Task<List<Category>> GetData()
        {
            var query = from c in _context.Categories
                        select c;

            return await query.ToListAsync();
        }
    }
}
