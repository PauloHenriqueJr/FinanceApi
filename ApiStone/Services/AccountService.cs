using ApiStone.Data;
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
        public async Task<AccountGetDto> PostAccountAsync(AccountPostDto accountPostDto)
        {
            var account = _mapper.Map<Account>(accountPostDto);
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return _mapper.Map<AccountGetDto>(account);
        }

        #endregion PostAccount

        #region GetAllAccount By Id
        public async Task<AccountGetDto> GetAccountAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Conta não encontrada");
            }
            return _mapper.Map<AccountGetDto>(account);
        }

        #endregion GetAllAccount By Id

        #region GetAllAccounts
        public async Task<IEnumerable<AccountGetDto>> GetAllAccountsAsync()
        {
            var accounts = await _context.Accounts.ToListAsync();
            return _mapper.Map<IEnumerable<AccountGetDto>>(accounts);
        }

        #endregion GetAllAccounts

        #region PutAccount By Id

        public async Task<AccountGetDto> PutAccountAsync(int id, AccountPutDto accountPutDto)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Conta não encontrada");
            }
            _mapper.Map(accountPutDto, account);
            await _context.SaveChangesAsync();
            return _mapper.Map<AccountGetDto>(account);
        }

        #endregion PutAccount By Id

        #region DeleteAccount By Id

        public async Task<AccountGetDto> DeleteAccountAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Conta não encontrada");
            }
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return _mapper.Map<AccountGetDto>(account);
        }

        #endregion DeleteAccount By Id

        #endregion Account Methods

        #region Deposit Methods

        #region PostDeposit By Id
        public async Task<DepositGetDto> PostDepositAsync(int id, DepositPostDto depositDto)
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
                return _mapper.Map<DepositGetDto>(operation);
            }

        }

        #endregion PostDeposit By Id

        #region PostDeposit By Date
        public async Task<DepositGetDto> PostDepositByDateAsync(int id, DateTime date, DepositPostDto depositDto)
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
                return _mapper.Map<DepositGetDto>(operation);
            }
        }

        #endregion PostDeposit By Date

        #region GetDeposit By Id
        public async Task<DepositGetDto> GetDepositAsync(int id)
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
            return _mapper.Map<DepositGetDto>(operation);
        }

        #endregion GetDeposit By Id

        #endregion Deposit Methods

        #region Withdraw Methods

        #region PostWithdraw By Id
        public async Task<WithdrawGetDto> PostWithdrawAsync(int id, WithdrawPostDto withdrawDto)
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
                return _mapper.Map<WithdrawGetDto>(operation);
            }

        }

        #endregion PostWithdraw By Id

        #region PostWithdraw By Date

        public async Task<WithdrawGetDto> PostWithdrawByDateAsync(int id, DateTime date, WithdrawPostDto withdrawDto)
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
                return _mapper.Map<WithdrawGetDto>(operation);
            }

        }

        #endregion PostWithdraw By Date

        #region GetWithdraw By Id

        public async Task<WithdrawGetDto> GetWithdrawAsync(int id)
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
            return _mapper.Map<WithdrawGetDto>(operation);
        }

        #endregion GetWithdraw By Id

        #endregion Withdraw Methods

        #region Statement Methods

        #region GetAllOperations By Account Id

        public async Task<IEnumerable<OperationGetDto>> GetAllOperationsAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Account not found");
            }
            var operations = await _context.Operations.Where(x => x.AccountId == id).ToListAsync();
            return _mapper.Map<IEnumerable<OperationGetDto>>(operations);
        }

        #endregion GetAllOperations By Account Id

        #region GetOperations By Account Id And Date
        public async Task<IEnumerable<OperationGetDto>> GetOperationsByDateAsync(int id, DateTime date)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Account not found");
            }
            var operations = await _context.Operations.Where(x => x.AccountId == id && x.ScheduledAt == date).ToListAsync();
            return _mapper.Map<IEnumerable<OperationGetDto>>(operations);
        }

        #endregion GetOperations By Account Id And Date

        #endregion Statement Methods

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
