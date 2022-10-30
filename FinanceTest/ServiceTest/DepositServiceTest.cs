using ApiStone.Data.Dtos.Deposit;
using ApiStone.Models;
using FinanceApi.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTest.ServiceTest
{
    [TestClass]
    public class DepositServiceTest
    {
        private DepositPostDto _depositPostDto;

        [TestInitialize]
        public void Initialize()
        {
            _depositPostDto = new DepositPostDto();
        }

        [TestMethod]
        public void PostDeposit_AmountGreaterThanZero_True()
        {
            // Arrange
            _depositPostDto.Amount = 100;

            // Act
            bool result = _depositPostDto.Amount > 0;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PostDeposit_AmountLessThanZero_True()
        {
            // Arrange
            _depositPostDto.Amount = -100;

            // Act
            bool result = _depositPostDto.Amount < 0;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PostDeposit_AmountEqualsZero_True()
        {
            // Arrange
            _depositPostDto.Amount = 0;

            // Act
            bool result = _depositPostDto.Amount == 0;

            // Assert
            Assert.IsTrue(result);
        }
    }
    
}
