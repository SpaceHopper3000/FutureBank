using FutureBank.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FutureBank
{
    internal class Program
    {
        //Dependency Injection reduces the hard-coded dependencies among your classes by injecting those dependencies at run time instead of design time technically. 
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            services.AddSingleton<StartUp, StartUp>()
                    .BuildServiceProvider()
                    .GetService<StartUp>()
                    .Init();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAccountService, AccountService>();
        }
    }

}