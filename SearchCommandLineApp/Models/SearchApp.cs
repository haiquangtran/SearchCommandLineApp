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
    class SearchApp
    {
        private List<string> _searchResults;
        private ISearchable _searchMethod;

        public SearchApp()
        {
        }

        public SearchApp(ISearchable searchMethod)
        {
            _searchMethod = searchMethod;
        }

        public void SetSearchMethod(ISearchable searchMethod)
        {
            _searchMethod = searchMethod;
        }

        public void Search(string searchTerm)
        {
            _searchResults = _searchMethod.Search(searchTerm).ToList();
        }

        public void PrintSearchResults()
        {
            if (_searchResults.Count == 0)
            {
                Console.WriteLine("FOUND NO SEARCH RESULTS.");
                return;
            }
                
            Console.WriteLine($"FOUND {_searchResults.Count} SEARCH RESULT(S): ");
            var result = string.Join(",", _searchResults);
            Console.WriteLine(result);
        }
    }
}
