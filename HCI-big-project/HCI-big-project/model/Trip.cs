using System;
using System.Collections.Generic;

namespace HCI_big_project.model
{
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Beginning { get; set; }
        public Location End { get; set; }
        public DateTime Form { get; set; }
        public DateTime To { get; set; }
        public string Caption { get; set; }
        public double Price { get; set; }
        public List<Attraction> Attractions { get; set; }
        public List<Accommodation> Accommodations { get; set; }
        public List<Restaurant> Restaurants { get; set; }
        public State State;
        
        public Trip(){}

        public Trip(int id,string name, Location beginning, Location end, DateTime form, DateTime to, string caption, double price, List<Attraction> attractions, List<Accommodation> accommodations, List<Restaurant> restaurants,State state)
        {
            Id              = id;
            Name            = name;
            Beginning       = beginning;
            End             = end;
            Form            = form;
            To              = to;
            Caption         = caption;
            Price           = price;
            Attractions     = attractions;
            Accommodations  = accommodations;
            Restaurants     = restaurants;
            State           = state;
        }
        public override string ToString()
        {
            string attractionsString = string.Join("\n", Attractions);
            string accommodationsString = string.Join("\n", Accommodations);
            string restaurantsString = string.Join("\n", Restaurants);

            return $"Trip ID: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Beginning: {Beginning}\n" +
                   $"End: {End}\n" +
                   $"Form: {Form}\n" +
                   $"To: {To}\n" +
                   $"Caption: {Caption}\n" +
                   $"Price: {Price}\n" +
                   $"Attractions:\n{attractionsString}\n" +
                   $"Accommodations:\n{accommodationsString}\n" +
                   $"Restaurants:\n{restaurantsString}\n" +
                   $"State: {State}";
        }
    }
}