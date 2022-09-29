using ApiStone.Data;
using ApiStone.Data.Dtos.Account;
using ApiStone.Data.Dtos.Balance;
using ApiStone.Data.Dtos.Withdraw;
using ApiStone.Models;
using AutoMapper;
using FluentResults;

namespace ApiStone.Services
{
    public class WithdrawService
    {
        private readonly AccountDbContext _context;
        private readonly IMapper _mapper;

        public WithdrawService(AccountDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Método que saca um valor da conta do cliente
        /// </summary>
        /// <param name="withdrawDto"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        //public Result<ReadWithdrawDto> PostWithdrawById(CreateWithdrawDto withdrawDto, Result<ReadBalanceDto> balanceDto)
        //{
        //    var withdraw = _mapper.Map<Withdraw>(withdrawDto); // mapeia o CreateWithdrawDto para um Withdraw
        //    var balance = _mapper.Map<Balance>(balanceDto); // mapeia o ReadBalanceDto para um Balance

        //    if (balance == null) // se o balance não existir retorna um erro
        //    {
        //        return Result.Fail<ReadWithdrawDto>("Balance not found");
        //    }

        //    if (withdraw.Value > balance.Value) // se o valor do saque for maior que o saldo retorna um erro
        //    {
        //        return Result.Fail<ReadWithdrawDto>("Insufficient balance");
        //    }

        //    balance.Value -= withdraw.Value; // subtrai o valor do saque do saldo
        //    _context.Balances.Update(balance); // atualiza o saldo
        //    _context.Withdraws.Add(withdraw); // adiciona o saque
        //    _context.SaveChanges(); // salva as alterações

        //    return Result.Ok(_mapper.Map<ReadWithdrawDto>(withdraw)); // retorna o saque
        //}


        /// <summary>
        /// Método para realizar o saque de uma conta
        /// </summary>
        /// <param name="withdrawDto"></param>
        /// <param name="account"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public Result<ReadWithdrawDto> PostWithdrawByDate(CreateWithdrawDto withdrawDto, Result<ReadAccountDto> account, string date)
        {
            Result<ReadWithdrawDto> result = new Result<ReadWithdrawDto>();
            var withdraw = _mapper.Map<Withdraw>(withdrawDto);
            withdraw.Account = _mapper.Map<Account>(account.Value);
            withdraw.CreatedAt = DateTime.Parse(date);
            _context.Withdraws.Add(withdraw);
            _context.SaveChanges();
            return Result.Ok(_mapper.Map<ReadWithdrawDto>(withdraw));
        }

        /// <summary>
        /// Método para realizar um saque na conta de um cliente pelo id da conta e data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="withdrawDto"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public Result<ReadWithdrawDto> PostWithdrawByDateById(int id, CreateWithdrawDto withdrawDto, string date)
        {
            Result<ReadWithdrawDto> result = new Result<ReadWithdrawDto>();
            var withdraw = _context.Withdraws.Find(id);
            if (withdraw == null)
            {
                result.WithError(new Error("Saque não encontrado"));
                return result;
            }
            withdraw = _mapper.Map(withdrawDto, withdraw);
            withdraw.CreatedAt = DateTime.Parse(date);
            _context.SaveChanges();
            ReadWithdrawDto readWithdrawDto = _mapper.Map<ReadWithdrawDto>(withdraw);
            result.WithValue(readWithdrawDto);
            return result;
        }

        /// <summary>
        /// Retorna todos os saques
        /// </summary>
        /// <returns></returns>
        public Result<ReadWithdrawDto> GetAllWithdraws()
        {
            Result<ReadWithdrawDto> result = new Result<ReadWithdrawDto>();
            var withdraws = _context.Withdraws;
            if (withdraws == null)
            {
                result.WithError(new Error("Saque não encontrado"));
                return result;
            }
            ReadWithdrawDto readWithdrawDto = _mapper.Map<ReadWithdrawDto>(withdraws);
            result.WithValue(readWithdrawDto);
            return result;
        }

        /// <summary>
        /// Retorna um saque pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Result<ReadWithdrawDto> GetWithdraw(int id)
        {
            Result<ReadWithdrawDto> result = new Result<ReadWithdrawDto>();
            var withdraw = _context.Withdraws.Find(id);
            if (withdraw == null)
            {
                result.WithError(new Error("Saque não encontrado"));
                return result;
            }
            ReadWithdrawDto readWithdrawDto = _mapper.Map<ReadWithdrawDto>(withdraw);
            result.WithValue(readWithdrawDto);
            return result;
        }

        /// <summary>
        /// Busca saque por período de data (dd/mm/yy) e id da conta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateInitial"></param>
        /// <param name="dateFinal"></param>
        /// <returns></returns>
        public Result<ReadWithdrawDto> GetWithdrawByPeriod(int id, string dateInitial, string dateFinal)
        {
            Result<ReadWithdrawDto> result = new Result<ReadWithdrawDto>();
            var withdraws = _context.Withdraws.Where(x => x.AccountId == id && x.CreatedAt >= DateTime.Parse(dateInitial) && x.CreatedAt <= DateTime.Parse(dateFinal));

            if (withdraws == null)
            {
                result.WithError(new Error("Saque não encontrado"));
                return result;
            }
            ReadWithdrawDto readWithdrawDto = _mapper.Map<ReadWithdrawDto>(withdraws);
            result.WithValue(readWithdrawDto);
            return result;
        }

        /// <summary>
        /// Busca todos os saques de uma conta pelo id da conta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Result<ReadWithdrawDto> GetWithdrawByAccountId(int id)
        {
            Result<ReadWithdrawDto> result = new Result<ReadWithdrawDto>();
            var withdraws = _context.Withdraws.Where(x => x.AccountId == id);
            if (withdraws == null)
            {
                result.WithError(new Error("Saque não encontrado"));
                return result;
            }
            ReadWithdrawDto readWithdrawDto = _mapper.Map<ReadWithdrawDto>(withdraws);
            result.WithValue(readWithdrawDto);
            return result;
        }

        public Result<ReadWithdrawDto> PostWithdrawById(int id, CreateWithdrawDto withdrawDto)
        {
            Result<ReadBalanceDto> readBalance = new Result<ReadBalanceDto>();
            Result<ReadWithdrawDto> readWithdraw = new Result<ReadWithdrawDto>();

            
        }
    }
}
