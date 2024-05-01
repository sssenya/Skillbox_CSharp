using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

namespace Practice_12_1.Models
{
    internal class JsonConverter<T>
    {
        private readonly string _filePath;
        
        public JsonConverter(string filePath)
        {
            _filePath = filePath;
        }

        public List<T> GetElements()
        {
            List<T> elements = new List<T>();

            using (StreamReader file = File.OpenText(_filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                elements = (List<T>)serializer.Deserialize(file, typeof(List<T>));
            }

            return elements;
        }

        public void UpdateElements(IEnumerable<T> elements)
        {
            using (StreamWriter file = File.CreateText(_filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, elements);
            }
        }
    }
}
