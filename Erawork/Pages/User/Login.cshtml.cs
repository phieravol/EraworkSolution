using AppModules.Users.Public;
using Data.EntityDbContext;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewModels.User;

namespace Erawork.Pages.User
{
    public class LoginModel : PageModel
    {
        // creating a private prop dbcontext
        private readonly EraWorkContext _context;
        private readonly IPublicUser _publicUser;

        // generating constructor
        public LoginModel(EraWorkContext context, IPublicUser publicUser)
        {
            _context = context;
            _publicUser = publicUser;
        }

        //create data transfer object for register request
        [BindProperty]
        public LoginRequest loginRequest { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
			string loginResult = await _publicUser.UserLogin(loginRequest);

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
