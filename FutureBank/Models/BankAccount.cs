using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureBank.Models
{
    public class BankAccount
    {
        //Constructer to allow application to pass in Customer Name in every instantiation
        public BankAccount(string customerName, int accountTypeId)
        {
            CustomerName = customerName;
            AccountType = accountTypeId;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public decimal Balance { get; set; } = 0;
        public bool WithdrawalsAllowed { get; set; }
        public int AccountType { get; set; }
    }
}
