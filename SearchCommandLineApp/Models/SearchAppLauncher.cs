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
    public class SearchAppLauncher
    {
        private IOrganisationRepository _organisationDataset;
        private ITicketRepository _ticketDataset;
        private IUserRepository _userDataset;
        private ISearchable _searcher;
        private SearchResultPrinter _printer;
        private HelpPrinter _helpPrinter;

        public SearchAppLauncher(IOrganisationRepository organisationRepository, ITicketRepository ticketRepository, 
            IUserRepository userRepository, ISearchable searcherMethod)
        {
            _organisationDataset = organisationRepository;
            _ticketDataset = ticketRepository;
            _userDataset = userRepository;
            _searcher = searcherMethod;
            _printer = new SearchResultPrinter();
            _helpPrinter = new HelpPrinter();
        }

        public List<string> StartSearch(string searchTerm, string datasetSelected)
        {
            if (string.Equals(datasetSelected, Constants.Datasets.ORGANISATION, StringComparison.OrdinalIgnoreCase))
                return _searcher.Search(searchTerm, _organisationDataset.GetOrganisations()).ToList();
            else if (string.Equals(datasetSelected, Constants.Datasets.TICKETS, StringComparison.OrdinalIgnoreCase))
                return _searcher.Search(searchTerm, _ticketDataset.GetTickets()).ToList();
            else if (string.Equals(datasetSelected, Constants.Datasets.USERS, StringComparison.OrdinalIgnoreCase))
                return _searcher.Search(searchTerm, _userDataset.GetUsers()).ToList();

            return null;
        }

        public void Start(string[] args)
        {
            var numArgs = args.Count();
            var minArgs = 4;
            var maxArgs = 6;

            if (numArgs < minArgs || numArgs > maxArgs)
            {
                _helpPrinter.PrintHelp();
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
                        var searchResults = StartSearch(searchTerm, datasetSelected);

                        if (searchResults == null)
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
