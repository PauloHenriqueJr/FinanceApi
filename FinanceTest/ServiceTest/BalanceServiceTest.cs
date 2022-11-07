using ApiStone.Data.Dtos.Account;
using ApiStone.Models;
using AutoMapper;
using FinanceApi.Data.Dtos.Balance;
using FinanceApi.Repository.Interfaces;
using Moq;
using static ApiStone.Enuns.EnumStatus;

namespace FinanceTest.ServiceTest
{
    [TestClass]
    public class BalanceServiceTest
    {
        private readonly Mock<IBalanceService> _balanceServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IAccountService> _accountServiceMock;
        private readonly Mock<IOperationService> _operationServiceMock;

        public BalanceServiceTest()
        {
            _balanceServiceMock = new Mock<IBalanceService>();
            _mapperMock = new Mock<IMapper>();
            _accountServiceMock = new Mock<IAccountService>();
            _operationServiceMock = new Mock<IOperationService>();
        }

        [TestMethod("Get Balance")]
        public async Task GetBalanceAsync_ShouldReturnBalanceGetDto()
        {
            // Arrange
            var account = new Account
            {
                Id = 1,
                UserName = "Test",
                Balance = 1000
            };
            var balanceGetDto = new BalanceGetDto
            {
                AccountId = 1,
                Balance = 1000,
                CreatedAt = DateTime.Now
            };
            _accountServiceMock.Setup(x => x.GetAccountAsync(1)).ReturnsAsync(_mapperMock.Object.Map<AccountGetDto>(account));
            _balanceServiceMock.Setup(x => x.GetBalanceAsync(1)).ReturnsAsync(balanceGetDto);

            // Act
            var result = await _balanceServiceMock.Object.GetBalanceAsync(1);

            // Assert
            Assert.AreEqual(result, balanceGetDto);
            Assert.IsInstanceOfType(result, typeof(BalanceGetDto));
            Assert.AreEqual(result.AccountId, balanceGetDto.AccountId);

        }

    }
}