﻿using System.Collections.Generic;
using System.Linq;
using HCI_big_project.model;
using HCI_big_project.utils;

namespace HCI_big_project.repository
{
    public class ClientRepository
    {
        private const string FilePath = "../../files/clients.json";
        private List<Client> Clients { get; set; }

        public ClientRepository()
        {
            Clients = ListHandler.ReadList<Client>(FilePath);
        }

        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public void DeleteClient(Client client)
        {
            Clients.Remove(client);
        }

        public List<Client> GetAllClients()
        {
            return Clients;
        }
        
        public void SaveAll()
        {
            ListHandler.WriteList(Clients, FilePath);
        }
    }
}
