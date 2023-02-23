using AppModules.Services.Admin;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Erawork.Pages.Services.Provider
{
    public class DeleteModel : PageModel
    {
        private readonly IManageServices manageServices;

        public DeleteModel(IManageServices manageServices)
        {
            this.manageServices = manageServices;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public Service service { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            service = await manageServices.GetServiceByIdAsync(Id);
            if (service == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await manageServices.DeleteServiceAsync(Id);
            return RedirectToPage("./Index");
        }
    }
}
