using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchCommandLineApp.Models;
using SearchCommandLineApp.Repositories;

namespace SearchCommandLineAppTests.Repositories
{
    [TestClass]
    public class TicketRepositoryTests
    {
        [TestMethod]
        public void TicketRepository_Constructor_SetsTicketsList_ShouldReturnOneTicket()
        {
            var list = new List<Ticket>() {
                new Ticket()
            };
            var ticketRepository = new TicketRepository(list);
            var test = ticketRepository.GetTickets().ToList();

            Assert.IsNotNull(test);
            Assert.AreEqual(1, test.Count);
        }
    }
}
