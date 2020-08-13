using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ozow.Sorting
{
    class Program
    {
        public static IConfigurationRoot configuration;

        public static IServiceProvider serviceProvider;

        //public static Dictionary<double, Alphabet> alphabets;
        static int Main(string[] args)
        {

            try
            {
                Run(args);
                Console.ReadKey();
                return 0;
            }
            catch(Exception ex)
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

            IAlphabetMachine alphabetMachine = serviceProvider.GetService<IAlphabetMachine>();

            Alphabet tempAlphabet;

            // Create alphabet list
            foreach (char @char in rawString)
            {
                tempAlphabet = alphabetMachine.CreateAlphabet(@char);
                alphabetMachine.AddAlphabet(tempAlphabet);
            }

            // Get output string from alphabet list
            string outputString = alphabetMachine.GetOutPutString();

            Console.WriteLine($"Ouput: {outputString}");

        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("AppSettings.json", false)
                        .Build();

            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);

            serviceCollection.AddTransient<IAlphabetMachine, AlphabetMachine>();
            serviceCollection.AddTransient<Alphabet>();

            serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
