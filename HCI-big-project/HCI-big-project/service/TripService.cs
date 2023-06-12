using System;
using System.Collections.Generic;
using System.Linq;
using HCI_big_project.model;
using HCI_big_project.repository;
using Microsoft.Ajax.Utilities;

namespace HCI_big_project.service
{
    public class TripService
    {
        private readonly TripRepository _tripRepository;

        public TripService(TripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public void AddNewTrip(Trip trip)
        {
            if (trip == null) throw new ArgumentNullException("Putovanje nije kreirano!");
            var trips = _tripRepository.GetAllTrips();
            trips.Add(trip);
            _tripRepository.SaveAll();
        }

        public int MakeNewId()
        {
            return _tripRepository.GetAllTrips().Last().Id + 1;
        }

        public List<Trip> GetReservedTrips()
        {
            return _tripRepository.GetAllTrips().Where(trip => trip.State == State.Rezervisan).ToList();
        }

        public List<Trip> GetPurchasedTrips()
        {
            return _tripRepository.GetAllTrips().Where(trip => trip.State == State.Kupljen).ToList();
        }

        public List<Trip> GetOfferedTrips()
        {
            return _tripRepository.GetAllTrips().Where(trip => trip.State == State.Ponuda).ToList();
        }

        public List<Trip> GetPurchasedAndReservedTrips()
        {
            return _tripRepository.GetAllTrips().Where(trip => trip.State == State.Kupljen || trip.State == State.Rezervisan).ToList();
        }

        public Dictionary<string, int> MakeDictionary(List<Trip> trips)
        {
            Dictionary<string, int> purchasedByTrip = new Dictionary<string, int>();
            foreach (Trip trip in trips)
            {
                Console.WriteLine(trip.Name);
                if (purchasedByTrip.Keys.Contains(trip.Name))
                {
                    purchasedByTrip[trip.Name] += 1;
                }
                else
                {
                    purchasedByTrip[trip.Name] = 1;
                }
            }

            return purchasedByTrip;
        }

        public List<Trip> GetPurchasedTripsForSpecificTrip(string tripName)
        {
            return _tripRepository.GetAllTrips().Where(trip => trip.State == State.Kupljen && trip.Name.ToLower().Trim() == tripName.ToLower().Trim()).ToList();
        }

        public void DeleteTripById(int tripId)
        {
            List<Trip> trips = _tripRepository.GetAllTrips();
            Trip tripToDelete = trips.FirstOrDefault(trip => trip.Id == tripId);
            if (tripToDelete != null)
            {
                trips.Remove(tripToDelete);
            }
            _tripRepository.SaveAll();
        }

        public void DeleteTripWithObject(Trip t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));
            List<Trip> trips = _tripRepository.GetAllTrips();
            Trip tripToDelete = trips.FirstOrDefault(trip => trip.Id == t.Id);
            if (tripToDelete != null)
            {
                trips.Remove(tripToDelete);
            }
            _tripRepository.SaveAll();
        }

        public void UpdateTrip(Trip newTrip)
        {
            if (newTrip == null) throw new ArgumentNullException(nameof(newTrip));
            List<Trip> trips = _tripRepository.GetAllTrips();
            Trip tripToUpdate = trips.FirstOrDefault(trip => trip.Id == newTrip.Id);
            if (tripToUpdate != null)
            {
                int index = trips.IndexOf(tripToUpdate);
                trips[index] = newTrip;
                _tripRepository.SaveAll();
            }
        }

        public List<Trip> GetTripsForMonth(DateTime dateTime)
        {
            return _tripRepository.GetAllTrips().Where(trip =>
                trip.Form.Year == dateTime.Year && trip.Form.Month == dateTime.Month).ToList();
        }

        public void DeleteAttraction(int attractionId)
        {
            List<Trip> trips = _tripRepository.GetAllTrips();
            foreach (var trip in trips)
            {
                Attraction attraction = trip.Attractions.Find(a => a.Id == attractionId);
                if (attraction != null)
                {
                    trip.Attractions.Remove(attraction);
                }
            }
            _tripRepository.SaveAll();
        }

        public void UpdateAttraction(Attraction updatedAttraction)
        {
            if (updatedAttraction == null) throw new ArgumentNullException(nameof(updatedAttraction));
            List<Trip> trips = _tripRepository.GetAllTrips();
            foreach (var trip in trips)
            {
                Attraction attractionToUpdate = trip.Attractions.Find(a => a.Id == updatedAttraction.Id);
                if (attractionToUpdate != null)
                {
                    int index = trip.Attractions.IndexOf(attractionToUpdate);
                    trip.Attractions[index] = updatedAttraction;
                }
            }
            _tripRepository.SaveAll();
        }

        public void DeleteAccommodation(int accommodationId)
        {
            List<Trip> trips = _tripRepository.GetAllTrips();
            foreach (var trip in trips)
            {
                Accommodation accommodation = trip.Accommodations.Find(a => a.Id == accommodationId);
                if (accommodation != null)
                {
                    trip.Accommodations.Remove(accommodation);
                }
            }
            _tripRepository.SaveAll();
        }

        public void UpdateAccommodation(Accommodation updatedAccommodation)
        {
            if (updatedAccommodation == null) throw new ArgumentNullException(nameof(updatedAccommodation));
            List<Trip> trips = _tripRepository.GetAllTrips();
            foreach (var trip in trips)
            {
                Accommodation accommodationToUpdate = trip.Accommodations.Find(a => a.Id == updatedAccommodation.Id);
                if (accommodationToUpdate != null)
                {
                    int index = trip.Accommodations.IndexOf(accommodationToUpdate);
                    trip.Accommodations[index] = updatedAccommodation;
                }
            }
            _tripRepository.SaveAll();
        }
    }
}