using FutureBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureBank.Services;

public class AccountService : IAccountService
{
    public async Task<BankAccount> CreateBankAccount(string customerName, int accountType)
    {
        return new BankAccount(customerName, accountType);
    }

    public async Task<SavingsAccount> CreateSavingsAccount(string customerName, int accountType)
    {
        return new SavingsAccount(customerName, accountType);
    }
    public async Task<string> CloseAccount(Guid accountNumber)
    {
        return $"Account: {accountNumber} has been successfully closed";
    }
}
