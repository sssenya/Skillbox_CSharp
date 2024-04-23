using System.Collections.Generic;


namespace Practice_12_1.Models
{
    internal class Repository : BaseRepository<Client>
    {
        public Repository() : base("\\ClientsData\\ClientsDatabase.json") { }

        public List<Client> GetClients()
        {
            return _converter.GetElements();
        }
        
        public void UpdateDatabase(IEnumerable<Client> clients)
        {
            _converter.UpdateElements(clients);
        }
    }
}
