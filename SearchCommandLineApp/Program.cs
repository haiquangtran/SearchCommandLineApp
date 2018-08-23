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
            SearchAppLauncher app = new SearchAppLauncher();
            app.Start(args);
            
            Console.Read();
        }
    }
}
