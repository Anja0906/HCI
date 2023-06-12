using System.Collections.Generic;
using HCI_big_project.model;
using HCI_big_project.repository;

namespace HCI_big_project.service
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository;

        public ClientService(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        

        public void addNewTrip(string email, Trip trip) { 
            List<Client> clients = _clientRepository.GetAllClients();
            int index = clients.FindIndex(c => c.Email == email);
            if (index >= 0) {clients[index].Trips.Add(trip);}
            _clientRepository.SaveAll();
        }

        public Client FindClientByEmail(string email)
        {
            return _clientRepository.FindClientByEmail(email);
        }



    }
}