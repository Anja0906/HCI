namespace HCI_big_project.model
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Address { get; set; }

        public Location(){}

        public Location(double latitude, double longitude, double address)
        {
            Latitude = latitude;
            Longitude = longitude;
            Address = address;
        }
    }
}