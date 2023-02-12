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
        private readonly SignInManager<AppUser> _signInManager;

        // generating constructor
        public LoginModel(EraWorkContext context, IPublicUser publicUser, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _publicUser = publicUser;
            _signInManager = signInManager;
        }

        //create data transfer object for register request
        [BindProperty]
        public LoginRequest loginRequest { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginRequest.UserName, loginRequest.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToPage("/Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            return Page();
        }
    }
}
