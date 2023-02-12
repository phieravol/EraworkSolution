using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class AppUserToken
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}
