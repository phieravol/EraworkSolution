using AppModules.Posts.Admin;
using AppModules.Posts.Public;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Erawork.Pages.Posts
{
    public class DetailsModel : PageModel
    {
		private readonly IPublicPost puclicPost;
		private readonly IManagePosts managePosts;

		public DetailsModel(IPublicPost puclicPost, IManagePosts managePosts)
		{
			this.puclicPost = puclicPost;
			this.managePosts = managePosts;
		}

		[BindProperty(SupportsGet = true)] public int? Id { get; set; }
		[BindProperty] public Post currentPost { get; set; }

		public async Task<IActionResult> OnGetAsync()
		{
			currentPost = await managePosts.GetPostByIdAsync(Id);
			if (currentPost == null)
			{
				return NotFound();
			}
			return Page();
		}
	}
}
