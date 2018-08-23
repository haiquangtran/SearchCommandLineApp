using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchCommandLineApp.Models;
using SearchCommandLineApp.Repositories;

namespace SearchCommandLineAppTests.Repositories
{
    [TestClass]
    public class UserRepositoryTests
    {
        [TestMethod]
        public void UserRepository_GetUsers_ShouldReturnOneUser()
        {
            var list = new List<User>() {
                new User()
            };
            var userRepository = new UserRepository(list);
            var test = userRepository.GetUsers().ToList();

            Assert.IsNotNull(test);
            Assert.AreEqual(1, test.Count);
        }
    }
}
