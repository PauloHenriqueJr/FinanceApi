using ApiStone.Data;
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
            _context = context;
            _mapper = mapper;
        }

        public async Task<BalanceGetDto> GetBalanceAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Account not found");
            }
            return _mapper.Map<BalanceGetDto>(account);
        }

        public async Task<BalanceGetDto> GetBalanceByDateAsync(int id, DateTime date)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                throw new Exception("Account not found");
            }
            var balance = account.Balance;
            var operations = await _context.Operations.Where(o => o.AccountId == id && o.ScheduledAt <= date).ToListAsync();
            foreach (var operation in operations)
            {
                if (operation.Type == OperationType.FutureDeposit)
                {
                    balance += operation.Amount;
                    operation.Status = OperationStatus.Executed;
                }
                else if (operation.Type == OperationType.FutureWithdraw)
                {
                    balance -= operation.Amount;
                    operation.Status = OperationStatus.Executed;
                }
            }
            account.Balance = balance;
            return _mapper.Map<BalanceGetDto>(account);
            
        }
    }
}
