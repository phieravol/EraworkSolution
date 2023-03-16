using AppModules.Posts.Public;
using Microsoft.AspNetCore.Mvc;
using ViewModels.PostViewModel;

namespace Erawork.Pages.Shared.Components.ProviderIndexComponent
{
	public class ProviderIndexComponent : ViewComponent
	{
		private readonly IPublicPost publicPost;

		public ProviderIndexComponent(IPublicPost publicPost)
		{
			this.publicPost = publicPost;
		}

		public List<PostVM> NewPosts { get; set; }

		public async Task<IViewComponentResult> InvokeAsync()
		{
			NewPosts = await publicPost.GetNewPostAsync();
			return View("ProviderIndexComponent", NewPosts);
		}
	}
}
