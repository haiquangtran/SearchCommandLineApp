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
    class JsonToModelConverterService
    {
        public IEnumerable<Organisation> GetModelsFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"No file exists at path: {filePath}");
            }

            return JsonConvert.DeserializeObject<List<Organisation>>(File.ReadAllText(filePath));
        }
    }
}