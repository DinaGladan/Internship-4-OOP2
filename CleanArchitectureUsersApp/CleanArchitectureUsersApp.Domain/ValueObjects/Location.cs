namespace CleanArchitectureUsersApp.Domain.ValueObjects
{
    public class Location
    {
        public const double EarthRadiusKm = 6371.0;
        public double geoLat { get; set; }
        public double geoLng { get; set; }
        public bool IsValidLat() => geoLat >= -90 && geoLat <= 90;
        public bool IsValidLng() => geoLng >= -180 && geoLng <= 180;
        public double Distance(Location other) 
        {
            double radiansOverDegrees = (Math.PI / 180.0);

            double geoLatRadians = (double)geoLat * radiansOverDegrees;
            double geoLngRadians = (double)geoLng * radiansOverDegrees;
            double geoLatRadiansOther = (double)other.geoLat * radiansOverDegrees;
            double geoLngRadiansOther = (double)other.geoLng * radiansOverDegrees;


            double resultLat = geoLatRadians - geoLatRadiansOther;
            double resultLng = geoLngRadians - geoLngRadiansOther;

            double result1 = Math.Sin(resultLat / 2) * Math.Sin(resultLat/2) +
                          Math.Cos(geoLatRadians) * Math.Cos(geoLatRadiansOther) *
                          Math.Sin(resultLng / 2) * Math.Sin(resultLng/2);

            double result2 =EarthRadiusKm * (2 * Math.Atan2(Math.Sqrt(result1), Math.Sqrt(1.0 - result1)));
            return result2;

        }

    }
}
