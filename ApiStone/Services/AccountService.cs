using ApiStone.Data;
using ApiStone.Data.Dtos.Account;
using ApiStone.Data.Dtos.Balance;
using ApiStone.Models;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiStone.Services
{
    public class AccountService
    {
        private AccountDbContext _context;
        private IMapper _mapper;
        public AccountService(AccountDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountDto"></param>
        /// <returns></returns>
        public ReadAccountDto CreateAccount(CreateAccountDto accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);
            _context.Accounts.Add(account);
            _context.SaveChanges();
            var readAccountDto = _mapper.Map<ReadAccountDto>(account);
            return readAccountDto;    
        }

        /// <summary>
        /// Buscar conta pelo id e buscar saldo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Result<ReadAccountDto> GetAccountById(int id)
        {
            var account = _context.Accounts.Find(id);
            if (account == null)
            {
                return Result.Fail<ReadAccountDto>("Conta não encontrada");
            }
            var readAccountDto = _mapper.Map<ReadAccountDto>(account);
            return Result.Ok(readAccountDto);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountDto"></param>
        /// <returns></returns>
        public Result<ReadAccountDto> UpdateAccount(int id, UpdateAccountDto accountDto)
        {
            Result<ReadAccountDto> result = new Result<ReadAccountDto>();
            var account = _context.Accounts.Find(id);
            if (account == null)
            {
                result.WithError(new Error("Conta não encontrada"));
                return result;
            }
            account.Name = accountDto.Name;
            _context.SaveChanges();
            ReadAccountDto readAccountDto = _mapper.Map<ReadAccountDto>(account);
            result.WithValue(readAccountDto);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Result<ReadAccountDto> DeleteAccount(int id)
        {
            Result<ReadAccountDto> result = new Result<ReadAccountDto>();
            var account = _context.Accounts.Find(id);
            if (account == null)
            {
                result.WithError(new Error("Conta não encontrada"));
                return result;
            }
            _context.Accounts.Remove(account);
            _context.SaveChanges();
            ReadAccountDto readAccountDto = _mapper.Map<ReadAccountDto>(account);
            result.WithValue(readAccountDto);
            return result;
        }

        public List<ReadAccountDto> GetAllAccounts()
        {
            List<Account> accounts = _context.Accounts.ToList();
            List<ReadAccountDto> readAccountDtos = _mapper.Map<List<ReadAccountDto>>(accounts);
            return readAccountDtos;
        }

        public Result<ReadBalanceDto> GetBalanceById(int id)
        {
            Result<ReadBalanceDto> result = new Result<ReadBalanceDto>();
            var account = _context.Accounts.Find(id);
            if (account == null)
            {
                result.WithError(new Error("Conta não encontrada"));
                return result;
            }
            var balance = _context.Balances.Find(id);
            if (balance == null)
            {
                result.WithError(new Error("Saldo não encontrado"));
                return result;
            }
            ReadBalanceDto readBalanceDto = _mapper.Map<ReadBalanceDto>(balance);
            result.WithValue(readBalanceDto);
            return result;
        }
    }
}
