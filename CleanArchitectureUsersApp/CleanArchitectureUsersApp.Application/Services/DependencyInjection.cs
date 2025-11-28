using CleanArchitectureUsersApp.Application.Features.Companies.Commands.CreateCompany;
using CleanArchitectureUsersApp.Application.Features.Companies.Commands.DeleteCompany;
using CleanArchitectureUsersApp.Application.Features.Companies.Commands.UpdateCompany;
using CleanArchitectureUsersApp.Application.Features.Companies.Queries.GetCompanies;
using CleanArchitectureUsersApp.Application.Features.Companies.Queries.GetCompanyById;
using CleanArchitectureUsersApp.Application.Features.Users.Commands.ActiveUser;
using CleanArchitectureUsersApp.Application.Features.Users.Commands.CreateUser;
using CleanArchitectureUsersApp.Application.Features.Users.Commands.DeactiveUser;
using CleanArchitectureUsersApp.Application.Features.Users.Commands.DeleteUser;
using CleanArchitectureUsersApp.Application.Features.Users.Commands.GetExternalUser;
using CleanArchitectureUsersApp.Application.Features.Users.Commands.UpdateUser;
using CleanArchitectureUsersApp.Application.Features.Users.Queries.GetUserById;
using CleanArchitectureUsersApp.Application.Features.Users.Queries.GetUsers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace CleanArchitectureUsersApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<CreateUserCommandHandler>();
            services.AddScoped<UpdateUserCommandHandler>();
            services.AddScoped<DeleteUserCommandHandler>();
            services.AddScoped<ActiveUserCommandHandler>();
            services.AddScoped<DeactiveUserCommandHandler>();
            services.AddScoped<GetExternalUserCommandHandler>();

            services.AddScoped<GetUsersQueryHandler>();
            services.AddScoped<GetUserByIdQueryHandler>();
            services.AddScoped<CreateCompanyCommandHelper>();
            services.AddScoped<UpdateCompanyCommandHandler>();
            services.AddScoped<DeleteCompanyCommandHandler>();

            services.AddScoped<GetCompaniesQueryHandler>();
            services.AddScoped<GetCompanyByIdQueryHandler>();

            return services;
        }
    }
}
