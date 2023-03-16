using AppModules.Services.Public;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using ViewModels.ServiceViewModel;

namespace Erawork.Pages.Shared.Components.ClientIndexComponent
{
    public class ClientIndexComponent:ViewComponent
    {
        private readonly IPublicServices publicServices;

        public ClientIndexComponent(IPublicServices publicServices)
        {
            this.publicServices = publicServices;
        }

        public List<ServicesVM> TopRateServices { get; set; }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            TopRateServices = await publicServices.getTopRateService();
            return View("ClientIndexComponent", TopRateServices);
        }

    }
}
