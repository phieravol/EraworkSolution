using AppModules.Users.Manage;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Erawork.Pages.Shared.Components.UserSessionComponent
{
    public class UserSessionComponent : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IManageAccount manageAccount;
		public UserSessionComponent(UserManager<AppUser> userManager, IManageAccount manageAccount)
		{
			this.userManager = userManager;
            this.manageAccount = manageAccount;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            string? rawUser = HttpContext.Session.GetString("User");
            AppUser? user = null;
            if (rawUser != null)
            {
                AppUser userFromSession = JsonConvert.DeserializeObject<AppUser>(rawUser);
                user = await manageAccount.GetUserByUsername(userFromSession.UserName);
				var roles = await userManager.GetRolesAsync(user);
				string? RoleUser = roles[0];
			}
            return View("UserSessionComponent", user);
        }
    }
}
