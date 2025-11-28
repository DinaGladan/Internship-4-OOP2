using CleanArchitectureUsersApp.Application.Abstraction.External;
using CleanArchitectureUsersApp.Application.DTOs.ExternalDTO;
using System.Text.Json;

namespace CleanArchitectureUsersApp.Infrastructure.External
{
    public class ExternalService : IExternalService
    {
        private const string Url = "https://jsonplaceholder.typicode.com/users";

        public async Task<List<ExternalUser>> GetExternalUsersAsync()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(Url);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ExternalUser>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<ExternalUser>();
        }
    }
}
