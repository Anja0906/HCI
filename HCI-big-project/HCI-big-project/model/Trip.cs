using System;

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
        public Attraction[] Attractions { get; set; }
        public Accommodation[] Accommodations { get; set; }
        public Restaurant[] Restaurants { get; set; }
        
        public Trip(){}

        public Trip(string name, Location beginning, Location end, DateTime form, DateTime to, string caption, double price, Attraction[] attractions, Accommodation[] accommodations, Restaurant[] restaurants)
        {
            Name = name;
            Beginning = beginning;
            End = end;
            Form = form;
            To = to;
            Caption = caption;
            Price = price;
            Attractions = attractions;
            Accommodations = accommodations;
            Restaurants = restaurants;
        }
        
        
    }
}