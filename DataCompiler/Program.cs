﻿using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using MovieEntities.Serialization;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DataCompiler
{
    class Program
    {

        static void Main(string[] args)
        {
            // Call the startup class config methods
            BuildWebHost(args).Run();

            new DataLoader().Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();


    }
}