using System;

namespace HCI_big_project.model
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        
        public Role Role { get; set; }

        public User() {}

        public User(string name, string surname, string email, string password, DateTime birthdate, Role role)
        {
            Name            = name;
            Surname         = surname;
            Email           = email;
            Password        = password;
            Birthdate       = birthdate;
            Role            = role;
        }
    }
}