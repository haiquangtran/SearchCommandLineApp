using SearchCommandLineApp.Models;
using SearchCommandLineApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCommandLineApp
{
    class Program
    {
        static void Main(string[] args)
        {            
            if (args.Count() == 2)
            {                
                JsonToModelConverterService dataService = new JsonToModelConverterService();
                var organisations = dataService.GetModelsFromFile<Organisation>("organizations.json");
                var users = dataService.GetModelsFromFile<User>("users.json");
                var tickets = dataService.GetModelsFromFile<Ticket>("tickets.json");

                // Strategies
                var ticketSearch = new TicketSearch(tickets);
                var userSearch = new UserSearch(users);
                var organisationSearch = new OrganisationSearch(organisations);

                SearchApp app = new SearchApp(dataService, userSearch);
                
                var command = args[0];

                // TODO:
                if (command == "search")
                {
                    app.Search(args[1]);
                    app.PrintSearchResults();
                }
            }

            Console.Read();
        }
    }
}
