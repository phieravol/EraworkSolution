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
        private readonly EraWorkContext context;

        public PublicRole(EraWorkContext context)
        {
            this.context = context;
        }

        List<AppRole> IPublicRole.listRoles()
        {
            return context.AppRoles.ToList();
        }
    }
}
