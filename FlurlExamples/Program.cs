using System;
using Flurl.Http;
using FlurlExamples.Model;

namespace FlurlExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Flurl examples.");
            Console.WriteLine();

            var flurlRequestHandler = new FlurlRequestHandler();

            var repositories = flurlRequestHandler.GetRepositories().Result;

            Console.WriteLine($"Number of repositories {repositories.Count}");
            Console.WriteLine();
            foreach (var repository in repositories)
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                WriteInColor("Repository", ConsoleColor.Green);
                WriteResult(repository);
            }
            Console.WriteLine();

            try
            {
                var newRepository = flurlRequestHandler.CreateRepository("CodeMazeBlog", "Test-Repository").Result;
                WriteInColor("Repository created", ConsoleColor.Green);
                WriteResult(newRepository);
                Console.WriteLine();
            }
            catch (AggregateException ae)
            {
                // in case the repository already exists, handle FlurlHttpException
                ae.Handle(ex =>
                {
                    if (ex is FlurlHttpException)
                    {
                        Console.WriteLine(ex);
                    }
                    return ex is FlurlHttpException;
                });
            }

            var editedRepository = flurlRequestHandler.EditRepository("CodeMazeBlog", "Test-Repository").Result;
            WriteInColor("Repository edited", ConsoleColor.Green);
            WriteResult(editedRepository);
            Console.WriteLine();

            var deleteRepoResult = flurlRequestHandler.DeleteRepository("CodeMazeBlog", "Test-Repository").Result;
            WriteInColor($"Repository deleted, status code: {deleteRepoResult.ReasonPhrase}", ConsoleColor.Green);
            Console.WriteLine();

            Console.ReadKey();
        }

        private static void WriteInColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void WriteResult(Repository repository)
        {
            Console.WriteLine($"Name: {repository.Name}");
            Console.WriteLine($"Full name: {repository.FullName}");
            Console.WriteLine($"Description: {repository.Description ?? "None"}");
            Console.WriteLine($"Url: {repository.Url}");
            Console.WriteLine($"Private: {repository.Private}");
        }
    }
}
