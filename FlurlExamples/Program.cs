using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace FlurlExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Flurl examples.");
            Console.WriteLine();

            var flurlRequestHandler = new FlurlRequestHandler();

            var result = flurlRequestHandler.GetAuthorizations().Result;

            Console.WriteLine(JsonConvert.SerializeObject(result));

            Console.ReadKey();
        }
    }
}
