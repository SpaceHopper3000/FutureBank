using FutureBank.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json;

namespace FutureBank
{
    internal class Program
    {
        //Dependency Injection reduces the hard-coded dependencies among your classes by injecting those dependencies at run time instead of design time technically. 
        static void Main(string[] args)
        {
            //Wait for API project to load
            Thread.Sleep(10000);

            var services = new ServiceCollection();
            ConfigureServices(services);
            services.AddSingleton<StartUp, StartUp>()
                    .BuildServiceProvider()
                    .GetService<StartUp>()
                    .Init();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            //Base IIS P
            var baseAddress = new Uri("https://localhost:44347");

            services.AddSingleton<IAccountService, AccountService>();
            services.AddHttpClient<IInterestRateService, InterestRateService>(client => { client.BaseAddress = baseAddress; } );
        }
    }
}