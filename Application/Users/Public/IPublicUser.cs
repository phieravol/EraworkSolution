using Microsoft.AspNetCore.Mvc;
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
		Task<bool> Login(LoginRequest request);
	}
}
