using Data.Confiuration;
using Data.DataSample;
using Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
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
        public EraWorkContext(DbContextOptions<EraWorkContext> options) : base(options)
        {
        }

        public EraWorkContext(DbSet<Category> categories, DbSet<OrderRequest> orderRequests, DbSet<Pakage> pakages, DbSet<PakageDetail> pakageDetails, DbSet<Post> posts, DbSet<Review> reviews, DbSet<Service> services, DbSet<SubCategory> subCategories)
        {
            Categories = categories;
            OrderRequests = orderRequests;
            Pakages = pakages;
            PakageDetails = pakageDetails;
            Posts = posts;
            Reviews = reviews;
            Services = services;
            SubCategories = subCategories;
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
            
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserClaim<Guid>>().ToTable("AppUserClaim");
            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserRole<Guid>>().ToTable("AppUserRole").HasKey(x => new {x.UserId, x.RoleId});
            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserLogin<Guid>>().ToTable("AppUserLogin").HasKey(x=>x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaim").HasKey(x=>x.RoleId);

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
