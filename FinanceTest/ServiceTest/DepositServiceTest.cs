using ApiStone.Data.Dtos.Deposit;
using ApiStone.Models;
using AutoMapper;
using FinanceApi.Repository.Interfaces;
using FinanceApi.Repository.Services;
using Moq;
using static ApiStone.Enuns.EnumStatus;

namespace FinanceTest.ServiceTest
{
    [TestClass]
    public class DepositServiceTest
    {
        private Mock<IMapper> _mapper;
        private Mock<IDepositService> _depositService;

        [TestInitialize]
        public void Initialize()
        {
            _mapper = new Mock<IMapper>();
            _depositService = new Mock<IDepositService>();

            _depositService.Setup(x => x.CreateDepositAsync(It.IsAny<int>(), It.IsAny<DepositPostDto>()))
                .ReturnsAsync(new DepositGetDto
                {
                    Id = 1,
                    AccountId = 1,
                    Amount = 100,
                    CreatedAt = DateTime.Now,
                    Description = "description example: deposit",
                    ScheduledAt = DateTime.Now,
                    Status = OperationStatus.Executed,
                    Type = OperationType.Deposit
                });

            _depositService.Setup(x => x.CreateDepositByDateAsync(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DepositPostDto>()))
                .ReturnsAsync(new DepositGetDto
                {
                    Id = 1,
                    AccountId = 1,
                    Amount = 100,
                    CreatedAt = DateTime.Now,
                    Description = "description example: future deposit",
                    ScheduledAt = DateTime.Now.AddDays(1),
                    Status = OperationStatus.Scheduled,
                    Type = OperationType.FutureDeposit
                });

        }


        [TestMethod("Create Deposit")]
        public async Task CreateDepositAsync_ShouldReturnDepositGetDto()
        {
            // Arrange
            
            
            // Act
            var result = await _depositService.Object.CreateDepositAsync(1, new DepositPostDto());

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(1, result.AccountId);
            Assert.AreEqual(100, result.Amount);
            Assert.AreEqual("description example: deposit", result.Description);
            Assert.AreEqual(OperationStatus.Executed, result.Status);
            Assert.AreEqual(OperationType.Deposit, result.Type);
            
        }

        [TestMethod("Create a deposit with a scheduled date")]
        public async Task CreateDepositByDateAsync_ShouldReturnDepositGetDto()
        {
            // Arrange
            var date = DateTime.Now.AddDays(1);

            // Act
            var result = await _depositService.Object.CreateDepositByDateAsync(1, date, new DepositPostDto());

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(1, result.AccountId);
            Assert.AreEqual(100, result.Amount);
            Assert.AreEqual("description example: future deposit", result.Description);
            Assert.AreEqual(OperationStatus.Scheduled, result.Status);
            Assert.AreEqual(OperationType.FutureDeposit, result.Type);

        }

    }
}