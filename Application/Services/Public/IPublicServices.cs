using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ServiceViewModel;
using ViewModels.ServiceViewModel.Public;

namespace AppModules.Services.Public
{
	public interface IPublicServices
	{
		Task<List<ServicesVM>> GetPublicServicesAsync(ServiceFilterRequest pagingRequest);
	}
}
