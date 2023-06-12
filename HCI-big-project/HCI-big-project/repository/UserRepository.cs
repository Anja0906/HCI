using System.Collections.Generic;
using System.Linq;
using HCI_big_project.model;
using HCI_big_project.utils;


namespace HCI_big_project.repository
{
    public class UserRepository
    {
        private const string FilePath = "../../files/users.json";
        private List<User> Users { get; set; }

        public UserRepository()
        {
           Users = ListHandler.ReadList<User>(FilePath);
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            Users.Remove(user);
        }

        public List<User> GetAllUsers()
        {
            return Users;
        }

        public User FindUserByUsername(string email)
        {
            return Users.FirstOrDefault(user => user.Email.Equals(email));
        }

        public void SaveAll()
        {
            ListHandler.WriteList(Users, FilePath);
        }
    }
}
