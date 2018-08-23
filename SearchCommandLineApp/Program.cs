using SearchCommandLineApp.Common;
using SearchCommandLineApp.Models;
using SearchCommandLineApp.Repositories;
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
                    SearchResultPrinter printer = new SearchResultPrinter();
                    PropertyValueSearch searcher = new PropertyValueSearch();
                    IOrganisationRepository organisationDataset = null;
                    ITicketRepository ticketDataset = null;
                    IUserRepository userDataset = null;

                    for (var i = fileStartIndex; i < numArgs; i++)
                    {
                        var datasetSelected = args[i];
                        List<string> searchResults;
                        if (string.Equals(datasetSelected, Constants.Datasets.ORGANISATION, StringComparison.OrdinalIgnoreCase))
                        {
                            organisationDataset = organisationDataset ?? new OrganisationRepository(dataService.GetModelsFromFile<Organisation>("organizations.json"));
                            searchResults = searcher.Search(searchTerm, organisationDataset.GetOrganisations()).ToList();
                        }
                        else if (string.Equals(datasetSelected, Constants.Datasets.TICKETS, StringComparison.OrdinalIgnoreCase))
                        {
                            ticketDataset = ticketDataset ?? new TicketRepository(dataService.GetModelsFromFile<Ticket>("tickets.json"));
                            searchResults = searcher.Search(searchTerm, ticketDataset.GetTickets()).ToList();
                        }  
                        else if (string.Equals(datasetSelected, Constants.Datasets.USERS, StringComparison.OrdinalIgnoreCase))
                        {
                            userDataset = userDataset ?? new UserRepository(dataService.GetModelsFromFile<User>("users.json"));
                            searchResults = searcher.Search(searchTerm, userDataset.GetUsers()).ToList();
                        }
                        else
                        {
                            Console.WriteLine($"NO DATASET FOR {datasetSelected} WAS FOUND.");
                            Console.WriteLine("THE AVAILABLE DATASET OPTIONS ARE THE FOLLOWING:\nOrganisations\nTickets\nUsers");
                            continue;
                        }
                        
                        printer.PrintSearchResults(datasetSelected, searchResults);
                    }
                }
            }
            
            Console.Read();
        }
    }
}
