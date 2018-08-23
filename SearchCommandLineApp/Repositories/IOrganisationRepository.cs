using SearchCommandLineApp.Models;
using System.Collections.Generic;

namespace SearchCommandLineApp.Repositories
{
    public interface IOrganisationRepository
    {
        IEnumerable<Organisation> GetOrganisations();
    }
}