using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class PakageDetail
    {
        public int? PakageDetailId { get; set; }
        public string? PakageDetailDesc { get; set; }
        public bool? IsDetailActive { get; set; }
        public int? PakageId { get; set; }

        public virtual Pakage? Pakage { get; set; }

    }
}
