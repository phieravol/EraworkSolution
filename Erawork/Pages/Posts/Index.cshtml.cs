using AppModules.Categories.Manage;
using AppModules.Categories.Public;
using AppModules.Posts.Admin;
using AppModules.Posts.Public;
using AppModules.Services.Admin;
using AppModules.SubCategories.Admin;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ViewModels.PostViewModel;
using ViewModels.PostViewModel.Public;

namespace Erawork.Pages.Posts
{
	public class IndexModel : PageModel
	{
		private readonly IPublicPost publicPost;
		private readonly IPublicCategory publicCategory;

		public IndexModel(IPublicPost publicPost, IPublicCategory publicCategory)
		{
			this.publicPost = publicPost;
			this.publicCategory = publicCategory;
		}

		public List<Category> Categories { get; set; }
		public List<PostVM>? PostList { get; set; }
		[BindProperty (SupportsGet = true)] public PublicPostPagingRequest pagingRequest { get; set; }
		public int CountPosts { get; set; }
		public int TotalPages { get; set; }
		public bool HasPreviousPage
		{
			get
			{
				return (pagingRequest.CurrentPage > 1);
			}
		}

		public bool HasNextPage
		{
			get
			{
				return (pagingRequest.CurrentPage < TotalPages);
			}
		}

		public async Task<IActionResult> OnGetAsync()
		{
			Categories = await publicCategory.GetActiveCategoriesAsync();
			//get user session
			string? rawUser = HttpContext.Session.GetString("User");
			AppUser? user = null;
			if (rawUser != null)
			{
				user = JsonConvert.DeserializeObject<AppUser>(rawUser);
			}

			if (ModelState.IsValid)
			
			{
				PostList = await publicPost.GetPostFilterPaging(pagingRequest);
				TotalPages = (int)Math.Ceiling(PostList.Count() / (double)pagingRequest.PageSize);
			}
			return Page();
		}

	}
}
