using Data.EntityDbContext;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Constructor for user login & register
        /// </summary>
        /// <param name="signInManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="userManager"></param>
        public PublicUser(
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
            UserManager<AppUser> userManager
        ) {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        /// <summary>
        /// User login with email or password
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> Login(LoginRequest request)
        {
            var user = _userManager.FindByNameAsync(request.Email);
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
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            return result.Succeeded;
        }
    }
}
