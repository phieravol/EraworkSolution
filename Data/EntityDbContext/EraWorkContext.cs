using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityDbContext
{
    public class EraWorkContext : DbContext
    {
        public EraWorkContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderRequest> OrderRequests { get; set; }
        public DbSet<Pakage> Pakages { get; set; }
        public DbSet<PakageDetail> PakageDetails { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

    }
}
