using AppModules.CommonDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModules.Categories.DTOs
{
    public class CategoryPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }
    }
}
