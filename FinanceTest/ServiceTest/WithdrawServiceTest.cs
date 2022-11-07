using ApiStone.Data.Dtos.Withdraw;
using ApiStone.Models;
using AutoMapper;
using FinanceApi.Repository.Interfaces;
using Moq;
using static ApiStone.Enuns.EnumStatus;

namespace FinanceTest.ServiceTest
{
    [TestClass]
    public class WithdrawServiceTest
    {
        private Mock<IMapper> _mapper;
        private Mock<IWithdrawService> _withdrawService;

        [TestInitialize]
        public void Initialize()
        {
            _mapper = new Mock<IMapper>();
            _withdrawService = new Mock<IWithdrawService>();

            _withdrawService.Setup(x => x.CreateWithdrawAsync(It.IsAny<int>(), It.IsAny<WithdrawPostDto>()))
                .ReturnsAsync(new WithdrawGetDto
                {
                    Id = 1,
                    AccountId = 1,
                    Amount = 100,
                    CreatedAt = DateTime.Now,
                    Description = "description example: withdraw",
                    Status = OperationStatus.Executed,
                    Type = OperationType.Withdraw
                });

            _withdrawService.Setup(x => x.CreateWithdrawByDateAsync(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<WithdrawPostDto>()))
                .ReturnsAsync(new WithdrawGetDto
                {
                    Id = 1,
                    AccountId = 1,
                    Amount = 100,
                    CreatedAt = DateTime.Now,
                    Description = "description example: future withdraw",
                    ScheduledAt = DateTime.Now.AddDays(1),
                    Status = OperationStatus.Scheduled,
                    Type = OperationType.FutureWithdraw
                });
        }

        [TestMethod("Create Withdraw")]
        public async Task CreateWithdrawAsync_ShouldReturnWithdrawGetDto()
        {
            // Arrange

            // Act
            var result = await _withdrawService.Object.CreateWithdrawAsync(1, new WithdrawPostDto());

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(1, result.AccountId);
            Assert.AreEqual(100, result.Amount);
            Assert.AreEqual("description example: withdraw", result.Description);
            Assert.AreEqual(OperationStatus.Executed, result.Status);
            Assert.AreEqual(OperationType.Withdraw, result.Type);
        }

        [TestMethod("Create a withdraw with scheduled date")]
        public async Task CreateWithdrawByDateAsync_ShouldReturnWithdrawGetDto()
        {
            // Arrange
            var date = DateTime.Now.AddDays(1);
            // Act
            var result = await _withdrawService.Object.CreateWithdrawByDateAsync(1, date, new WithdrawPostDto());

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(1, result.AccountId);
            Assert.AreEqual(100, result.Amount);
            Assert.AreEqual("description example: future withdraw", result.Description);
            Assert.AreEqual(OperationStatus.Scheduled, result.Status);
            Assert.AreEqual(OperationType.FutureWithdraw, result.Type);
        }

    }
}