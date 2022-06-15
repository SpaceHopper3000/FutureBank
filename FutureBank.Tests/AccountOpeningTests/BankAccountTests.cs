using System.Threading.Tasks;
using FutureBank.Models;
using FutureBank.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NuGet.Frameworks;

namespace FutureBank.Tests.AccountOpeningTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Account_Opened_NameMatchesParameters()
        {
            const string customerName = "Mr Test";
            const int accountTypeId = 1;
            var expectedResult = new BankAccount(customerName, accountTypeId);

            //Arrange
            var sut = new AccountService();

            //Act
            var accountOpeningTask = sut.CreateBankAccount(customerName, accountTypeId);

            //Assert
            Assert.IsNotNull(accountOpeningTask.Result);
            Assert.AreEqual(expectedResult.CustomerName, accountOpeningTask.Result.CustomerName);
        }
    }
}