using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureBank.Models
{
    //Derived Class (child) - the class that inherits from another class (in this case Bank Account)
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string customerName, int accountTypeId) : base(customerName, accountTypeId)
        {
        }

        public double InterestRate { get; set; } = 2.5;

        public bool NegativeBalAllowed { get; set; } = false;
    }
}
