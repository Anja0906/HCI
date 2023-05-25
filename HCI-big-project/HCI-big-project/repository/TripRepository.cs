using System.Collections.Generic;
using System.Linq;
using HCI_big_project.model;
using HCI_big_project.utils;

namespace HCI_big_project.Repository
{
    public class TripRepository
    {
        private const string FilePath = "../../files/trips.json";
        private List<Trip> Trips { get; set; }

        public TripRepository()
        {
            Trips = ListHandler.ReadList<Trip>(FilePath);
        }

        public void AddTrip(Trip trip)
        {
            Trips.Add(trip);
        }

        public void DeleteTrip(Trip trip)
        {
            Trips.Remove(trip);
        }

        public List<Trip> GetAllTrips()
        {
            return Trips;
        }

        public Trip FindTripByName(string name)
        {
            return Trips.FirstOrDefault(trip => trip.Name.Equals(name));
        }

        public void SaveAll()
        {
            ListHandler.WriteList(Trips, FilePath);
        }
    }
}
