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
        private List<Organisation> _organisations;
        private List<Ticket> _tickets;
        private List<User> _users;

        public SearchApp(JsonToModelConverterService dataService)
        {
            // TODO:
            string fileName = "organizations.json";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\", fileName);

            _organisations = dataService.GetModelsFromFile(filePath).ToList();
        }

        public void Search(string searchTerm)
        {
            foreach (var organisation in _organisations)
            {
                var organisationProperties = organisation.GetType().GetProperties().ToList();
                var organisationHasSearchTerm = organisationProperties.Any(p =>
                {
                    var propertyValue = p.GetValue(organisation, null);
                    if (propertyValue is string)
                        return String.Equals(propertyValue.ToString(), searchTerm, StringComparison.OrdinalIgnoreCase);

                    var propertyList = propertyValue as IEnumerable;
                    if (propertyList != null)
                    {
                        foreach (var propertyListVal in propertyList)
                        {
                            if (String.Equals(propertyListVal.ToString(), searchTerm, StringComparison.OrdinalIgnoreCase))
                                return true;
                        }
                    }

                    return false;
                });

                if (organisationHasSearchTerm)
                    Console.WriteLine(JsonConvert.SerializeObject(organisation));
            }
        }
    }
}
