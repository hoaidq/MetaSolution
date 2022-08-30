using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MetaSolution.Data.EF
{
    public class MetaDbContextFactory : IDesignTimeDbContextFactory<MetaDbContext>
    {
        public MetaDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("MetaSolutionDatabase");

            var optionBuilder = new DbContextOptionsBuilder<MetaDbContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new MetaDbContext(optionBuilder.Options);
        }
    }
}
