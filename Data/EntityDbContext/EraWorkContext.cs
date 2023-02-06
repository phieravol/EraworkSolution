using Data.Confiuration;
using Data.DataSample;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityDbContext
{
    public class EraWorkContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public EraWorkContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderRequestConfiguration());
            modelBuilder.ApplyConfiguration(new PakageConfiguration());
            modelBuilder.ApplyConfiguration(new PakageDetailConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());

            //add modelbuilder for identity table
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaim").HasKey(x=>x.UserId);
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRole").HasKey(x => new {x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogin").HasKey(x=>x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaim");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserToken").HasKey(x=>x.UserId);

            modelBuilder.Seed();
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
