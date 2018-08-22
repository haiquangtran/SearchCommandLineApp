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
                SearchApp app = new SearchApp(dataService);

                var command = args[0];

                if (command == "search")
                {
                    app.Search(args[1]);
                }
            }

            Console.Read();
        }
    }
}
