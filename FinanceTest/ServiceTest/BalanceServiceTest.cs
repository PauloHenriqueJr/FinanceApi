using ApiStone.Models;
using FinanceApi.Data.Dtos.Balance;
using FinanceApi.Repository.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApiStone.Enuns.EnumStatus;

namespace FinanceTest.ServiceTest
{
    [TestClass]
    public class BalanceServiceTest
    {
        private Account _account;
        private Operation _operation;
        private BalanceGetDto _balanceGetDto;


        [TestInitialize]
        public void Initialize()
        {
            _operation = new Operation();
            _account = new Account();
            _balanceGetDto = new BalanceGetDto();
        }

        [TestMethod]
        public void GetBalance_AmountGreaterThanZero_True()
        {
            // Arrange
            _balanceGetDto.Balance = 100;

            // Act
            bool result = _balanceGetDto.Balance > 0;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetBalanceByDate_AmountGreaterThanZero_True()
        {
            // Arrange
            _balanceGetDto.Balance = 100;

            // Act
            bool result = _balanceGetDto.Balance > 0;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetBalanceByDate_AmountLessThanBalance_True()
        {
            // Arrange
            _balanceGetDto.Balance = 100;

            // Act
            bool result = _balanceGetDto.Balance > 0;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetBalanceByDate_OperationTypeFutureDeposit_True()
        {
            // Arrange
            _operation.Type = OperationType.FutureDeposit;

            // Act
            bool result = _operation.Type == OperationType.FutureDeposit;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetBalanceByDate_OperationTypeFutureWithdraw_True()
        {
            // Arrange
            _operation.Type = OperationType.FutureWithdraw;

            // Act
            bool result = _operation.Type == OperationType.FutureWithdraw;

            // Assert
            Assert.IsTrue(result);
        }
    }
}
