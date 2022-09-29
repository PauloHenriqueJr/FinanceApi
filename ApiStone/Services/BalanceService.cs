using ApiStone.Data;
using ApiStone.Data.Dtos.Account;
using ApiStone.Data.Dtos.Balance;
using ApiStone.Data.Dtos.Withdraw;
using ApiStone.Models;
using AutoMapper;
using FluentResults;

namespace ApiStone.Services
{
    public class BalanceService
    {
        private readonly AccountDbContext _context;
        private readonly IMapper _mapper;

        public BalanceService(AccountDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna o saldo de uma conta bancária específica 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Result<ReadBalanceDto> GetBalance(int id)
        {
            Result<ReadBalanceDto> result = new Result<ReadBalanceDto>();
            var account = _context.Accounts.Find(id);
            double balance = 0;
            foreach (var deposit in account.Deposits) // Depositos da conta 
            {
                balance += deposit.Value;
            }
            foreach (var withdraw in account.Withdraws) // Percorre os saques da conta e 
            {
                balance -= withdraw.Value;
            }

            ReadBalanceDto readBalanceDto = new ReadBalanceDto(); // Instanciando o objeto de retorno
            readBalanceDto.Value = balance;
            readBalanceDto.AccountId = account.Id;
            readBalanceDto.CreatedAt = account.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss");
            readBalanceDto.Id = account.Id;
            result.WithValue(readBalanceDto);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public Result<ReadBalanceDto> GetBalanceByDate(int id, string date)
        {
            Result<ReadBalanceDto> result = new Result<ReadBalanceDto>();
            var account = _context.Accounts.Find(id);
            double balance = 0;
            foreach (var deposit in account.Deposits)
            {
                if (deposit.CreatedAt <= DateTime.Parse(date)) // se a data do deposito for menor ou igual a data passada por parametro adiciona o valor do deposito no saldo
                {
                    balance += deposit.Value; // 
                }
            }
            foreach (var withdraw in account.Withdraws) // para cada saque da conta
            {
                if (withdraw.CreatedAt <= DateTime.Parse(date)) // se a data do saque for menor ou igual a data passada por parametro
                {
                    balance -= withdraw.Value;
                }
            }
            
            ReadBalanceDto readBalanceDto = new ReadBalanceDto(); // 
            readBalanceDto.Value = balance;
            readBalanceDto.AccountId = account.Id;
            readBalanceDto.CreatedAt = account.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss");
            readBalanceDto.Id = account.Id;
            result.WithValue(readBalanceDto);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public Result<ReadBalanceDto> GetBalanceByPeriod(int id, string date1, string date2)
        {
            Result<ReadBalanceDto> result = new Result<ReadBalanceDto>();
            var account = _context.Accounts.Find(id);
            double balance = 0;
            foreach (var deposit in account.Deposits)
            {
                if (deposit.CreatedAt >= DateTime.Parse(date1) && deposit.CreatedAt <= DateTime.Parse(date2)) // se a data do deposito for maior ou igual a data1 e menor ou igual a data2
                {
                    balance += deposit.Value;
                }
            }
            foreach (var withdraw in account.Withdraws)
            {
                if (withdraw.CreatedAt >= DateTime.Parse(date1) && withdraw.CreatedAt <= DateTime.Parse(date2))
                {
                    balance -= withdraw.Value;
                }
            }

            ReadBalanceDto readBalanceDto = new ReadBalanceDto();
            readBalanceDto.Value = balance;
            readBalanceDto.AccountId = account.Id;
            readBalanceDto.CreatedAt = account.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss");
            readBalanceDto.Id = account.Id;
            result.WithValue(readBalanceDto);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="balanceDto"></param>
        /// <returns></returns>
        public Result<ReadBalanceDto> UpdateBalance(int id, UpdateBalanceDto balanceDto)
        {
            Result<ReadBalanceDto> result = new Result<ReadBalanceDto>();
            var account = _context.Accounts.Find(id);
            if (account == null)
            {
                result.WithError("Account not found");
                return result;
            }
            double balance = 0;
            foreach (var deposit in account.Deposits)
            {
                balance += deposit.Value;
            }
            foreach (var withdraw in account.Withdraws)
            {
                balance -= withdraw.Value;
            }
            balance += balanceDto.Value;
            ReadBalanceDto readBalanceDto = new ReadBalanceDto();
            readBalanceDto.Value = balance;
            result.WithValue(readBalanceDto);
            return result;
        }

    }
}
