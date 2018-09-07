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

            var repositories = flurlRequestHandler.GetRepositories();

            foreach (var repository in repositories.Result)
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine("Repository:");
                Console.WriteLine($"Name: {repository.Name}");
                Console.WriteLine($"Full name: {repository.FullName}");
                Console.WriteLine($"Description: {repository.Description ?? "None"}");
                Console.WriteLine($"Url: {repository.Url}");
                Console.WriteLine($"Private: {repository.Private}");
                Console.WriteLine();
            }

            var createRepoResult = flurlRequestHandler.CreateRepository("CodeMazeBlog", "Test-Repository").Result;
            var deleteRepoResult = flurlRequestHandler.DeleteRepository("CodeMazeBlog", "Test-Repository").Result;

            Console.ReadKey();
        }
    }
}
