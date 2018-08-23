using SearchCommandLineApp.Common;
using SearchCommandLineApp.Repositories;
using SearchCommandLineApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCommandLineApp.Models
{
    class SearchAppLauncher
    {
        private IOrganisationRepository _organisationDataset;
        private ITicketRepository _ticketDataset;
        private IUserRepository _userDataset;
        private JsonToModelConverterService _dataService;
        private SearchResultPrinter _printer;
        private PropertyValueSearch _searcher;

        public SearchAppLauncher()
        {
            _dataService = new JsonToModelConverterService();
            _printer = new SearchResultPrinter();
            _searcher = new PropertyValueSearch();
        }

        public List<string> DatasetSearcher(string searchTerm, string datasetSelected)
        {
            List<string> searchResults = new List<string>();
            if (string.Equals(datasetSelected, Constants.Datasets.ORGANISATION, StringComparison.OrdinalIgnoreCase))
            {
                _organisationDataset = _organisationDataset ?? new OrganisationRepository(_dataService.GetModelsFromFile<Organisation>("organizations.json"));
                searchResults = _searcher.Search(searchTerm, _organisationDataset.GetOrganisations()).ToList();
            }
            else if (string.Equals(datasetSelected, Constants.Datasets.TICKETS, StringComparison.OrdinalIgnoreCase))
            {
                _ticketDataset = _ticketDataset ?? new TicketRepository(_dataService.GetModelsFromFile<Ticket>("tickets.json"));
                searchResults = _searcher.Search(searchTerm, _ticketDataset.GetTickets()).ToList();
            }
            else if (string.Equals(datasetSelected, Constants.Datasets.USERS, StringComparison.OrdinalIgnoreCase))
            {
                _userDataset = _userDataset ?? new UserRepository(_dataService.GetModelsFromFile<User>("users.json"));
                searchResults = _searcher.Search(searchTerm, _userDataset.GetUsers()).ToList();
            }

            return searchResults;
        }

        public void Start(string[] args)
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
                    for (var i = fileStartIndex; i < numArgs; i++)
                    {
                        var datasetSelected = args[i];
                        var searchResults = DatasetSearcher(searchTerm, datasetSelected);

                        if (searchResults.Count == 0)
                        {
                            Console.WriteLine($"NO DATASET FOR {datasetSelected} WAS FOUND.");
                            Console.WriteLine("THE AVAILABLE DATASET OPTIONS ARE THE FOLLOWING:\nOrganisations\nTickets\nUsers");
                            continue;
                        }

                        _printer.PrintSearchResults(datasetSelected, searchResults);
                    }
                }
            }
        }
    }
}
