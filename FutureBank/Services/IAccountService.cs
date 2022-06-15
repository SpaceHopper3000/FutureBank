using FutureBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureBank.Services
{
    //By default, members of an interface are abstract and public.
    //Interfaces can contain properties and methods, but not fields.
    //Interfaces must implement all methods
    public interface IAccountService
    {
        Task<BankAccount> CreateBankAccount(string customerName, int accountTypeId);
        Task<SavingsAccount> CreateSavingsAccount(string customerName, int accountTypeId);
        Task<string> CloseAccount(Guid accountNumber);
    }
}
