using System.Collections.Generic;
using System.Linq;
using HCI_big_project.model;
using HCI_big_project.utils;

namespace HCI_big_project.Repository
{
    public class RestaurantRepository
    {
        private const string FilePath = "../../files/restaurants.json";
        private List<Restaurant> Restaurants { get; set; }

        public RestaurantRepository()
        {
            Restaurants = ListHandler.ReadList<Restaurant>(FilePath);
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            Restaurants.Add(restaurant);
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            Restaurants.Remove(restaurant);
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return Restaurants;
        }

        public Restaurant FindRestaurantByName(string name)
        {
            return Restaurants.FirstOrDefault(restaurant => restaurant.Name.Equals(name));
        }

        public void SaveAll()
        {
            ListHandler.WriteList(Restaurants, FilePath);
        }
    }
}
