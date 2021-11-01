using Microsoft.Extensions.DependencyInjection;
using System;


namespace TicTacToe
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        /// <summary>
        /// In main method services are registered and call initiategame method in Game class
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<Game>().InitiateGame();
            DisposeServices();
        }

        /// <summary>
        /// Register all required services in single method
        /// </summary>
        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<ICommon, Common>();
            services.AddTransient<IGame, Game>();
            services.AddTransient<IGameMove, GameMove>();
            services.AddTransient<IGameConsole, GameConsole>();
            services.AddTransient<Game>();
            _serviceProvider = services.BuildServiceProvider(true);
        }

        /// <summary>
        ///  Dispose of not requrired services
        /// </summary>
        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

    }
}
