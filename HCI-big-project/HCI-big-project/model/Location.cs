namespace HCI_big_project.model
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }

        public Location(){}

        public Location(double latitude, double longitude, string address)
        {
            Latitude    = latitude;
            Longitude   = longitude;
            Address     = address;
        }
    }
}