using System.Collections.Generic;
using HCI_big_project.model;
using HCI_big_project.utils;

namespace HCI_big_project.repository
{
    public class AccommodationRepository
    {
        private const string FilePath = "./accommodations.json";
        private List<Accommodation> Accommodations { get; set; }

        public AccommodationRepository()
        {
            Accommodations = ListHandler.ReadList<Accommodation>(FilePath);
        }

        public void AddAccommodation(Accommodation accommodation)
        {
            Accommodations.Add(accommodation);
        }
        
        public void DeleteAccommodation(Accommodation accommodation)
        {
            Accommodations.Remove(accommodation);
        }

        public List<Accommodation> GetAllAccommodations()
        {
            return Accommodations;
        }

        public Accommodation FindAccommodationByName(string name)
        {
            foreach (Accommodation accommodation in Accommodations)
            {
                if (accommodation.Name.Equals(name))
                {
                    return accommodation;
                }
            }

            return null;
        }

        public void SaveAll()
        {
            ListHandler.WriteList(Accommodations, FilePath);
        }
        
        

    }
}