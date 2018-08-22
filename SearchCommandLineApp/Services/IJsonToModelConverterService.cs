using System.Collections.Generic;

namespace SearchCommandLineApp.Services
{
    public interface IJsonToModelConverterService
    {
        IEnumerable<T> GetModelsFromFile<T>(string fileName);
    }
}