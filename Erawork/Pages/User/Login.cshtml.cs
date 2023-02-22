using AppModules.Users.Public;
using Data.EntityDbContext;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ViewModels.User;

namespace Erawork.Pages.User
{
    public class LoginModel : PageModel
    {
        // creating a private prop dbcontext
        private readonly EraWorkContext context;
        private readonly IPublicUser publicUser;
        private readonly UserManager<AppUser> userManager;
        // generating constructor
        public LoginModel(EraWorkContext context, IPublicUser publicUser, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.publicUser = publicUser;
            this.userManager = userManager;
        }

        //create data transfer object for register request
        [BindProperty]
        public LoginRequest loginRequest { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            string loginResult = await publicUser.UserLogin(loginRequest);
            if (loginResult != null)
            {
                //save user session
                var user = await userManager.FindByNameAsync(loginRequest.UserName);
                var json = JsonConvert.SerializeObject(user);

                var session = HttpContext.Session;
                session.SetString("User", json);
            }

            if (ModelState.IsValid)
            {
                switch (loginResult)
                {
                    case "Admin":
                        return RedirectToPage($"/Admin/Index");
                        break;
                    default:
                        return RedirectToPage($"/Index");
                        break;
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return Page();
        }
    }
}
