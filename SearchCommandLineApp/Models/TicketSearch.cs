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
    class TicketSearch : ISearchable
    {
        private List<Ticket> _tickets;

        public TicketSearch(JsonToModelConverterService dataService)
        {
            string ticketsFileName = "tickets.json";

            _tickets = dataService.GetModelsFromFile<Ticket>(ticketsFileName).ToList();
        }

        public IEnumerable<string> Search(string searchTerm)
        {
            var objectsContainingSearchTerm = new List<string>();

            foreach (var ticket in _tickets)
            {
                var ticketProperties = ticket.GetType().GetProperties().ToList();
                var ticketHasSearchTerm = ticketProperties.Any(p =>
                {
                    var propertyValue = p.GetValue(ticket, null);
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

                if (ticketHasSearchTerm)
                    objectsContainingSearchTerm.Add(JsonConvert.SerializeObject(ticket, Formatting.Indented));
            }

            return objectsContainingSearchTerm;
        }
    }
}
