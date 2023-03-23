using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModules.Users.Manage
{
	public interface IManageAccount
	{
        Task<AppUser> GetUserByUsername(string userName);
        Task UpdateProfile(AppUser user, IFormFile avatar);
	}
}
