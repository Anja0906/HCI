using System;

namespace HCI_big_project.model
{
    public class Client:User
    {
        public Trip[] Trips { get; set; }

        public Client() {}

        public Client(Trip[] trips)
        {
            Trips = trips;
        }

        public Client(string name, string surname, string email, string password, DateTime birthdate, Role role, Trip[] trips) : base(name, surname, email, password, birthdate, role)
        {
            Trips = trips;
        }
    }
}