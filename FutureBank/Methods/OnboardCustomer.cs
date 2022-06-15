using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureBank.Methods
{
    //Abstraction:Method can only be used in an abstract class, and it does not have a body. The body is provided by the derived class (inherited from).
    abstract class OnboardCustomer
    {
        public abstract string Onboard();
    }

    //Polymorphism uses those methods to perform different tasks. This allows us to perform a single action in different ways.
    class Marketing : OnboardCustomer
    {
        public override string Onboard()
        {
            return "Successfully registered for Marketing";
        }
    }
    class OnlineBanking : OnboardCustomer
    {
        public override string Onboard()
        {
            return "Successfully registered for Online Banking";
        }
    }
}
