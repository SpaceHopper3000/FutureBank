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
            Thread.Sleep(5000);

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
            var baseAddress = new Uri("https://localhost:7143");

            services.AddSingleton<IAccountService, AccountService>();
            services.AddHttpClient<IInterestRateService, InterestRateService>(client => { client.BaseAddress = baseAddress; });
        }
    }
}