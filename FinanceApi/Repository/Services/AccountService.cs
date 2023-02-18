using ApiStone.Data;
using ApiStone.Data.Dtos.Account;
using ApiStone.Models;
using AutoMapper;
using FinanceApi.Helpers.Exceptions;
using FinanceApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanceApi.Repository.Services
{
    public class AccountService : IAccountService
    {

        private readonly FinanceDbContext _context;
        private readonly IMapper _mapper;

        public AccountService(FinanceDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        /// <summary>
        /// Method to create a new account
        /// </summary>
        /// <param name="accountPostDto"></param>
        /// <returns></returns>
        public async Task<AccountGetDto> PostAccountAsync(AccountPostDto accountPostDto)
        {
            if (accountPostDto == null)
            {
                throw new ArgumentNullException(nameof(accountPostDto), "AccountPostDto cannot be null");
            }

            Account? account = _mapper.Map<Account>(accountPostDto);
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return _mapper.Map<AccountGetDto>(account);
        }

        /// <summary>
        /// Method to get all accounts
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AccountGetDto>> GetAllAccountsAsync()
        {
            var accounts = await _context.Accounts.ToListAsync();
            return _mapper.Map<IEnumerable<AccountGetDto>>(accounts);
        }

        /// <summary>
        /// Method to get account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AccountGetDto> GetAccountAsync(int id)
        {
            Account? account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new AccountNotFoundException($"Account with id {id} not found");
            }
            return _mapper.Map<AccountGetDto>(account);
        }


        /// <summary>
        /// Method to update an account by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountPutDto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AccountGetDto> PutAccountAsync(int id, AccountPutDto accountPutDto)
        {
            if (accountPutDto == null)
            {
                throw new ArgumentNullException(nameof(accountPutDto), "AccountPutDto cannot be null");
            }

            Account? account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new AccountNotFoundException($"Account with id {id} not found");
            }
            _mapper.Map(accountPutDto, account);
            await _context.SaveChangesAsync();
            return _mapper.Map<AccountGetDto>(account);
        }

        /// <summary>
        /// Method to delete and account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AccountGetDto> DeleteAccountAsync(int id)
        {
            Account? account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new AccountNotFoundException($"Account with id {id} not found");
            }
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return _mapper.Map<AccountGetDto>(account);
        }

    }
}