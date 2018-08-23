using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using SearchCommandLineApp.Common;
using SearchCommandLineApp.Models;
using SearchCommandLineApp.Repositories;

namespace SearchCommandLineAppTests.Models
{
    [TestClass]
    public class SearchAppLauncherTests
    {
        private Mock<IOrganisationRepository> _mockOrganisationRepository;
        private Mock<ITicketRepository> _mockTicketRepository;
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<ISearchable> _mockSearchMethod;

        [TestInitialize]
        public void SetUp()
        {
            _mockOrganisationRepository = new Mock<IOrganisationRepository>();
            _mockTicketRepository = new Mock<ITicketRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _mockSearchMethod = new Mock<ISearchable>();
        }

        [TestMethod]
        public void SearchAppLauncher_StartSearch_ShouldCallSearcherMethod()
        {
            var app = new SearchAppLauncher(_mockOrganisationRepository.Object, _mockTicketRepository.Object, _mockUserRepository.Object, _mockSearchMethod.Object);
            var test = app.StartSearch("test", Constants.Datasets.ORGANISATION);

            _mockSearchMethod.Verify(m => m.Search(It.IsAny<string>(), It.IsAny<IEnumerable<Object>>()), Times.Once);
        }

        [TestMethod]
        public void SearchAppLauncher_Start_InvalidNumberOfArguments_LessThanMinArguments_ShouldNotCalLSearch()
        {
            var test = new SearchAppLauncher(_mockOrganisationRepository.Object, _mockTicketRepository.Object, _mockUserRepository.Object, _mockSearchMethod.Object);
            var args = new string[] { "-search", "nothing", "none" };

            test.Start(args);

            _mockSearchMethod.Verify(m => m.Search(It.IsAny<string>(), It.IsAny<IEnumerable<Object>>()), Times.Never);
        }

        [TestMethod]
        public void SearchAppLauncher_Start_InvalidNumberOfArguments_MoreThanMaxArguments_ShouldNotCalLSearch()
        {
            var test = new SearchAppLauncher(_mockOrganisationRepository.Object, _mockTicketRepository.Object, _mockUserRepository.Object, _mockSearchMethod.Object);
            var args = new string[] { "-search", "nothing", "none", "test", "test2", "test3", "test4" };

            test.Start(args);

            _mockSearchMethod.Verify(m => m.Search(It.IsAny<string>(), It.IsAny<IEnumerable<Object>>()), Times.Never);
        }

        [TestMethod]
        public void SearchAppLauncher_Start_ValidNumberOfArguments_WrongSyntax_NoDatasetArgument_ShouldNotCalLSearch()
        {
            var test = new SearchAppLauncher(_mockOrganisationRepository.Object, _mockTicketRepository.Object, _mockUserRepository.Object, _mockSearchMethod.Object);
            var args = new string[] { "-search", "nothing", "none", "test", "test2" };

            test.Start(args);

            _mockSearchMethod.Verify(m => m.Search(It.IsAny<string>(), It.IsAny<IEnumerable<Object>>()), Times.Never);
        }

        [TestMethod]
        public void SearchAppLauncher_Start_ValidNumberOfArguments_WrongSyntax_NoSearchArgument_ShouldNotCalLSearch()
        {
            var test = new SearchAppLauncher(_mockOrganisationRepository.Object, _mockTicketRepository.Object, _mockUserRepository.Object, _mockSearchMethod.Object);
            var args = new string[] { "test", "nothing", "-dataset", "test", "test2" };

            test.Start(args);

            _mockSearchMethod.Verify(m => m.Search(It.IsAny<string>(), It.IsAny<IEnumerable<Object>>()), Times.Never);
        }

        [TestMethod]
        public void SearchAppLauncher_Start_ValidNumberOfArguments_CorrectSyntax_ShouldCallSearch()
        {
            var test = new SearchAppLauncher(_mockOrganisationRepository.Object, _mockTicketRepository.Object, _mockUserRepository.Object, _mockSearchMethod.Object);
            var args = new string[] { "-search", "test", "-dataset", "organisations"};

            test.Start(args);

            _mockSearchMethod.Verify(m => m.Search(It.IsAny<string>(), It.IsAny<IEnumerable<Object>>()), Times.Once);
        }
    }
}
