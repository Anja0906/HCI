using System;
using System.Collections.Generic;
using System.Linq;
using HCI_big_project.model;
using HCI_big_project.repository;

namespace HCI_big_project.service
{
    public class RestaurantService
    {
        private readonly RestaurantRepository _restaurantRepository;

        public RestaurantService(RestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public void AddNewRestaurant(Restaurant restaurant)
        {
            if (restaurant == null) throw new ArgumentNullException(nameof(restaurant));
            var restaurants = _restaurantRepository.GetAllRestaurants();
            restaurants.Add(restaurant);
            _restaurantRepository.SaveAll();
        }

        public int MakeNewId()
        {
            return _restaurantRepository.GetAllRestaurants()[_restaurantRepository.GetAllRestaurants().Count - 1].Id + 1;
        }

        public void DeleteTripById(int restaurantId)
        {
            List<Restaurant> restaurants = _restaurantRepository.GetAllRestaurants();
            Restaurant restaurantToDelete = restaurants.FirstOrDefault(res => res.Id == restaurantId);
            if (restaurantToDelete != null)
            {
                restaurants.Remove(restaurantToDelete);
            }
            _restaurantRepository.SaveAll();
        }

        public Restaurant FindById(int id)
        {
            return _restaurantRepository.GetAllRestaurants().FirstOrDefault(res => res.Id == id);
        }

        public void DeleteTripWithObject(Restaurant restaurant)
        {
            if (restaurant == null) throw new ArgumentNullException(nameof(restaurant));
            List<Restaurant> restaurants = _restaurantRepository.GetAllRestaurants();
            Restaurant restaurantToDelete = restaurants.FirstOrDefault(res => res.Id == restaurant.Id);
            if (restaurantToDelete != null)
            {
                restaurants.Remove(restaurantToDelete);
            }

            _restaurantRepository.SaveAll();
        }

        public void UpdateRestaurant(Restaurant newRestaurant)
        {
            if (newRestaurant == null) throw new ArgumentNullException(nameof(newRestaurant));
            List<Restaurant> restaurants = _restaurantRepository.GetAllRestaurants();
            Restaurant restaurantToUpdate = restaurants.FirstOrDefault(res => res.Id == newRestaurant.Id);
            if (restaurantToUpdate != null)
            {
                int index = restaurants.IndexOf(restaurantToUpdate);
                restaurants[index] = newRestaurant;
                _restaurantRepository.SaveAll();
            }
        }
    }
}