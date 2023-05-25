using System.Collections.Generic;
using HCI_big_project.model;
using HCI_big_project.utils;

namespace HCI_big_project.repository
{
    public class AttractionRepository
    {
        private const string FilePath = "../../files/attractions.json";
        private List<Attraction> Attractions { get; set; }

        public AttractionRepository()
        {
            Attractions = ListHandler.ReadList<Attraction>(FilePath);
        }

        public void AddAttraction(Attraction attraction)
        {
            Attractions.Add(attraction);
        }

        public void DeleteAttraction(Attraction attraction)
        {
            Attractions.Remove(attraction);
        }

        public List<Attraction> GetAllAttractions()
        {
            return Attractions;
        }

        public Attraction FindAttractionByName(string name)
        {
            foreach (Attraction Attraction in Attractions)
            {
                if (Attraction.Name.Equals(name))
                {
                    return Attraction;
                }
            }

            return null;
        }

        public void SaveAll()
        {
            ListHandler.WriteList(Attractions, FilePath);
        }

    }
}