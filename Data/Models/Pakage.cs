using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Pakage
    {
        public int PakageId { get; set; }
        public string? PakageName { get; set; }
        public decimal? Price { get; set; }
        public string? RevisionLimit { get; set; }
        public int? DeliveryDays { get; set; }
        public bool? PakageStatus { get; set; }
        public int? ServiceId { get; set; }
    }
}
