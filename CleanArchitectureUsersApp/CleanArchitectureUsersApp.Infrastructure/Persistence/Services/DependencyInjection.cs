using CleanArchitectureUsersApp.Application.Abstraction.Cashing;
using CleanArchitectureUsersApp.Application.Abstraction.External;
using CleanArchitectureUsersApp.Application.Abstraction.Persistence;
using CleanArchitectureUsersApp.Domain.Abstractions.Repositories;
using CleanArchitectureUsersApp.Domain.Abstractions.UnitOfWork;
using CleanArchitectureUsersApp.Infrastructure.Caching;
using CleanArchitectureUsersApp.Infrastructure.External;
using CleanArchitectureUsersApp.Infrastructure.Persistence.Database;
using CleanArchitectureUsersApp.Infrastructure.Persistence.Dapper;
using CleanArchitectureUsersApp.Infrastructure.Persistence.Repositories;
using CleanArchitectureUsersApp.Infrastructure.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureUsersApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            AddDatabase(services, configuration);
            AddRepositories(services);
            AddServices(services);
            return services;
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<UsersDb>(options =>
                options.UseNpgsql(configuration.GetConnectionString("UsersDb")));

            services.AddDbContext<CompaniesDb>(options =>
                options.UseNpgsql(configuration.GetConnectionString("CompaniesDb")));
        }

        private static void  AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
            services.AddScoped<ICompanyUnitOfWork, CompanyUnitOfWork>();

            services.AddScoped<IUsersReadRepository, UsersReadRepository>();
            services.AddScoped<ICompaniesReadRepository, CompaniesReadRepository>();

        }
            
        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IExternalService, ExternalService>();
            services.AddSingleton<ICacheService, MemoryCacheService>();
        }
    }
}
