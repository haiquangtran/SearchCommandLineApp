using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SearchCommandLineApp.Models;

namespace SearchCommandLineAppTests.Models
{
    [TestClass]
    public class PropertyValueSearchTests
    {
        private PropertyValueSearch _propertyValueSearch;
        private class TestClass
        {
            public int TestID { get; set; }
            public bool TestBool { get; set; }
            public string TestString { get; set; }
            public string[] TestArray { get; set; }
        }

        private TestClass GetTestClassWithAllPopulatedProperties()
        {
            return new TestClass()
            {
                TestID = 1,
                TestArray = new string[] { "a", "b" },
                TestString = "Not Empty",
                TestBool = false
            };
        }

        [TestInitialize]
        public void SetUp()
        {
            _propertyValueSearch = new PropertyValueSearch();
        }
        
        [TestMethod]
        public void PropertyValueSearch_Search_SearchTermTest_NoMatch()
        {
            var list = new List<TestClass>()
            {
                GetTestClassWithAllPopulatedProperties()
            };

            var test = _propertyValueSearch.Search("Test", list).ToList();

            Assert.AreEqual(0, test.Count);
        }

        [TestMethod]
        public void PropertyValueSearch_Search_SearchTermNull_ShouldReturnOneObjectContainingNull()
        {
            var containsNull = GetTestClassWithAllPopulatedProperties();
            containsNull.TestString = null;

            var list = new List<TestClass>()
            {
                containsNull,
                GetTestClassWithAllPopulatedProperties()
            };
            
            var test = _propertyValueSearch.Search(null, list).ToList();

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual(JsonConvert.SerializeObject(containsNull, Formatting.Indented), test.First());
        }
        
        [TestMethod]
        public void PropertyValueSearch_Search_SearchTermNullString_ShouldReturnOneObjectContainingNull()
        {
            var containsNull = GetTestClassWithAllPopulatedProperties();
            containsNull.TestString = null;

            var list = new List<TestClass>()
            {
                containsNull,
                GetTestClassWithAllPopulatedProperties()
            };

            var test = _propertyValueSearch.Search("null", list).ToList();

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual(JsonConvert.SerializeObject(containsNull, Formatting.Indented), test.First());
        }
        
        [TestMethod]
        public void PropertyValueSearch_Search_SearchTermEmptyString_ShouldReturnOneObjectContainingEmptyField()
        {
            var containsNull = GetTestClassWithAllPopulatedProperties();
            containsNull.TestString = "";

            var list = new List<TestClass>()
            {
                containsNull,
                GetTestClassWithAllPopulatedProperties()
            };

            var test = _propertyValueSearch.Search("", list).ToList();

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual(JsonConvert.SerializeObject(containsNull, Formatting.Indented), test.First());
        }

        [TestMethod]
        public void PropertyValueSearch_Search_SearchTermInt_ShouldHaveOneMatch()
        {
            var expectedMatch = GetTestClassWithAllPopulatedProperties();
            expectedMatch.TestID = 100;
            var list = new List<TestClass>()
            {
                expectedMatch,
                GetTestClassWithAllPopulatedProperties()
            };

            var test = _propertyValueSearch.Search("100", list).ToList();

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual(JsonConvert.SerializeObject(expectedMatch, Formatting.Indented), test.First());
        }

        [TestMethod]
        public void PropertyValueSearch_Search_SearchTermBool_ShouldHaveOneMatch()
        {
            var expectedMatch = GetTestClassWithAllPopulatedProperties();
            expectedMatch.TestBool = true;
            var list = new List<TestClass>()
            {
                expectedMatch,
                GetTestClassWithAllPopulatedProperties()
            };

            var test = _propertyValueSearch.Search("true", list).ToList();

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual(JsonConvert.SerializeObject(expectedMatch, Formatting.Indented), test.First());
        }

        [TestMethod]
        public void PropertyValueSearch_Search_SearchTermString_ShouldHaveOneMatch()
        {
            const string expectedMatchString = "result";
            var expectedMatch = GetTestClassWithAllPopulatedProperties();
            expectedMatch.TestString = expectedMatchString;
            var list = new List<TestClass>()
            {
                expectedMatch,
                GetTestClassWithAllPopulatedProperties()
            };

            var test = _propertyValueSearch.Search(expectedMatchString, list).ToList();

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual(JsonConvert.SerializeObject(expectedMatch, Formatting.Indented), test.First());
        }

        [TestMethod]
        public void PropertyValueSearch_Search_SearchTermIsInTheList_ShouldHaveOneMatch()
        {
            const string expectedMatchString = "Matched";
            var expectedMatch = GetTestClassWithAllPopulatedProperties();
            expectedMatch.TestArray = new string[] { expectedMatchString };
            var list = new List<TestClass>()
            {
                expectedMatch,
                GetTestClassWithAllPopulatedProperties()
            };

            var test = _propertyValueSearch.Search(expectedMatchString, list).ToList();

            Assert.AreEqual(1, test.Count);
            Assert.AreEqual(JsonConvert.SerializeObject(expectedMatch, Formatting.Indented), test.First());
        }

        [TestMethod]
        public void PropertyValueSearch_Search_SearchTermIsInTheList_ShouldHaveTwoMatches()
        {
            const string expectedMatchString = "Two matches";
            var expectedMatchOne = GetTestClassWithAllPopulatedProperties();
            expectedMatchOne.TestArray = new string[] { expectedMatchString };
            var expectedMatchTwo = GetTestClassWithAllPopulatedProperties();
            expectedMatchTwo.TestString = expectedMatchString;
            var list = new List<TestClass>()
            {
                expectedMatchOne,
                GetTestClassWithAllPopulatedProperties(),
                expectedMatchTwo
            };

            var test = _propertyValueSearch.Search(expectedMatchString, list).ToList();

            Assert.AreEqual(2, test.Count);
            Assert.AreEqual(JsonConvert.SerializeObject(expectedMatchOne, Formatting.Indented), test[0]);
            Assert.AreEqual(JsonConvert.SerializeObject(expectedMatchTwo, Formatting.Indented), test[1]);
        }
    }
}
