﻿using SearchCommandLineApp.Models;
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

                // Strategies
                var ticketSearch = new TicketSearch(dataService);
                var userSearch = new UserSearch(dataService);
                var organisationSearch = new OrganisationSearch(dataService);

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
