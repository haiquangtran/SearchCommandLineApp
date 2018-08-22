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
    class UserSearch : ISearchable
    {
        private List<User> _users;

        public UserSearch(IEnumerable<User> users)
        {
            _users = users.ToList();
        }

        public IEnumerable<string> Search(string searchTerm)
        {
            var objectsContainingSearchTerm = new List<string>();

            foreach (var user in _users)
            {
                var userProperties = user.GetType().GetProperties().ToList();
                var userHasSearchTerm = userProperties.Any(p =>
                {
                    var propertyValue = p.GetValue(user, null);
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
                
                if (userHasSearchTerm)
                    objectsContainingSearchTerm.Add(JsonConvert.SerializeObject(user, Formatting.Indented));
            }

            return objectsContainingSearchTerm;
        }
    }
}
