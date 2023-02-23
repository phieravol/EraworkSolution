using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.SubCatesViewModel.Admin;
using ViewModels.SubCatesViewModel;
using ViewModels.ServiceViewModel.Admin;
using ViewModels.ServiceViewModel;
using Data.Models;
using Microsoft.AspNetCore.Http;

namespace AppModules.Services.Admin
{
	public interface IManageServices
	{
		Task<List<ServicesVM>> PagingServicesAsync(ServicePagingRequest request, string UserName);
		Task CreateServiceAsync(ServicesCreateRequest request, AppUser UserName);
		Task<string> SaveServiceImage(IFormFile? serviceI);
		Task<Service>? GetServiceByIdAsync(int Id);
		Task UpdateServiceAsync(Service newService);
		Task DeleteServiceAsync(int Id);

	}
}
