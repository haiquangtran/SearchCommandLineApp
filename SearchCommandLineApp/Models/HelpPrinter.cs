using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCommandLineApp.Models
{
    class HelpPrinter
    {
        public void PrintHelp()
        {
            Console.WriteLine("To use this tool, do the following: ");
            Console.WriteLine("1. In your terminal, navigate to the directory of the SearchCommandLineApp.exe. ");
            Console.WriteLine("2. Use this tool by using the following syntax in the terminal: \"./SearchCommandLineApp -search \"search-term\" -dataset <organisations | users | tickets> [organisations | users | tickets] [organisations | users | tickets]");
            Console.WriteLine("\"search-term\" is the value you are looking for within the JSON object i.e. \"John\"");
            Console.WriteLine("<organisations | users | tickets>: Represents that it is required to specify one of these datasets.");
            Console.WriteLine("[organisations | users | tickets]: Represents that it is optional to specify one of these datasets.");
            Console.WriteLine("For more help, please see visit the website: https://github.com/haiquangtran/SearchCommandLineApp");
        }
    }
}
