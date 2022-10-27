using ApiStone.Data;
using ApiStone.Data.Dtos.Operation;
using ApiStone.Models;
using AutoMapper;
using FinanceApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using static ApiStone.Enuns.EnumStatus;

namespace FinanceApi.Repository.Services
{
    public class StatementService : IStatementService
    {
        private readonly FinanceDbContext _context;
        private readonly IMapper _mapper;

        public StatementService(FinanceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Method to get all operations
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<OperationGetDto>> GetAllOperationsAsync(int id)
        {
            Account? account = await GetAccount(id);

            var operations = await _context.Operations.Where(x => x.AccountId == id).ToListAsync();
            return _mapper.Map<IEnumerable<OperationGetDto>>(operations);
        }

        /// <summary>
        /// Method to get all operations by date
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<IEnumerable<OperationGetDto>> GetOperationByDateAsync(int id, DateTime date)
        {
            Account? account = await GetAccount(id);

            var operations = await _context.Operations.Where(x => x.AccountId == id && x.ScheduledAt == date).ToListAsync();
            return _mapper.Map<IEnumerable<OperationGetDto>>(operations);
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

    }
}