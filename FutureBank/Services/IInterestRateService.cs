using FutureBank.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureBank.Services
{
    public interface IInterestRateService
    {
        Task<InterestRate> GetCurrentRate();
    }
}
