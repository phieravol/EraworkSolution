using AppModules.Categories.Public;
using AppModules.SubCategories.Public;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Erawork.Pages.Shared.Components.PublicCategories
{
    public class CategoriesMenuComponent : ViewComponent
    {
        private readonly IPublicCategory publicCate;
        private readonly IPublicSubcate publicSubCate;
        

        public CategoriesMenuComponent(IPublicCategory publicCate)
        {
            this.publicCate = publicCate;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> ActiveCates = await publicCate.GetActiveCategoriesAsync();
            
            return View("CategoriesMenuComponent", ActiveCates);
        }
    }
}
