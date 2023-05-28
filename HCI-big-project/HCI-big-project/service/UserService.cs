using HCI_big_project.repository;

namespace HCI_big_project.service
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
    }
}