using Newtonsoft.Json;
using SearchCommandLineApp.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SearchCommandLineApp.Models
{
    class SearchResultPrinter
    {
        public void PrintSearchResults(string datasetName, List<string> searchResults)
        {
            if (searchResults.Count == 0)
            {
                Console.WriteLine($"FOUND NO SEARCH RESULTS IN THE DATASET: {datasetName}");
                return;
            }
                
            Console.WriteLine($"FOUND {searchResults.Count} SEARCH RESULT(S) IN THE DATASET {datasetName}:");
            var result = string.Join(",", searchResults);
            Console.WriteLine(result);
        }
    }
}
