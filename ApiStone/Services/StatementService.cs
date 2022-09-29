using ApiStone.Data;
using ApiStone.Data.Dtos.Balance;
using ApiStone.Data.Dtos.Statement;
using ApiStone.Models;
using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace ApiStone.Services
{
    public class StatementService
    {
        private AccountDbContext _context;
        private IMapper _mapper;

        public StatementService(AccountDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       

        // cria um extrato
        public Result<ReadStatementDto> PostStatement(CreateStatementDto statementDto)
        {
            var statement = _mapper.Map<Statement>(statementDto); // mapeia o CreateStatementDto para um Statement
            _context.Statements.Add(statement); // adiciona o extrato no contexto
            _context.SaveChanges(); // salva as alterações no banco de dados
            var readStatementDto = _mapper.Map<ReadStatementDto>(statement); // mapeia o Statement para um ReadStatementDto
            return Result.Ok(readStatementDto); // retorna um Result<ReadStatementDto> com o ReadStatementDto
        }

        // busca o saldo de uma conta
        public Result<ReadBalanceDto> GetBalance(int id)
        {
            var account = _context.Accounts.Find(id); // busca a conta pelo id no banco de dados
            if (account == null) return Result.Fail<ReadBalanceDto>("Conta não encontrada"); // retorna um Result<ReadBalanceDto> com uma mensagem de erro
            var balance = account.Balance; // pega o saldo da conta
            var readBalanceDto = _mapper.Map<ReadBalanceDto>(balance); // mapeia o Balance para um ReadBalanceDto
            return Result.Ok(readBalanceDto); // retorna um Result<ReadBalanceDto> com o ReadBalanceDto
        }

        // buscar statement por id da conta e id do statement 
        public Result<ReadStatementDto> GetStatementByDate(int id, string date)
        {
            var statement = _context.Statements.Find(id, date); //busca o statement pelo id e data
            if (statement == null) return Result.Fail<ReadStatementDto>("Statement not found"); //se o statement não for encontrado retorna um Result<ReadStatementDto> com a mensagem de erro
            return Result.Ok(_mapper.Map<ReadStatementDto>(statement)); //se o statement for encontrado retorna um Result<ReadStatementDto> com o ReadStatementDto
        }

        

        public Result<ReadStatementDto> GetStatementByDateAndType(int id, string date, string type)
        {
            var statement = _context.Statements.Find(id, date, type); //busca o statement pelo id, data e tipo
            if (statement == null) return Result.Fail<ReadStatementDto>("Statement not found"); //se o statement não for encontrado retorna um Result<ReadStatementDto> com a mensagem de erro
            return Result.Ok(_mapper.Map<ReadStatementDto>(statement)); //se o statement for encontrado retorna um Result<ReadStatementDto> com o ReadStatementDto
        }

        //buscando extrato por periodo de tempo
        public Result<ReadStatementDto> GetStatementByPeriod(int id, string startDate, string endDate)
        {
            var statement = _context.Statements.Find(id, startDate, endDate); //busca o statement pelo id, data inicial e data final
            if (statement == null) return Result.Fail<ReadStatementDto>("Statement not found"); //se o statement não for encontrado retorna um Result<ReadStatementDto> com a mensagem de erro
            return Result.Ok(_mapper.Map<ReadStatementDto>(statement)); //se o statement for encontrado retorna um Result<ReadStatementDto> com o ReadStatementDto
        }
        
        public List<ReadStatementDto> GetStatementById(int id)
        {
            var statement = _context.Statements.Where(s => s.AccountId == id).ToList(); //busca o statement pelo id da conta
            if (statement == null) return null; //se o statement não for encontrado retorna null
            return _mapper.Map<List<ReadStatementDto>>(statement); //se o statement for encontrado retorna um List<ReadStatementDto> com o ReadStatementDto
        }

    }
}
