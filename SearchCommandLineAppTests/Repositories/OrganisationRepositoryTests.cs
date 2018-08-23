using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchCommandLineApp.Models;
using SearchCommandLineApp.Repositories;

namespace SearchCommandLineAppTests.Repositories
{
    [TestClass]
    public class OrganisationRepositoryTests
    {
        [TestMethod]
        public void OrganisationRepository_GetOrganisations_ShouldReturnOneOrganisation()
        {
            var list = new List<Organisation>() {
                new Organisation()
            };
            var organisationRepository = new OrganisationRepository(list);
            var test = organisationRepository.GetOrganisations().ToList();

            Assert.IsNotNull(test);
            Assert.AreEqual(1, test.Count);
        }
    }
}
