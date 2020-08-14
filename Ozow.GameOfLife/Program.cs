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
                ServiceCollection serviceCollection = new ServiceCollection();

                ConfigureServices(serviceCollection);

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
            IGameEngine gameEngine = serviceProvider.GetService<IGameEngine>();

            gameEngine.Initialize();

            gameEngine.Start();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("AppSettings.json", false)
                        .Build();

            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);

            serviceCollection.AddTransient<IActiveFormation, ActiveFormation>();
            serviceCollection.AddTransient<ICell, Cell>();
            serviceCollection.AddTransient<ICellPosition, CellPosition>();
            serviceCollection.AddTransient<IFormation, Formation>();
            serviceCollection.AddTransient<IGameBoard, GameBoard>();
            serviceCollection.AddTransient<IGameEngine, GameEngine>();
            serviceCollection.AddTransient<IGameUiDrawer, Piccasso>();
            serviceCollection.Configure<GameSettings>(configuration.GetSection("GameSettings"));
            serviceCollection.AddTransient<IActiveFormation, ActiveFormation>();
            serviceCollection.AddTransient<IInstruction, Instruction>();
            serviceCollection.AddTransient<IMatrix, TheMatrix>();
            serviceCollection.AddTransient<IToolBox, ToolBox>();


            serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
