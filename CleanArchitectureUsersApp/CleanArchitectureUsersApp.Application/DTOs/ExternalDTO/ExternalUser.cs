namespace CleanArchitectureUsersApp.Application.DTOs.ExternalDTO
{
    public class ExternalUser
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public double GeoLat { get; set; }
        public double GeoLng { get; set; }
        public string? Website { get; set; }
    }
}
