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
    class OrganisationSearch : ISearchable
    {
        private List<Organisation> _organisations;

        public OrganisationSearch(IEnumerable<Organisation> organisations)
        {
            _organisations = organisations.ToList();
        }

        public IEnumerable<string> Search(string searchTerm)
        {
            var objectsContainingSearchTerm = new List<string>();

            foreach (var organisation in _organisations)
            {
                var organisationProperties = organisation.GetType().GetProperties().ToList();
                var organisationHasSearchTerm = organisationProperties.Any(p =>
                {
                    var propertyValue = p.GetValue(organisation, null);
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

                if (organisationHasSearchTerm)
                    objectsContainingSearchTerm.Add(JsonConvert.SerializeObject(organisation, Formatting.Indented));
            }

            return objectsContainingSearchTerm;
        }
    }
}
