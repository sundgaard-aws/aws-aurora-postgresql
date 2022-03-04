using System;
using System.IO;
using BL;
using DAL;
using DTL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BabelfishConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BabelfishConsole started...");

            // Build configuration
		    var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
			.AddJsonFile("appsettings.json", false)
			.Build();

             //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<ITradeDAC, MSSQL_DAL.TradeDAC>()
                .AddSingleton<TradeBO, TradeBO>()
                .AddSingleton<IConfigurationRoot>(configuration)
                .BuildServiceProvider();

            //configure console logging
            serviceProvider.GetService<ILoggerFactory>();
            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            logger.LogDebug("Starting application");		    

            //do the actual work here
            var tradeBO = serviceProvider.GetService<TradeBO>();
            var trade = new TradeDTO();
            tradeBO.BookTrade(trade);
            Console.WriteLine("BabelfishConsole ended.");
        }
    }
}
