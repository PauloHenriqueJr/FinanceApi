using ApiStone.Data;
using ApiStone.Models;
using AutoMapper;
using FinanceApi.Data.Dtos.Balance;
using FinanceApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using static ApiStone.Enuns.EnumStatus;

namespace FinanceApi.Repository.Services
{
    public class BalanceService:IBalanceService
    {
        private readonly FinanceDbContext _context;
        private readonly IMapper _mapper;

        public BalanceService(FinanceDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Method to get balance by account id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BalanceGetDto> GetBalanceAsync(int id)
        {
            Account? account = await GetAccount(id);
            return _mapper.Map<BalanceGetDto>(account);
        }

        /// <summary>
        /// Method to get account by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<BalanceGetDto> GetBalanceByDateAsync(int id, DateTime date)
        {
            Account? account = await GetAccount(id);

            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var balance = account.Balance;
            var operations = await GetOperations(id, date);
            UpdateAccountBalance(account, operations);
            return _mapper.Map<BalanceGetDto>(account);

        }

        /// <summary>
        /// Method to get account by id
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

        /// <summary>
        /// Method to get all operations by account id and date
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        private async Task<List<Operation>> GetOperations(int id, DateTime date)
        {
            return await _context.Operations
                .Where(o => o.AccountId == id && o.ScheduledAt <= date)
                .ToListAsync();
        }

        /// <summary>
        /// Method to update account balance
        /// </summary>
        /// <param name="account"></param>
        /// <param name="operations"></param>
        private void UpdateAccountBalance(Account account, List<Operation> operations)
        {
            foreach (var operation in operations)
            {
                switch (operation.Type)
                {
                    case OperationType.FutureDeposit:
                        account.Balance += operation.Amount;
                        operation.Status = OperationStatus.Executed;
                        break;
                    case OperationType.FutureWithdraw:
                        account.Balance -= operation.Amount;
                        operation.Status = OperationStatus.Executed;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
