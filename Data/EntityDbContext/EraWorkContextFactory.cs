using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
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
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("EraWorkDb");
            var optionBuilder = new DbContextOptionsBuilder<EraWorkContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new EraWorkContext(optionBuilder.Options);
        }
    }
}
