using Newtonsoft.Json;
using SearchCommandLineApp.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCommandLineApp.Models
{
    class PropertyValueSearch : ISearchable
    {
        public IEnumerable<string> Search(string searchTerm, IEnumerable<Object> propertyCollection)
        {
            var objectsContainingSearchTerm = new List<string>();

            foreach (var property in propertyCollection)
            {
                var properties = property.GetType().GetProperties().ToList();
                var hasSearchTerm = properties.Any(p =>
                {
                    var propertyValue = p.GetValue(property, null);
                    var propertyList = propertyValue as IEnumerable;
                    if (propertyList != null && !(propertyList is string))
                    {
                        foreach (var propertyListVal in propertyList)
                        {
                            if (String.Equals(propertyListVal.ToString(), searchTerm, StringComparison.OrdinalIgnoreCase))
                                return true;
                        }
                    }

                    return String.Equals(propertyValue?.ToString() ?? string.Empty, searchTerm, StringComparison.OrdinalIgnoreCase);
                });

                if (hasSearchTerm)
                    objectsContainingSearchTerm.Add(JsonConvert.SerializeObject(property, Formatting.Indented));
            }

            return objectsContainingSearchTerm;
        }
    }
}
