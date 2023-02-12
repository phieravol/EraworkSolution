using AppModules.Users.Public;
using Data.EntityDbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewModels.User;

namespace Erawork.Pages.User
{
    public class RegistrationModel : PageModel
    {
        // creating a private prop dbcontext
        private readonly EraWorkContext _context;
        private readonly IPublicUser _publicUser;

        // generating constructor
        public RegistrationModel(EraWorkContext context, IPublicUser publicUser)
        {
            _context = context;
            _publicUser = publicUser;
        }

        //create data transfer object for register request
        [BindProperty]
        public RegisterRequest registerRequest { get; set; }


        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");


            if (await _publicUser.Register(registerRequest))
            {
                return LocalRedirect(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
