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

        /*'
            True randomnes doesn't exist, not in C# I guess, because It ALWAYS creates the same set, for every new System.Random instance min-max pair.
            
            So that is why there is only 1 bug left, the lack of true randomness in the game, which I will tackel soon,
            
            till then, randomness is archieved by changing the following :
                
                * Board hehight
                * Board width
                * Number of formations in the config (using IsActive flag)
                * The order of those formations in the config
                * The Game Matrix Formation Height Margin (randomness occures much later generations)
                * The Game Matrix Formation width Margin (randomness occures much later generations)
                * The creation of new formations, the coolest way yet.
         */

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

            serviceCollection.AddOptions();
            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);
            serviceCollection.AddTransient<IFormation, Formation>();

            serviceCollection.Configure<GameSettings>(configuration.GetSection("GameSettings"));

            serviceCollection.AddTransient<IActiveFormation, ActiveFormation>();
            serviceCollection.AddTransient<ICell, Cell>();
            serviceCollection.AddTransient<ICellPosition, CellPosition>();
            serviceCollection.AddSingleton<IGameBoard, GameBoard>();
            serviceCollection.AddSingleton<IGameEngine, GameEngine>();
            serviceCollection.AddTransient<IGameUiDrawer, Piccasso>();
            serviceCollection.AddTransient<IActiveFormation, ActiveFormation>();
            serviceCollection.AddTransient<IInstruction, Instruction>();
            serviceCollection.AddTransient<IMatrix, TheMatrix>();
            serviceCollection.AddSingleton<IToolBox, ToolBox>();


            serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
