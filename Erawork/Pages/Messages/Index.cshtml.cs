using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Erawork.Pages.Messages
{
    public class IndexModel : PageModel
    {
        public List<string> myConnectedUsers { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }
    }
}
