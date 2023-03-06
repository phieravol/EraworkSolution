using AppModules.GeneralModule;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModules.Users.Manage
{
	public class ManageAccount : IManageAccount
	{
		private readonly UserManager<AppUser> userManager;
		private readonly RoleManager<AppRole> roleManager;
		private readonly ISaveImage saveImage;

		public ManageAccount(UserManager<AppUser> userManager, ISaveImage saveImage, RoleManager<AppRole> roleManager)
		{
			this.userManager = userManager;
			this.saveImage = saveImage;
			this.roleManager = roleManager;
		}
		public string? roleName { get; set; }

		public async Task UpdateProfile(AppUser user, IFormFile Avatar)
		{
			string folderPath = "assets/images/user/avatar";

			AppUser CurrentUser = await userManager.FindByNameAsync(user.UserName);
			if (CurrentUser != null)
			{
				CurrentUser.FirstName= user.FirstName;
				CurrentUser.LastName= user.LastName;
				CurrentUser.PhoneNumber = user.PhoneNumber;
				CurrentUser.Gender= user.Gender;
				CurrentUser.UserAvatar = await saveImage.SaveImageAsync(Avatar, folderPath);
				CurrentUser.UserDesc = user.UserDesc;
				CurrentUser.Slogan = user.Slogan;
				
			}
			var roles = await userManager.GetRolesAsync(user);
			roleName = roles.FirstOrDefault();
			
			await userManager.UpdateAsync(CurrentUser);
		}
	}
}
