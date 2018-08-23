using SearchCommandLineApp.Models;
using System.Collections.Generic;

namespace SearchCommandLineApp.Repositories
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetTickets();
    }
}