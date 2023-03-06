using AppModules.Pakages.Provider;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Erawork.Pages.Pakages.Provider
{
    public class DeleteModel : PageModel
    {
        private readonly IManagePakages managePakages;

		public DeleteModel(IManagePakages managePakages)
		{
			this.managePakages = managePakages;
		}

		[BindProperty(SupportsGet = true)] public int Pakage { get; set; }
		[BindProperty] public int Name { get; set; }
        [BindProperty] public Pakage DeletePackage { get; set; }

		public async Task<IActionResult> OnGetAsync()
        {
			if (string.IsNullOrEmpty(Pakage.ToString()))
			{
				HttpContext.Response.Clear();
				HttpContext.Response.StatusCode = 404;
				HttpContext.Response.Redirect("/Errors/Error404");
			}

			DeletePackage = await managePakages.GetPakageByIdAsync(Pakage);

			return Page();
        }

		public async Task<IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid)
			{
				await managePakages.DeletePagageAsync(DeletePackage.PakageId);
			}
			return RedirectToPage("./Index");
		}
	}
}
