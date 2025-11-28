using CleanArchitectureUsersApp.Domain.Entitis;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureUsersApp.Infrastructure.Persistence.Database
{
    public class CompaniesDb : DbContext
    {
        public CompaniesDb(DbContextOptions<CompaniesDb> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompaniesDb).Assembly);

            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}

