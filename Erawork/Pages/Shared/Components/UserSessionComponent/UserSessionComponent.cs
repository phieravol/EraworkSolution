using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Erawork.Pages.Shared.Components.UserSessionComponent
{
    public class UserSessionComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string? rawUser = HttpContext.Session.GetString("User");
            AppUser? user = null;
            if (rawUser != null)
            {
                user = JsonConvert.DeserializeObject<AppUser>(rawUser);
            }
            return View("UserSessionComponent", user);
        }
    }
}
