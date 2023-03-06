using AppModules.Users.Manage;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Erawork.Pages.User
{
	public class MyProfileModel : PageModel
	{
		private readonly IManageAccount manageAccount;
		private readonly UserManager<AppUser> userManager;
		public MyProfileModel(IManageAccount manageAccount, UserManager<AppUser> userManager)
		{
			this.manageAccount = manageAccount;
			this.userManager = userManager;
		}

		[BindProperty] public AppUser user { get; set; }
		[BindProperty] public IFormFile Avatar { get; set; }
		public string? roleName { get; set; }
		public async Task<IActionResult> OnGetAsync()
		{
			//1. get user session
			string? rawUser = HttpContext.Session.GetString("User");
			if (rawUser != null)
			{
				user = JsonConvert.DeserializeObject<AppUser>(rawUser);
				
			}
			if (user == null)
			{
				HttpContext.Response.Clear();
				HttpContext.Response.StatusCode = 404;
				HttpContext.Response.Redirect("/Errors/Error404");
			}
			var roles = await userManager.GetRolesAsync(user);
			roleName = roles.FirstOrDefault();
			return Page();
		}
		public async Task<IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid)
			{
				await manageAccount.UpdateProfile(user, Avatar);
			}
			return Page();
		}
	}
}
