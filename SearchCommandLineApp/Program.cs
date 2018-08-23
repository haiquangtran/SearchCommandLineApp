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
            var dataService = new JsonToModelConverterService();

            var searchMethod = new PropertyValueSearch();
            var organisationRepository = new OrganisationRepository(dataService.GetModelsFromFile<Organisation>("organizations.json"));
            var ticketRepository = new TicketRepository(dataService.GetModelsFromFile<Ticket>("tickets.json"));
            var userRepository = new UserRepository(dataService.GetModelsFromFile<User>("users.json"));

            SearchAppLauncher app = new SearchAppLauncher(organisationRepository, ticketRepository, userRepository, searchMethod);
            app.Start(args);
            
            Console.Read();
        }
    }
}
