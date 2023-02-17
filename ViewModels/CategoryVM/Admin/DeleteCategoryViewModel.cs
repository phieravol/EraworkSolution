using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.CategoryVM.Admin
{
    public class DeleteCategoryViewModel
    {
        public int Id { get; set; }
        public Category Category { get; set; }
    }
}
