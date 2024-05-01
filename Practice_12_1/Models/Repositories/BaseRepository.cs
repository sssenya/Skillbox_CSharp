using System;
using System.IO;

namespace Practice_12_1.Models
{
    internal class BaseRepository<T>
    {
        private protected readonly string _filePath;
        private protected readonly JsonConverter<T> _converter;

        public BaseRepository(string jsonPath)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            _filePath = projectDirectory + jsonPath;

            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }

            _converter = new JsonConverter<T>(_filePath);
        }
    }
}
