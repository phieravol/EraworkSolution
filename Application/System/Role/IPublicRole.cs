using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModules.System.Role
{
    public interface IPublicRole
    {
        List<AppRole> listRoles();
    }
}
