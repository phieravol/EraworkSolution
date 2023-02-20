using AppModules.Categories.Manage;
using AppModules.Categories.Public;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Erawork.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IManageCategory _manageCategory;
        private readonly IPublicCategory _publicCategory;

		public IndexModel(ILogger<IndexModel> logger, IManageCategory manageCategory, IPublicCategory publicCategory)
		{
			_manageCategory = manageCategory;
			_logger = logger;
            _publicCategory = publicCategory;
		}

        public List<Category> Categories { get; set; }
        public async Task OnGetAsync()
        {
            Categories = await _publicCategory.GetActiveCategoriesAsync();
        }
    }
}