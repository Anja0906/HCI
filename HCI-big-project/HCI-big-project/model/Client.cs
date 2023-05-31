using System;
using System.Collections.Generic;

namespace HCI_big_project.model
{
    public class Client:User
    {
        public List<Trip> Trips { get; set; }

        public Client() {}

        public Client(List<Trip> trips)
        {
            Trips = trips;
        }

        public Client(string name, string surname, string email, string password, DateTime birthdate, Role role, List<Trip> trips) : base(name, surname, email, password, birthdate, role)
        {
            Trips = trips;
        }
        public override string ToString()
        {
            string tripsString = string.Join("\n", Trips);

            return $"Client Name: {Name}\n" +
                   $"Surname: {Surname}\n" +
                   $"Email: {Email}\n" +
                   $"Birthdate: {Birthdate}\n" +
                   $"Role: {Role}\n" +
                   $"Trips:\n{tripsString}";
        }
    }
}