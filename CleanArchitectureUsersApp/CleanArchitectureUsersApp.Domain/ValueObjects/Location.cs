namespace CleanArchitectureUsersApp.Domain.ValueObjects
{
    public class Location
    {
        public decimal geoLat { get; set; }
        public decimal geoLng { get; set; }
        public void Distance() { }
        public bool IsValidLat() => geoLat >= -90 && geoLat <= 90;
        public bool IsValidLng() => geoLng >= -180 && geoLng <= 180;
    }
}
