using System;
using System.Collections.Generic;
using System.Linq;
using HCI_big_project.model;
using HCI_big_project.repository;

namespace HCI_big_project.service
{
    public class AttractionService
    {
        private readonly AttractionRepository _attractionRepository;

        public AttractionService(AttractionRepository attractionRepository)
        {
            _attractionRepository = attractionRepository;
        }

        public void AddNewAttraction(Attraction attraction)
        {
            if (attraction == null) throw new ArgumentNullException(nameof(attraction));
            var attractions = _attractionRepository.GetAllAttractions();
            attractions.Add(attraction);
            _attractionRepository.SaveAll();
        }

        public Attraction FindById(int id)
        {
            return _attractionRepository.GetAllAttractions().FirstOrDefault(res => res.Id == id);
        }

        public int MakeNewId()
        {
            return _attractionRepository.GetAllAttractions().Last().Id + 1;
        }

        public void DeleteAttractionById(int attractionId)
        {
            List<Attraction> attractions = _attractionRepository.GetAllAttractions();
            Attraction attractionToDelete = attractions.FirstOrDefault(res => res.Id == attractionId);
            if (attractionToDelete != null)
            {
                attractions.Remove(attractionToDelete);
            }
            _attractionRepository.SaveAll();
        }

        public void DeleteAttractionWithObject(Attraction attraction)
        {
            if (attraction == null) throw new ArgumentNullException(nameof(attraction));
            List<Attraction> attractions = _attractionRepository.GetAllAttractions();
            Attraction attractionToDelete = attractions.FirstOrDefault(res => res.Id == attraction.Id);
            if (attractionToDelete != null)
            {
                attractions.Remove(attractionToDelete);
            }
            _attractionRepository.SaveAll();
        }

        public void UpdateAttraction(Attraction newAttraction)
        {
            if (newAttraction == null) throw new ArgumentNullException(nameof(newAttraction));
            List<Attraction> attractions = _attractionRepository.GetAllAttractions();
            Attraction attractionToUpdate = attractions.FirstOrDefault(res => res.Id == newAttraction.Id);
            if (attractionToUpdate != null)
            {
                int index = attractions.IndexOf(attractionToUpdate);
                attractions[index] = newAttraction;
                _attractionRepository.SaveAll();
            }
        }
    }
}