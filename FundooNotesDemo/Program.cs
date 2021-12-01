//// -------------------------------------------------------------------------------------------------------
// <copyright file="program.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Varun Hemant Lad"/>
// ----------------------------------------------------------------------------------------------------------

namespace FunDooNote
{
    using FundooNotesDemo;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using NLog.Extensions.Logging;

    /// <summary>
    /// main program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// This is the main method of code.
        /// It configures & builds the Web host. The web host is responsible for running our app.
        /// Most of the plumbing required to configure host is already done for us in the createdefaultbuilder method,
        /// which is invoked in the Main method. We can further add our custom configuration is startup class.
        /// </summary>
        /// <param name="args">string array arguments</param> 
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// CreateHostBuilder-it create the host and provide the configuration to it.
        /// CreateDefaultBuilder-it enables Dependency Injection(DI) container.
        /// Build()-it builds it using the provided configuration
        /// Run()-it runs it and listen for HTTP request
        /// </summary>
        /// <param name="args"> string array arguments</param>
        /// <returns>It pass the control to the startup file</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .ConfigureLogging((hostingContext, logging) =>
             {
                 logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                 logging.AddDebug();
                 logging.AddNLog();
             })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
