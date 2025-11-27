using CleanArchitectureUsersApp.Domain.Entitis.Users;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureUsersApp.Infrastructure.Persistence.Database
{
    public class UsersDb : DbContext
    {
        public UsersDb(DbContextOptions<UsersDb> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsersDb).Assembly);

            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}
