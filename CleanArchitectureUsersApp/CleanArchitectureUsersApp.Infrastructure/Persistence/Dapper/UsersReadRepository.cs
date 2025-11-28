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
                    id AS Id,
                    name AS Name,
                    username AS Username,
                    email AS Email,
                    address_street AS AddressStreet,
                    address_city AS AddressCity,
                    geo_lat AS GeoLat,
                    geo_lng AS GeoLng,
                    website AS Website,
                    is_active AS IsActive
                FROM users
            ";

            await using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryAsync<UserResponse>(sql);
        }
        public async Task<UserResponse?> GetByIdAsync(int id)
        {
            const string sql = @"
                SELECT 
                    id AS Id,
                    name AS Name,
                    username AS Username,
                    email AS Email,
                    address_street AS AddressStreet,
                    address_city AS AddressCity,
                    geo_lat AS GeoLat,
                    geo_lng AS GeoLng,
                    website AS Website,
                    is_active AS IsActive
                FROM users
                WHERE id = @Id
            ";

            await using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<UserResponse>(sql, new { Id = id });
        }
    }
}
