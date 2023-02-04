using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityDbContext
{
    public class EraWorkContextFactory : IDesignTimeDbContextFactory<EraWorkContext>
    {
        public EraWorkContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<EraWorkContext>();
            var connectionString = configuration.GetConnectionString("EraWorkDb");
            optionsBuilder.UseSqlServer(connectionString);
            return new EraWorkContext(optionsBuilder.Options);
        }
    }
}
