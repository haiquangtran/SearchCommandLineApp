using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCommandLineApp.Models
{
    public interface ISearchable
    {
        void Search(string searchTerm);
    }
}
