using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.User;

namespace AppModules.Users.Public
{
	public interface IPublicUser
	{
		Task<bool> Register(RegisterRequest request);
		Task<string> UserLogin(LoginRequest request);
	}
}
