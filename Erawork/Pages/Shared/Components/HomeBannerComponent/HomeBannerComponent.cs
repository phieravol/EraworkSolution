using AppModules.Services.Public;
using Microsoft.AspNetCore.Mvc;

namespace Erawork.Pages.Shared.Components.HomeBannerComponent
{
	public class HomeBannerComponent : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			string Title = "Home Page";
			return View("HomeBannerComponent", Title);
		}
	}
}
