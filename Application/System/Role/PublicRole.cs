using Data.EntityDbContext;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModules.System.Role
{
    public class PublicRole : IPublicRole
    {
        private readonly EraWorkContext _context;

        public PublicRole(EraWorkContext context)
        {
            _context = context;
        }

        List<AppRole> IPublicRole.listRoles()
        {
            return _context.AppRoles.ToList();
        }
    }
}
