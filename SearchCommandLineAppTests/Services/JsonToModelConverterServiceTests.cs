using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchCommandLineApp.Services;

namespace SearchCommandLineAppTests.Services
{
    [TestClass]
    public class JsonToModelConverterServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void JsonToModelConverterService_GetModelsFromFile_NoFile_ThrowsException()
        {
            var test = new JsonToModelConverterService();
            test.GetModelsFromFile<Object>("Imaginary_file.json");
        }
    }
}
