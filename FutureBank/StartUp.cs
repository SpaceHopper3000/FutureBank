using FutureBank.Services;
using FutureBank.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutureBank.Methods;
using FutureBank.Models;

namespace FutureBank
{
    public class StartUp
    {
        private readonly IAccountService _accountService;
        private readonly IInterestRateService _interestRateService;

        public StartUp(IAccountService accountService, IInterestRateService interestRateService)
        {
            _accountService = accountService;
            _interestRateService = interestRateService;
        }

        public async void Init()
        {
            Console.WriteLine("Welcome to the Bank of the Future!");
            Console.WriteLine("Getting Interest Rate from Server..");

            //Cannot run Asynchronously as Main Thread kills the process upon completion
            var task = Task.Run(() => _interestRateService.GetCurrentRate());
            task.Wait();
            var rate = task.Result?.Rate;

            BankAccount? newBankAccount = null;
            SavingsAccount? newSavingsAccount = null;

            var accountName = GetAccountName();

            if (accountName == "Not Given")
            {
                Console.WriteLine("We've got no accounts available for ghosts i'm afraid. Good day.");
                return;
            }

            var accountTypeId = SelectAccountType();

            if (accountTypeId == 0)
            {
                Console.WriteLine("Looks like you didn't like the options so why don't you try another bank? No wait... don't go...");
                return;
            }

            var convertedEnum = (AccountTypeId)accountTypeId;
            Console.WriteLine($"Creating new {convertedEnum} for you...");

            if (accountTypeId == 4)
            {
                newSavingsAccount = await _accountService.CreateSavingsAccount(accountName, accountTypeId);

            }
            else
            {
                newBankAccount = await _accountService.CreateBankAccount(accountName, accountTypeId);
            }

            var id = newSavingsAccount?.Id ?? newBankAccount?.Id;
            Console.WriteLine($"New Account opened: {id}");

            if (accountTypeId == 4) Console.WriteLine($"Interest Rate = {rate}%");

            var marketing = new Marketing();
            Console.WriteLine($"{marketing.Onboard()}");

            var olb = new OnlineBanking();
            Console.WriteLine($"{olb.Onboard()}");

            Console.WriteLine("Thank you for joining us here at FutureBank! Where the future, is now.");

            Thread.Sleep(10000);

            Environment.Exit(0);

        }

        //Private methods can only be referenced by the class they are in
        //A static class cannot be instantiated. In other words, you cannot use the new operator to create a variable of the class type.
        private static string GetAccountName()
        {
            Console.WriteLine("Please enter the name you would like on your account...");

            var accountName = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(accountName))
            {
                Console.WriteLine("Oops, try that again! value can't be empty. How would we know who owes us money?");
                accountName = Console.ReadLine().Trim();
            }

            return string.IsNullOrEmpty(accountName) ? accountName : "Not Found";
        }

        private static int SelectAccountType()
        {
            Console.WriteLine("Please pick your Account Type...");

            Console.WriteLine($"1: {AccountTypeId.PremiumAccount}");
            Console.WriteLine($"2: {AccountTypeId.OkAccount}");
            Console.WriteLine($"3: {AccountTypeId.RubbishAccount}");
            Console.WriteLine($"4: {AccountTypeId.SuperSaverAccount}");

            var accountChoice = Console.ReadLine().Trim();
            bool valid = int.TryParse(accountChoice, out int result);

            return valid ? result : 0;
        }
    }

}