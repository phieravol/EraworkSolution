using AppModules.GeneralModule;
using AppModules.Services.Admin;
using AppModules.SubCategories.Admin;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ViewModels.ServiceViewModel.Admin;
using ViewModels.SubCatesViewModel.Admin;

namespace Erawork.Pages.Services.Provider
{
    public class UpdateModel : PageModel
    {
        private readonly IManageServices manageServices;
        private readonly IManageSubcates manageSubcates;
        private readonly ISaveImage ImageSaver;

        public UpdateModel(IManageServices manageServices, ISaveImage saveImage, IManageSubcates manageSubcates)
        {
            this.manageServices = manageServices;
            this.ImageSaver = saveImage;
            this.manageSubcates = manageSubcates;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public ServiceUpdateRequest UpdateRequest { get; set; }

        [BindProperty]
        public IFormFile? Image { get; set; }

        public Service? currentService { get; set; }
        public List<SubCategory>? subCates { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            currentService = await manageServices.GetServiceByIdAsync(Id);
            subCates = await manageSubcates.GetSubCatesAsync();
            if (currentService == null)
            {
                return NotFound();
            }

            UpdateRequest = new ServiceUpdateRequest()
            {
                ServiceId = currentService.ServiceId,
                ServiceTitle = currentService.ServiceTitle,
                ServiceIntro = currentService.ServiceIntro,
                isServiceActive = currentService.isServiceActive,
                SubCategoryId = currentService.SubCategoryId,
                TotalClients = currentService.TotalClients,
                TotalStars = currentService.TotalStars,
                UserId = currentService.UserId
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string? rawUser = HttpContext.Session.GetString("User");
            AppUser? user = JsonConvert.DeserializeObject<AppUser>(rawUser);

            var currentService = await manageServices.GetServiceByIdAsync(Id);

            string folderPath = "assets/images/services";
            currentService.ServiceId = Id;
            currentService.ServiceTitle = UpdateRequest.ServiceTitle;
            currentService.ServiceIntro = UpdateRequest.ServiceIntro;
            currentService.ServiceImage = await ImageSaver.SaveImageAsync(UpdateRequest.ServiceImage, folderPath);
            currentService.SubCategoryId = UpdateRequest.SubCategoryId;
            currentService.TotalStars = UpdateRequest.TotalStars;
            currentService.TotalClients = UpdateRequest.TotalClients;
            currentService.UserId = user.Id;

            await manageServices.UpdateServiceAsync(currentService);

            return RedirectToPage("./Index");
        }
    }
}
