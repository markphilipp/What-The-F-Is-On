using System;
using Microsoft.Extensions.DependencyInjection;
using Containerization;
using DataCompiler.Helpers;

namespace DataCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call the startup class config methods
            var startup = new Startup();
            startup.ConfigureContainer();

            // Resolve our main entry point and run
            var dataLoader = ConsoleContainer.Current.GetService<IDataLoaderHelper>();
            dataLoader.Run();
        }
    }
}