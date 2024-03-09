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
using static Practice_10_1.Client;

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
            List<Client> clients = new List<Client>();

            using (StreamReader file = File.OpenText(_filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                clients = (List<Client>)serializer.Deserialize(file, typeof(List<Client>));
            }

            clients.Sort(new SortByName());

            return clients;
        }
        
        public void UpdateDatabase(ObservableCollection<Client> clients)
        {
            using (StreamWriter file = File.CreateText(_filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, clients);
            }
        }
    }
}
