using Data.EntityDbContext;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.User;

namespace AppModules.Users.Public
{
    public class PublicUser : IPublicUser
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly EraWorkContext _context;
        /// <summary>
        /// Constructor for user login & register
        /// </summary>
        /// <param name="signInManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="userManager"></param>
        public PublicUser(
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
            UserManager<AppUser> userManager,
            EraWorkContext context
        ) {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

		/// <summary>
		/// User login with email or password
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public async Task<string> UserLogin(LoginRequest request)
		{
			var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, isPersistent: false, lockoutOnFailure: false);
			var user = _userManager.FindByNameAsync(request.UserName);
			if (result.Succeeded)
			{
				var roles = await _userManager.GetRolesAsync(await user);
				return roles[0];
			}
			return null;
		}

		/// <summary>
		/// Create user account by register info
		/// </summary>
		/// <param name="request"></param>
		/// <returns>true/false if user register success/failed</returns>
		public async Task<bool> Register(RegisterRequest request)
        {
            var user = new AppUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                UserName = request.UserName
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if(result.Succeeded)
            {
                try
                {
                    Guid roleId = request.RoleId;
                    
                    var userByName = await _userManager.FindByNameAsync(user.UserName);

                    var AppUserRole = new AppUserRole
                    {
                        RoleId = roleId,
                        UserId = userByName.Id
                    };

                    await _context.AddAsync(AppUserRole);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
