using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace UCI.Project.Infraestructure.Data.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {

        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
#if DEBUG
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
#endif
            optionsBuilder.UseSqlServer(args.Length > 0 ? args[0] : "server=.;database=project_Db;trusted_connection=true;");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
