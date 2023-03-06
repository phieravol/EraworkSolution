using AppModules.Pakages.Provider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewModels.PakageViewModel.Provider;

namespace Erawork.Pages.Pakages.Provider
{
    public class CreateModel : PageModel
    {

        private readonly IManagePakages managePakages;

        public CreateModel(IManagePakages managePakages)
        {
            this.managePakages = managePakages;
        }

        [BindProperty] public PakageCreateRequest createRequest { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

			await managePakages.CreatePakageAsync(createRequest);

			return RedirectToPage("./Index");
        }
    }
}
