using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Erawork.Pages.User
{
    public class LogoutModel : PageModel
    {

        private readonly SignInManager<AppUser> signInManager;

		public LogoutModel(SignInManager<AppUser> signInManager)
		{
			this.signInManager = signInManager;
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> OnPostAsync()
        {
			await signInManager.SignOutAsync();

			HttpContext.Session.Remove("User");
			return RedirectToPage("/Index");
        }
    }
}
