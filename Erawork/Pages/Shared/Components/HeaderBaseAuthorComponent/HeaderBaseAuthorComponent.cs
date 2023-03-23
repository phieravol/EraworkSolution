using AppModules.Posts.Public;
using AppModules.System.Role;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Erawork.Pages.Shared.Components.HeaderBaseAuthorComponent
{
    public class HeaderBaseAuthorComponent : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;

        public HeaderBaseAuthorComponent(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string? rawUser = HttpContext.Session.GetString("User");
            AppUser? user = null;
            string? RoleUser = null;
            if (rawUser != null)
            {
                user = JsonConvert.DeserializeObject<AppUser>(rawUser);
                var roles = await userManager.GetRolesAsync(user);
                RoleUser = roles[0];
            }
            return View("HeaderBaseAuthorComponent", RoleUser);
        }
    }
}
