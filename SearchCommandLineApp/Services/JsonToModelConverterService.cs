﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SearchCommandLineApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCommandLineApp.Services
{
    public class JsonToModelConverterService : IJsonToModelConverterService
    {
        public IEnumerable<T> GetModelsFromFile<T>(string fileName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\", fileName);

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"No file exists at path: {filePath}");
                    Console.WriteLine("Please check you have the correct file path and try again.");

                    throw new FileNotFoundException("File does not exist at specified path.");
                }

                return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(filePath));
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops! something went wrong! Please make sure you have a valid .json file.");
                Console.WriteLine(e.StackTrace);

                // TODO: handle
                throw e;
            }
        }
    }
}