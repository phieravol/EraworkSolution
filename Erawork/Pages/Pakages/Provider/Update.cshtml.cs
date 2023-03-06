using AppModules.Pakages.Provider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ViewModels.PakageViewModel.Provider;

namespace Erawork.Pages.Pakages.Provider
{
    public class UpdateModel : PageModel
    {
        private readonly IManagePakages managePakages;

		public UpdateModel(IManagePakages managePakages)
		{
			this.managePakages = managePakages;
		}

		[BindProperty] public PakageUpdateRequest updateRequest { get; set; }
		public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

		public async Task<IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid)
			{
				await managePakages.UpdatePakage(updateRequest);
			}
			return RedirectToPage("./Index");
		}

	}
}
