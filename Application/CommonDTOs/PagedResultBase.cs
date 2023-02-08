using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModules.GeneralDTOs
{
    public class PagedResultBase<T>
    {
        public List<T> Items { get; set; }
        public int TotalRecords { get; set; }
    }
}
