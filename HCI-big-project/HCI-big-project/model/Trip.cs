using System;
using System.Collections.Generic;

namespace HCI_big_project.model
{
    public class Trip
    {
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

        public Trip(string name, Location beginning, Location end, DateTime form, DateTime to, string caption, double price, List<Attraction> attractions, List<Accommodation> accommodations, List<Restaurant> restaurants,State state)
        {
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
        
        
    }
}