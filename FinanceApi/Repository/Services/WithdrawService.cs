﻿using ApiStone.Data;
using ApiStone.Data.Dtos.Withdraw;
using ApiStone.Models;
using AutoMapper;
using FinanceApi.Repository.Interfaces;
using static ApiStone.Enuns.EnumStatus;

namespace FinanceApi.Repository.Services
{
    public class WithdrawService:IWithdrawService
    {
        private readonly FinanceDbContext _context;
        private readonly IMapper _mapper;

        public WithdrawService(FinanceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Method to create new withdraw
        /// </summary>
        /// <param name="id"></param>
        /// <param name="withdrawDto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<WithdrawGetDto> CreateWithdrawAsync(int id, WithdrawPostDto withdrawDto)
        {
            Account? account = await GetAccount(id);
            Conditionals(withdrawDto, account);

            account.Balance -= withdrawDto.Amount;
            var operation = _mapper.Map<Operation>(withdrawDto);
            operation.AccountId = id;
            operation.Type = OperationType.Withdraw;
            operation.Status = OperationStatus.Executed;
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
            return _mapper.Map<WithdrawGetDto>(operation);

        }

        /// <summary>
        /// Method to create a new future withdraw
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="withdrawDto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<WithdrawGetDto> CreateWithdrawByDateAsync(int id, DateTime date, WithdrawPostDto withdrawDto)
        {
            Account? account = await GetAccount(id);
            Conditionals(withdrawDto, account);

            var operation = _mapper.Map<Operation>(withdrawDto);
            operation.AccountId = id;
            operation.Type = OperationType.FutureWithdraw;
            operation.Status = OperationStatus.Scheduled;
            operation.ScheduledAt = date;
            await _context.Operations.AddAsync(operation);
            await _context.SaveChangesAsync();
            return _mapper.Map<WithdrawGetDto>(operation);

        }

        private async Task<Account> GetAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Account not found");
            }

            return account;
        }
        private static void Conditionals(WithdrawPostDto withdrawDto, Account account)
        {
            if (withdrawDto.Amount <= 0) throw new Exception("Amount must be greater than zero");

            else if (account.Balance < withdrawDto.Amount) throw new Exception("Insufficient funds");
        }

    }
}
