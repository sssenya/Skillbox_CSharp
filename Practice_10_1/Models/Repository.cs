using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Practice_10_1.ViewModels;

namespace Practice_10_1.Models
{
    internal class Repository
    {
        private readonly string _filePath;

        public Repository()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            _filePath = projectDirectory + "\\ClientsData\\ClientsDatabase.json";

            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }
        }

        public List<Client> GetClients()
        {
            List<Client> clients;

            using (StreamReader file = File.OpenText(_filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                clients = (List<Client>)serializer.Deserialize(file, typeof(List<Client>));
            }

            return clients;
        }
        
        public void UpdateDatabase(ObservableCollection<IClientInfo> clients)
        {
            List<Client> clientsToJson = new List<Client>();
            foreach(var client in clients)
            {
                clientsToJson.Add(client.GetClient());
            }
            
            using (StreamWriter file = File.CreateText(_filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, clientsToJson);
            }
        }
    }
}
