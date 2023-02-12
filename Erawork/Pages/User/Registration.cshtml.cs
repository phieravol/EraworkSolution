using AppModules.System.Role;
using AppModules.Users.Public;
using Data.EntityDbContext;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ViewModels.User;

namespace Erawork.Pages.User
{
    public class RegistrationModel : PageModel
    {
        // creating a private prop dbcontext
        private readonly EraWorkContext _context;
        private readonly IPublicUser _publicUser;
        private readonly IPublicRole _publicRole;

        // generating constructor
        public RegistrationModel(EraWorkContext context, IPublicUser publicUser, IPublicRole publicRole)
        {
            _context = context;
            _publicUser = publicUser;
            _publicRole = publicRole;
        }

        //create data transfer object for register request
        [BindProperty]
        public RegisterRequest registerRequest { get; set; }
        public List<AppRole> roles { get; set; }
        
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            Console.WriteLine($"Log name: {registerRequest.RoleName}");
            returnUrl = returnUrl ?? Url.Content("~/");
            if (await _publicUser.Register(registerRequest))
            {
                return LocalRedirect(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        public async Task OnGetAsync()
        {
            roles = _publicRole.listRoles();
        }
    }
}
