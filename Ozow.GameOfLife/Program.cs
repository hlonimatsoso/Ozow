using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ozow.GameOfLife.Game;
using Ozow.GameOfLife.Interfaces;
using System;
using System.IO;

namespace Ozow.GameOfLife
{
    class Program
    {
        public static IConfigurationRoot configuration;

        public static IServiceProvider serviceProvider;

        static int Main(string[] args)
        {

            try
            {
                Run(args);
                Console.ReadKey();
                return 0;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                return 1;
            }
        }

        static void Run(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            string rawString = configuration.GetSection("text").Value.ToLower();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("AppSettings.json", false)
                        .Build();

            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);

            serviceCollection.AddTransient<IGameEngine, GameEngine>();
            serviceCollection.AddTransient<GameEngine>();
            serviceCollection.Configure<GameSettings>(configuration.GetSection("GameSettings"));

            serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
