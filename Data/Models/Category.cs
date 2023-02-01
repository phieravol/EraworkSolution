using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public byte[]? CategoryImage { get; set; }
        public bool? CategoryStatus { get; set; }
        public string? CategoryDescription { get; set; }
    }
}
