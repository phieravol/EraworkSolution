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
		Task<int> CountTotalRecord(ServiceFilterRequest pagingRequest);
        Task<List<ServicesVM>> GetPublicServicesAsync(ServiceFilterRequest pagingRequest);
        Task<List<ServicesVM>> GetServiceBySubcateAsync(int subCateId);
        Task<ServicesVM> GetServiceDetailAsync(int detailId);
        Task<List<ServicesVM>> getTopRateService();
    }
}
