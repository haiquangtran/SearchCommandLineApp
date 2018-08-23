using SearchCommandLineApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCommandLineApp.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly IEnumerable<Ticket> _tickets;

        public TicketRepository(IEnumerable<Ticket> tickets)
        {
            _tickets = tickets;
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return _tickets;
        }
    }
}
