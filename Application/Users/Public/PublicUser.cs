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
        public async Task<bool> Login(LoginRequest request)
        {
            var user = _userManager.FindByNameAsync(request.UserName);
            return true;
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
                //result = await _userManager.AddToRoleAsync(user, request.RoleName);
                return true;
            }
            return false;
        }
    }
}
