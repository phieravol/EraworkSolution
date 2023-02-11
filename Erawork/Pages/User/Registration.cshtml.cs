using Data.EntityDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewModels.User;

namespace Erawork.Pages.User
{
    public class RegistrationModel : PageModel
    {
        // creating a private prop dbcontext
        private readonly EraWorkContext _context;

        // generating constructor
        public RegistrationModel(EraWorkContext context)
        {
            _context = context;
        }

        //create data transfer object for register request
        [BindProperty]
        public RegisterRequest registerRequest { get; set; }
        

        public void OnPostAsync()
        {

        }
    }
}
