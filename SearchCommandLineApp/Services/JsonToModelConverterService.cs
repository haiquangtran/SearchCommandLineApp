using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SearchCommandLineApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCommandLineApp.Services
{
    class JsonToModelConverterService : IJsonToModelConverterService
    {
        public IEnumerable<T> GetModelsFromFile<T>(string fileName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\", fileName);

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"No file exists at path: {filePath}");
                Console.WriteLine("Please try again.");
                return null;
            }

            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(filePath));
        }
    }
}