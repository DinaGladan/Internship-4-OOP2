using CleanArchitectureUsersApp.Application.Abstraction.Persistence;
using CleanArchitectureUsersApp.Application.DTOs.Responses;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace CleanArchitectureUsersApp.Infrastructure.Persistence.Dapper
{
    public class UsersReadRepository : IUsersReadRepository
    {
        private readonly string _connectionString;
        public UsersReadRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("UsersDb");
        }

        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            const string sql = @"
                SELECT 
                    id,
                    name,
                    username,
                    email,
                    address_street AS AddressStreet,
                    city AS AddressCity,
                    GeoLat,
                    GeoLng,
                    website,
                    active AS IsActive
                FROM users
            ";

            await using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryAsync<UserResponse>(sql);
        }
        public async Task<UserResponse?> GetByIdAsync(int id)
        {
            const string sql = @"
                SELECT 
                    id,
                    name,
                    username,
                    email,
                    address_street AS AddressStreet,
                    city AS AddressCity,
                    GeoLat,
                    GeoLng,
                    website,
                    active AS IsActive
                FROM users
                WHERE id = @Id
            ";

            await using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<UserResponse>(sql, new { Id = id });
        }
    }
}
