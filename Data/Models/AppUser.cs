using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? UserStatus { get; set; }
        public string? UserLevel { get; set; }
        public string? UserDesc { get; set; }
        public string? UserLable { get; set; }
        public DateTime? MemberSince { get; set; }

        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<Post>? Posts { get; set; }
        public virtual ICollection<Service>? Services { get; set; }
        public virtual ICollection<OrderRequest>? OrderRequests { get; set; }
        public virtual ICollection<AppUserRole>? AppUserRoles { get; set; }
        
    }
}
