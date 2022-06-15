﻿using FutureBank.Services;
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

        public StartUp(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async void Init()
        {
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

            } else
            {
                newBankAccount = await _accountService.CreateBankAccount(accountName, accountTypeId);
            }

            var id = newSavingsAccount?.Id ?? newBankAccount?.Id;
            Console.WriteLine($"New Account opened: {id}");

            if (accountTypeId == 4) Console.WriteLine($"Interest Rate = {newSavingsAccount.InterestRate}%");

            Marketing _marketing = new Marketing();
            Console.WriteLine($"{_marketing.Onboard()}");

            OnlineBanking _olb = new OnlineBanking();
            Console.WriteLine($"{_olb.Onboard()}");

            Console.WriteLine("Thank you for joining us here at FutureBank! Where the future, is now.");

            Thread.Sleep(10000);

            Environment.Exit(0);

        }

        //Private methods can only be referenced by the class they are in
        //A static class cannot be instantiated. In other words, you cannot use the new operator to create a variable of the class type.
        private static string GetAccountName()
        {
            Console.WriteLine("Welcome to the Bank of the Future!");
            Console.WriteLine("Please enter the name you would like on your account...");

            var accountName = Console.ReadLine().Trim();
            if (accountName == null)
            {
                Console.WriteLine("Oops, try that again! value can't be empty. How would we know who owes us money?");
                accountName = Console.ReadLine().Trim();
            }

            return accountName ?? "Not Given";
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