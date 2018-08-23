using SearchCommandLineApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCommandLineApp.Repositories
{
    public class OrganisationRepository : IOrganisationRepository
    {
        private readonly IEnumerable<Organisation> _organisations;

        public OrganisationRepository(IEnumerable<Organisation> organisations)
        {
            _organisations = organisations;
        }

        public IEnumerable<Organisation> GetOrganisations()
        {
            return _organisations;
        }
    }
}
