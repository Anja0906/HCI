using HCI_big_project.repository;
using HCI_big_project.model;
using System;
using System.Collections.Generic;
using System.Linq;
namespace HCI_big_project.service
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Login(string email, string password)
        {
            User user = _userRepository.GetAllUsers()
                .FirstOrDefault(usr => usr.Email == email && usr.Password == password);

            if (user == null) throw new NullReferenceException("Uneti korisnik ne postoji u sistemu!");
            return user;
        }

    }
}