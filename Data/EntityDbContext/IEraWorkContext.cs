using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.EntityDbContext
{
    public interface IEraWorkContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<OrderRequest> OrderRequests { get; set; }
        DbSet<PakageDetail> PakageDetails { get; set; }
        DbSet<Pakage> Pakages { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<SubCategory> SubCategories { get; set; }
    }
}