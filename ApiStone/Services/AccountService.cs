﻿using ApiStone.Data;
using ApiStone.Data.Dtos.Account;
using ApiStone.Data.Dtos.Deposit;
using ApiStone.Data.Dtos.Operation;
using ApiStone.Data.Dtos.Withdraw;
using ApiStone.Enuns;
using ApiStone.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using static ApiStone.Enuns.EnumStatus;

namespace ApiStone.Services
{
    public class AccountService : IAccountService
    {
        #region Properties
        private readonly AccountDbContext _context;
        private readonly IMapper _mapper;
        # endregion

        # region Constructor
        public AccountService(AccountDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Account Methods

        #region PostAccount
        public async Task<GetAccountDto> PostAccountAsync(PostAccountDto accountPostDto)
        {
            var account = _mapper.Map<Account>(accountPostDto);
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return _mapper.Map<GetAccountDto>(account);
        }

        #endregion PostAccount

        #region GetAllAccount By Id
        public async Task<GetAccountDto> GetAccountAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Conta não encontrada");
            }
            return _mapper.Map<GetAccountDto>(account);
        }

        #endregion GetAllAccount By Id

        #region GetAllAccounts
        public async Task<IEnumerable<GetAccountDto>> GetAllAccountsAsync()
        {
            var accounts = await _context.Accounts.ToListAsync();
            return _mapper.Map<IEnumerable<GetAccountDto>>(accounts);
        }

        #endregion GetAllAccounts

        #region PutAccount By Id

