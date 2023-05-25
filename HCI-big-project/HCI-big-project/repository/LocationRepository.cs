using System.Collections.Generic;
using System.Linq;
using HCI_big_project.model;
using HCI_big_project.utils;

namespace HCI_big_project.Repository
{
    public class LocationRepository
    {
        private const string FilePath = "../../files/locations.json";
        private List<Location> Locations { get; set; }

        public LocationRepository()
        {
            Locations = ListHandler.ReadList<Location>(FilePath);
        }

        public void AddLocation(Location location)
        {
            Locations.Add(location);
        }

        public void DeleteLocation(Location location)
        {
            Locations.Remove(location);
        }

        public List<Location> GetAllLocations()
        {
            return Locations;
        }

        public Location FindLocationByAddress(string address)
        {
            return Locations.FirstOrDefault(location => location.Address.Equals(address));
        }

        public void SaveAll()
        {
            ListHandler.WriteList(Locations, FilePath);
        }
    }
}
