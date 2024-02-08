using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;


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
    }
}