        public async Task<GetAccountDto> PutAccountAsync(int id, PutAccountDto accountPutDto)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Conta não encontrada");
            }
            _mapper.Map(accountPutDto, account);
            await _context.SaveChangesAsync();
            return _mapper.Map<GetAccountDto>(account);
        }

        #endregion PutAccount By Id

        #region DeleteAccount By Id

        public async Task<GetAccountDto> DeleteAccountAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Conta não encontrada");
            }
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return _mapper.Map<GetAccountDto>(account);
        }

        #endregion DeleteAccount By Id

        #endregion Account Methods

        #region Deposit Methods

        #region PostDeposit By Id
        public async Task<GetDepositDto> PostDepositAsync(int id, PostDepositDto depositDto)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Conta não encontrada");
            }
            else if (depositDto.Amount <= 0 || depositDto.Amount == null)
            {
                throw new Exception("Valor inválido");
            }

            else
            {
                account.Balance += depositDto.Amount;
                var operation = _mapper.Map<Operation>(depositDto);
                operation.AccountId = id;
                operation.Type = OperationType.Deposit;
                operation.Status = OperationStatus.Executed;
                await _context.Operations.AddAsync(operation);
                await _context.SaveChangesAsync();
                return _mapper.Map<GetDepositDto>(operation);
            }

        }

        #endregion PostDeposit By Id

        #region PostDeposit By Date
        public async Task<GetDepositDto> PostDepositByDateAsync(int id, DateTime date, PostDepositDto depositDto)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Conta não encontrada");
            }
            else if (depositDto.Amount <= 0 || depositDto.Amount == null)
            {
                throw new Exception("Valor inválido");
            }

            else
            {
               
                var operation = _mapper.Map<Operation>(depositDto);
                operation.AccountId = id;
                operation.Type = OperationType.FutureDeposit;
                operation.Status = OperationStatus.Scheduled;
                operation.ScheduledAt = date;

                await _context.Operations.AddAsync(operation);
                await _context.SaveChangesAsync();
                return _mapper.Map<GetDepositDto>(operation);
            }
        }

        #endregion PostDeposit By Date

        #region GetAllDeposits

        public async Task<IEnumerable<GetOperationDto>> GetAllOperationsAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Conta não encontrada");
            }
            var operations = await _context.Operations.Where(x => x.AccountId == id).ToListAsync();
            return _mapper.Map<IEnumerable<GetOperationDto>>(operations);
        }

        #endregion GetAllDeposits

        #region GetDeposit By Id
        public async Task<GetDepositDto> GetDepositAsync(int id)
        {
            var operation = await _context.Operations.FindAsync(id);
            if (operation == null)
            {
                throw new Exception("Operação não encontrada");
            }
            else if (operation.Type != OperationType.Deposit)
            {
                throw new Exception("Operação não é um depósito");
            }
            return _mapper.Map<GetDepositDto>(operation);
        }

        #endregion GetDeposit By Id

        #endregion Deposit Methods

        #region Withdraw Methods

        #region PostWithdraw By Id
        public async Task<GetWithdrawDto> PostWithdrawAsync(int id, PostWithdrawDto withdrawDto)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Account not found");
            }

            else if (withdrawDto.Amount <= 0 || withdrawDto.Amount == null)
            {
                throw new Exception("Amount invalid");
            }

            else if (account.Balance < withdrawDto.Amount)
            {
                throw new Exception("Insufficient funds");
            }

            else
            {
                account.Balance -= withdrawDto.Amount;
                var operation = _mapper.Map<Operation>(withdrawDto);
                operation.AccountId = id;
                operation.Type = OperationType.Withdraw;
                operation.Status = OperationStatus.Executed;
                await _context.Operations.AddAsync(operation);
                await _context.SaveChangesAsync();
                return _mapper.Map<GetWithdrawDto>(operation);
            }

        }

        #endregion PostWithdraw By Id

        #region PostWithdraw By Date

        public async Task<GetWithdrawDto> PostWithdrawByDateAsync(int id, DateTime date, PostWithdrawDto withdrawDto)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Account not found");
            }

            else if (withdrawDto.Amount <= 0 || withdrawDto.Amount == null)
            {
                throw new Exception("Amount invalid");
            }

            else if (account.Balance < withdrawDto.Amount)
            {
                throw new Exception("Insufficient funds");
            }

            else
            {
                var operation = _mapper.Map<Operation>(withdrawDto);
                operation.AccountId = id;
                operation.Type = OperationType.FutureWithdraw;
                operation.Status = OperationStatus.Scheduled;
                operation.ScheduledAt = date;
                await _context.Operations.AddAsync(operation);
                await _context.SaveChangesAsync();
                return _mapper.Map<GetWithdrawDto>(operation);
            }

        }

        #endregion PostWithdraw By Date

        #region GetWithdraw By Id

        public async Task<GetWithdrawDto> GetWithdrawAsync(int id)
        {
            var operation = await _context.Operations.FindAsync(id);
            if (operation == null)
            {
                throw new Exception("Operation not found");
            }
            else if (operation.Type != OperationType.Withdraw)
            {
                throw new Exception("Operation is not a withdraw");
            }
            return _mapper.Map<GetWithdrawDto>(operation);
        }

        #endregion GetWithdraw By Id

        #endregion Withdraw Methods

        #region Balance Methods

        #region GetBalance By Id
        public async Task<AccountBalanceGetDto> GetBalanceAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Account not found");
            }

            return _mapper.Map<AccountBalanceGetDto>(account);

        }

        #endregion GetBalance By Id

        #region GetBalance By Date

        public async Task<AccountBalanceGetDto> GetBalanceByDateAsync(int id, DateTime date)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Account not found");
            }

            var operations = await _context.Operations.Where(x => x.AccountId == id).ToListAsync();
            foreach (var operation in operations)
            {
                if (operation.ScheduledAt <= date) // Se a data da operação for menor ou igual a data passada por parâmetro
                {
                    if (operation.Type == OperationType.FutureDeposit) // Se a operação for um depósito futuro 
                    {
                        account.Balance += operation.Amount; // Adiciona o valor do depósito ao saldo
                        operation.Status = OperationStatus.Executed; // Muda o status da operação para executado
                    }
                    else if (operation.Type == OperationType.FutureWithdraw) // Se a operação for um saque futuro
                    {
                        account.Balance -= operation.Amount; // Subtrai o valor do saque do saldo
                        operation.Status = OperationStatus.Executed; // Muda o status da operação para executado
                    }
                } 
            }

            return _mapper.Map<AccountBalanceGetDto>(account);

        }

        #endregion GetBalance By Date

        #endregion Balance Methods


    }
}