using ApiStone.Data;
using ApiStone.Data.Dtos.Account;
using ApiStone.Data.Dtos.Balance;
using ApiStone.Data.Dtos.Deposit;
using ApiStone.Models;
using AutoMapper;
using FluentResults;
using MySqlX.XDevAPI.Common;
using System.Security.Principal;
using Result = FluentResults.Result;

namespace ApiStone.Services
{
    public class DepositService
    {
        private readonly AccountDbContext _context;
        private readonly IMapper _mapper;

        public DepositService(AccountDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Deposita um valor na conta do cliente pelo id da conta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="depositDto"></param>
        /// <returns></returns>
        public Result<ReadDepositDto> PostDepositById(int id, CreateDepositDto depositDto)
        {
            var account = _context.Accounts.Find(id);
            var deposit = _mapper.Map<Deposit>(depositDto);

            Result<ReadDepositDto> result = new Result<ReadDepositDto>();
            if (account == null)
            {
                result.WithError("Conta não encontrada");
                return result;
            }
            else if (deposit.Value <= 0)
            {
                result.WithError("Valor do depósito deve ser maior que zero");
                return result;
            }
            else
            {
                deposit.Account = account;
                _context.Deposits.Add(deposit);
                _context.SaveChanges();
                var readDepositDto = _mapper.Map<ReadDepositDto>(deposit);
                result.WithValue(readDepositDto);
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Result<List<ReadDepositDto>> GetDepositById(int id)
        {
            var account = _context.Accounts.Find(id); // busca a conta pelo id
            if (account == null) return Result.Fail<List<ReadDepositDto>>("Account not found"); // se a conta não existir retorna um erro
            var deposits = _context.Deposits.Where(d => d.Account.Id == id).ToList(); // busca todos os depositos da conta
            return Result.Ok(_mapper.Map<List<ReadDepositDto>>(deposits)); // mapeia a lista de depositos para uma lista de ReadDepositDto
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateInitial"></param>
        /// <param name="dateFinal"></param>
        /// <returns></returns>
        public List<ReadDepositDto> GetDepositByDate(int? id, string dateInitial, string dateFinal)
        {
            List<Deposit> deposits = new List<Deposit>(); // cria uma lista de depositos
            if (id != null) // se o id for diferente de null
            {
                deposits = _context.Deposits.Where(d => d.Account.Id == id && d.CreatedAt >= DateTime.Parse(dateInitial) && d.ClosedAt <= DateTime.Parse(dateFinal)).ToList(); // busca todos os depositos da conta pelo id e pela data
            }
            else // se o id for null
            {
                deposits = _context.Deposits.Where(d => d.CreatedAt >= DateTime.Parse(dateInitial) && d.ClosedAt <= DateTime.Parse(dateFinal)).ToList(); // busca todos os depositos pela data
            }

            try // tenta mapear os depositos para um ReadDepositDto
            {
                return _mapper.Map<List<ReadDepositDto>>(deposits);
            }
            catch (Exception e) // se não conseguir retorna null
            {
                return null;
            }
        }

        public Result DeleteDeposit(int id)
        {
            var deposit = _context.Deposits.Find(id); // busca o deposito pelo id
            if (deposit == null) return Result.Fail("Depósito não encontrado"); // se o deposito não existir retorna um erro
            _context.Deposits.Remove(deposit); // remove o deposito do contexto
            _context.SaveChanges(); // salva as alterações no banco de dados
            return Result.Ok(); // retorna um ok
        }

        public ReadAccountDto DeleteDepositsByAccountId(int id) // apenas para testes em desenvolvimento
        {
            Account account = _context.Accounts.Find(id);
            if (account == null) return null;
            foreach (var deposit in account.Deposits)
            {
                _context.Deposits.Remove(deposit);
            }
            _context.SaveChanges();
            ReadAccountDto readAccountDto = _mapper.Map<ReadAccountDto>(account);
            return readAccountDto;
        }

        public ReadDepositDto PostFutureDeposit(int id, CreateDepositDto depositDto)
        {
            var account = _context.Accounts.Find(id); // busca a conta pelo id
            if (account == null) return null; // se a conta não existir retorna null
            var deposit = _mapper.Map<Deposit>(depositDto); // mapeia o CreateDepositDto para um Deposit
            deposit.Account = account; // adiciona a conta no deposito
            _context.Deposits.Add(deposit); // adiciona o deposito no contexto
            _context.SaveChanges(); // salva as alterações no banco de dados
            return _mapper.Map<ReadDepositDto>(deposit); // mapeia o Deposit para um ReadDepositDto
        }
    }
}
