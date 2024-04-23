using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Newtonsoft.Json;

namespace Practice_12_1.Models
{
    internal class Repository
    {
        private readonly string _filePath;
        private readonly JsonConverter<Client> _converter;

        public Repository()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            _filePath = projectDirectory + "\\ClientsData\\ClientsDatabase.json";

            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }

            _converter = new JsonConverter<Client>(_filePath);
        }

        public List<Client> GetClients()
        {
            return _converter.GetElements();
        }
        
        public void UpdateDatabase(ObservableCollection<Client> clients)
        {
            _converter.UpdateElements(clients);
        }
    }
}
