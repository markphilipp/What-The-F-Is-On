using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using MovieEntities.Serialization;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using DataCompiler.Interfaces;
using DataCompiler.Containerization;

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
            var dataLoader = ConsoleContainer.Current.GetService<IDataLoader>();
            dataLoader.Run();
        }
    }
}