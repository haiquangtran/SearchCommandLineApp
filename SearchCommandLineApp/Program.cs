using SearchCommandLineApp.Common;
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
            var numArgs = args.Count();
            var minArgs = 4;
            var maxArgs = 6;

            if (numArgs < minArgs || numArgs > maxArgs)
            {
                Console.WriteLine("Please enter the correct Syntax");
            }
            else
            {
                var fileStartIndex = 3;
                var searchCommand = args[0];
                var searchTerm = args[1].ToString();
                var dataCommand = args[2];
                
                if (searchCommand == "-search" && dataCommand == "-dataset")
                {
                    JsonToModelConverterService dataService = new JsonToModelConverterService();
                    SearchApp app = new SearchApp();
                    OrganisationSearch organisationSearch = null;
                    TicketSearch ticketSearch = null;
                    UserSearch userSearch = null;

                    for (var i = fileStartIndex; i < numArgs; i++)
                    {
                        var dataset = args[i];
                        
                        if (string.Equals(dataset, Constants.Datasets.ORGANISATION, StringComparison.OrdinalIgnoreCase))
                        {
                            organisationSearch = organisationSearch ?? new OrganisationSearch(dataService.GetModelsFromFile<Organisation>("organizations.json"));
                            app.SetSearchMethod(organisationSearch);
                        }
                        else if (string.Equals(dataset, Constants.Datasets.TICKETS, StringComparison.OrdinalIgnoreCase))
                        {
                            ticketSearch = ticketSearch ?? new TicketSearch(dataService.GetModelsFromFile<Ticket>("tickets.json"));
                            app.SetSearchMethod(ticketSearch);
                        }  
                        else if (string.Equals(dataset, Constants.Datasets.USERS, StringComparison.OrdinalIgnoreCase))
                        {
                            userSearch = userSearch ?? new UserSearch(dataService.GetModelsFromFile<User>("users.json"));
                            app.SetSearchMethod(userSearch);
                        }
                        else
                        {
                            Console.WriteLine($"NO DATASET FOR {dataset} WAS FOUND.");
                            Console.WriteLine("THE AVAILABLE DATASET OPTIONS ARE THE FOLLOWING:\nOrganisations\nTickets\nUsers");
                            continue;
                        }
                        
                        app.Search(searchTerm);
                        app.PrintSearchResults(dataset);
                    }
                }
            }
            
            Console.Read();
        }
    }
}
