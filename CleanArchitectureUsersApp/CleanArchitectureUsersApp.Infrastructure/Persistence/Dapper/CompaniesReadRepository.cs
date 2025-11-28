using CleanArchitectureUsersApp.Application.Abstraction.Persistence;
using CleanArchitectureUsersApp.Application.DTOs.Responses;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace CleanArchitectureUsersApp.Infrastructure.Persistence.Dapper
{
    public class CompaniesReadRepository : ICompaniesReadRepository
    {
        private readonly string _connectionString;

        public CompaniesReadRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("CompaniesDb");
        }
        public async Task<IEnumerable<CompanyResponse>> GetAllAsync()
        {
            const string sql = @"
                SELECT 
                    id AS Id,
                    name AS CompanyName
                FROM companies
            ";

            await using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryAsync<CompanyResponse>(sql);
        }
        public async Task<CompanyResponse?> GetByIdAsync(int id)
        {
            const string sql = @"
                SELECT 
                    id AS Is,
                    name AS CompanyName
                FROM companies
                WHERE id = @Id
            ";

            await using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<CompanyResponse>(sql, new { Id = id });
        }
    }
}
