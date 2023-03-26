using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ServiceViewModel.Admin
{
    public class ServicePagingRequest : PagingRequestBase
    {
        public string? searchTerm { get; set; }

    }
}
