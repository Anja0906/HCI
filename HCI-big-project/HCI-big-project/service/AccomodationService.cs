using System;
using System.Collections.Generic;
using System.Linq;
using HCI_big_project.model;
using HCI_big_project.repository;
using HCI_big_project.view;

namespace HCI_big_project.service
{
    public class AccomodationService
    {
        private readonly AccommodationRepository _accommodationRepository;

        public AccomodationService(AccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
        }

        public void AddNewAccommodation(Accommodation accommodation)
        {
            if (accommodation == null) throw new ArgumentNullException(nameof(accommodation));
            var accommodations = _accommodationRepository.GetAllAccommodations();
            accommodations.Add(accommodation);
            _accommodationRepository.SaveAll();
        }

        public Accommodation FindById(int id)
        {
            return _accommodationRepository.GetAllAccommodations().FirstOrDefault(res => res.Id == id);
        }
        
        public Accommodation FindByName(string name)
        {
            return _accommodationRepository.GetAllAccommodations().FirstOrDefault(res => res.Name == name);
        }

        public List<Accommodation> GetAll()
        {
            return _accommodationRepository.GetAllAccommodations();
        }

        public int MakeNewId()
        {
            return _accommodationRepository.GetAllAccommodations().Last().Id + 1;
        }

        public void DeleteAccommodationById(int accommodationId)
        {
            List<Accommodation> accommodations = _accommodationRepository.GetAllAccommodations();
            Accommodation accommodationToDelete = accommodations.FirstOrDefault(res => res.Id == accommodationId);
            if (accommodationToDelete != null)
            {
                accommodations.Remove(accommodationToDelete);
            }

            _accommodationRepository.SaveAll();
        }

        public void DeleteAccommodationWithObject(Accommodation accommodation)
        {
            if (accommodation == null) throw new ArgumentNullException(nameof(accommodation));
            List<Accommodation> accommodations = _accommodationRepository.GetAllAccommodations();
            Accommodation accommodationToDelete = accommodations.FirstOrDefault(res => res.Id == accommodation.Id);
            if (accommodationToDelete != null)
            {
                accommodations.Remove(accommodationToDelete);
            }

            _accommodationRepository.SaveAll();
        }

        public void UpdateAccommodation(Accommodation newAccommodation)
        {
            if (newAccommodation == null) throw new ArgumentNullException(nameof(newAccommodation));
            List<Accommodation> accommodations = _accommodationRepository.GetAllAccommodations();
            Accommodation accommodationToUpdate = accommodations.FirstOrDefault(res => res.Id == newAccommodation.Id);
            if (accommodationToUpdate != null)
            {
                int index = accommodations.IndexOf(accommodationToUpdate);
                accommodations[index] = newAccommodation;
                _accommodationRepository.SaveAll();
            }
        }
    }
}