using AppModules.Posts.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Erawork.Pages.Posts.Client
{
    public class DeleteModel : PageModel
    {
        private readonly IManagePosts managePost;

		public DeleteModel(IManagePosts managePost)
		{
			this.managePost = managePost;
		}

		[HttpPost]
		public async Task<IActionResult> OnPostAsync(int PostId)
        {
            if (ModelState.IsValid && PostId!=null)
            {
				await managePost.DeletePostAsync(PostId);
            }

			return RedirectToPage("./Index");
		}
    }
}
