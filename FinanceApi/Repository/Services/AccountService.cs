﻿using ApiStone.Data;
using ApiStone.Data.Dtos.Account;
using ApiStone.Data.Dtos.Deposit;
using ApiStone.Data.Dtos.Operation;
using ApiStone.Data.Dtos.Withdraw;
using ApiStone.Models;
using AutoMapper;
using FinanceApi.Data.Dtos.Balance;
using FinanceApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using static ApiStone.Enuns.EnumStatus;

namespace FinanceApi.Repository.Services
{
    public class AccountService : IAccountService
    {
        #region Properties
        private readonly FinanceDbContext _context;
        private readonly IMapper _mapper;
        # endregion

        # region Constructor
        public AccountService(FinanceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion Constructor

        #region Account Methods

        #region PostAccount
        /// <summary>
        /// Method to create a new account
        /// </summary>
        /// <param name="accountPostDto"></param>
        /// <returns></returns>
        public async Task<AccountGetDto> PostAccountAsync(AccountPostDto accountPostDto)
        {
            var account = _mapper.Map<Account>(accountPostDto);
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return _mapper.Map<AccountGetDto>(account);

        }

        #endregion PostAccount

        #region GetAllAccounts

        /// <summary>
        /// Method to get all accounts
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AccountGetDto>> GetAllAccountsAsync()
        {
            var accounts = await _context.Accounts.ToListAsync();
            return _mapper.Map<IEnumerable<AccountGetDto>>(accounts);
        }

        #endregion GetAllAccounts

        #region GetAllAccount By Id

        /// <summary>
        /// Method to get account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AccountGetDto> GetAccountAsync(int id)
        {
            Account? account = await GetAccount(id);
            return _mapper.Map<AccountGetDto>(account);
        }


        #endregion GetAllAccount By Id

        #region PutAccount By Id

        /// <summary>
        /// Method to update an account by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountPutDto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AccountGetDto> PutAccountAsync(int id, AccountPutDto accountPutDto)
        {
            Account? account = await GetAccount(id);
            _mapper.Map(accountPutDto, account);
            await _context.SaveChangesAsync();
            return _mapper.Map<AccountGetDto>(account);
        }

        #endregion PutAccount By Id

        #region DeleteAccount By Id

        /// <summary>
        /// Method to delete and account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AccountGetDto> DeleteAccountAsync(int id)
        {
            Account? account = await GetAccount(id);
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return _mapper.Map<AccountGetDto>(account);
        }

        #endregion DeleteAccount By Id

        #endregion Account Methods


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