using ApiStone.Data.Dtos.Withdraw;
using ApiStone.Models;

namespace FinanceTest.ServiceTest
{
    [TestClass]
    public class WithdrawServiceTest
    {
        private Account _account;
        private WithdrawPostDto _withdrawPostDto;

        [TestInitialize]
        public void Initialize()
        {
            _account = new Account();
            _withdrawPostDto = new WithdrawPostDto();
        }


        [TestMethod]
        public void PostWithdraw_AmountGreaterThanZero_True()
        {
            // Arrange
            _account.Balance = 1000;
            _withdrawPostDto.Amount = 100;

            // Act
            bool result = _withdrawPostDto.Amount > 0;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PostWithdraw_InsufficientBalance_True()
        {
            // Arrange
            _account.Balance = 1000;
            _withdrawPostDto.Amount = 2000;

            // Act
            bool result = _account.Balance < _withdrawPostDto.Amount;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PostWithdraw_AmountLessThanBalance_True()
        {
            // Arrange
            _account.Balance = 1000;
            _withdrawPostDto.Amount = 500;

            // Act
            bool result = _account.Balance >= _withdrawPostDto.Amount;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PostWithdraw_AmountLessThanBalanceAndGreaterThanZero_True()
        {
            // Arrange
            _account.Balance = 1000;
            _withdrawPostDto.Amount = 500;

            // Act
            bool result = _account.Balance >= _withdrawPostDto.Amount && _withdrawPostDto.Amount > 0;

            // Assert
            Assert.IsTrue(result);
        }
        

    }
}