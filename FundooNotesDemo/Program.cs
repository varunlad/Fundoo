using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotesDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
//The Main method of the program.cs class is the entry point of our application.
//It configures & builds the Web host. The web host is responsible for running our app.
//Most of the plumbing required to configure host is already done for us in the createdefaultbuilder method,
//which is invoked in the Main method. We can further add our custom configuration is startup class.
//----//
//CreateDefaultBuilder-it enables Dependancy Injection(DI) container
//CreateHostBuilder-it create the host and provide the configuration to it
//Build()-it builds it using the provided configuration
//Run()-it runs it and listen for HTTP request

