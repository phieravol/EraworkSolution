using AppModules.Categories.Public;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Erawork.Pages.Shared.Components.PublicCategories
{
    public class CategoriesMenuComponent : ViewComponent
    {
        private readonly IPublicCategory _publicCate;

        public CategoriesMenuComponent(IPublicCategory publicCate)
        {
            _publicCate = publicCate;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> ActiveCates = await _publicCate.GetActiveCategoriesAsync();
            
            return View("CategoriesMenuComponent", ActiveCates);
        }
    }
}
