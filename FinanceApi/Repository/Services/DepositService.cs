using ApiStone.Data;
using ApiStone.Data.Dtos.Deposit;
using ApiStone.Data.Dtos.Operation;
using ApiStone.Models;
using AutoMapper;
using FinanceApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using static ApiStone.Enuns.EnumStatus;

namespace FinanceApi.Repository.Services
{
    public class DepositService : IDepositService
    {
        private readonly FinanceDbContext _context;
        private readonly IMapper _mapper;

        public DepositService(FinanceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        /// <summary>
        /// Method to create a new deposit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="depositDto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<DepositGetDto> PostDepositAsync(int id, DepositPostDto depositDto)
        {
            Account? account = await GetAccount(id);

            if (depositDto.Amount <= 0) throw new Exception("The amount must be greater than zero");

            account.Balance += depositDto.Amount;
            var operation = _mapper.Map<Operation>(depositDto);
            operation.AccountId = id;
            operation.Type = OperationType.Deposit;
            operation.Status = OperationStatus.Executed;
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
            return _mapper.Map<DepositGetDto>(operation);

        }

        /// <summary>
        /// Method to create a new future deposit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="depositDto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<DepositGetDto> PostDepositByDateAsync(int id, DateTime date, DepositPostDto depositDto)
        {
            Account? account = await GetAccount(id);

            if (depositDto.Amount <= 0) throw new Exception("The amount must be greater than zero");

            else if (date < DateTime.Now) throw new Exception("The date must be greater than the current date");

            var operation = _mapper.Map<Operation>(depositDto);
            operation.AccountId = id;
            operation.Type = OperationType.FutureDeposit;
            operation.Status = OperationStatus.Scheduled;
            operation.ScheduledAt = date;

            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
            return _mapper.Map<DepositGetDto>(operation);

        }

        /// <summary>
        /// Method get account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<Account> GetAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Account not found");
            }

            return account;
        }
    }
}
