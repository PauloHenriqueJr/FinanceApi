using ApiStone.Data.Dtos.Statement;
using ApiStone.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiStone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatementController : ControllerBase
    {
        private readonly StatementService _statementService;
        private readonly AccountService _accountService;

        public StatementController(StatementService statementService, AccountService accountService)
        {
            _statementService = statementService;
            _accountService = accountService;
        }

        [HttpGet("/statement/{id}")] //busca um extrato com uma lista de operações 
        public IActionResult GetStatementById(int id)
        {
            var result = _statementService.GetStatementById(id); //busca o extrato pelo id
            if (result == null) return NotFound(); //se o extrato não for encontrado retorna um NotFound com a mensagem de erro
            return Ok(result); //se o extrato for encontrado retorna um Ok com o ReadStatementDto
        }


        [HttpGet("/statement/{id}/{date}")] // retorna um extrato de uma conta por data
        public ActionResult<ReadStatementDto> GetStatementByDate(int id, string date)
        {
            var account = _accountService.GetAccountById(id); // busca a conta pelo id informado no extrato e retorna um Result<ReadAccountDto>
            if (account.IsFailed) return BadRequest(account.Errors); // se a conta não existir retorna um BadRequest com a mensagem de erro
            var statement = _statementService.GetStatementByDate(id, date); // se a conta existir, busca o extrato da conta e retorna um Result<ReadStatementDto>
            if (statement.IsFailed) return BadRequest(statement.Errors); // se o extrato não for encontrado retorna um BadRequest com a mensagem de erro
            return Ok(statement.Value); // se o extrato for encontrado retorna um Ok com o ReadStatementDto
        }

        // retorna varios extratos por periodo
        [HttpGet("/statement/{id}/{startDate}/{endDate}")]
        public ActionResult<ReadStatementDto> GetStatementByPeriod(int id, string startDate, string endDate)
        {
            var account = _accountService.GetAccountById(id); // busca a conta pelo id informado no extrato e retorna um Result<ReadAccountDto>
            if (account.IsFailed) return BadRequest(account.Errors); // se a conta não existir retorna um BadRequest com a mensagem de erro
            var statement = _statementService.GetStatementByPeriod(id, startDate, endDate); // se a conta existir, busca o extrato da conta e retorna um Result<ReadStatementDto>
            if (statement.IsFailed) return BadRequest(statement.Errors); // se o extrato não for encontrado retorna um BadRequest com a mensagem de erro
            return Ok(statement.Value); // se o extrato for encontrado retorna um Ok com o ReadStatementDto
        }

        [HttpGet("/statement/{id}/{date}/{type}")] // retorna um extrato de uma conta por data e tipo
        public ActionResult<ReadStatementDto> GetStatementByDateAndType(int id, string date, [FromQuery] string type)
        {
            var account = _accountService.GetAccountById(id); // busca a conta pelo id informado no extrato e retorna um Result<ReadAccountDto>
            if (account.IsFailed) return BadRequest(account.Errors); // se a conta não existir retorna um BadRequest com a mensagem de erro
            var statement = _statementService.GetStatementByDateAndType(id, date, type); // se a conta existir, busca o extrato da conta e retorna um Result<ReadStatementDto>
            if (statement.IsFailed) return BadRequest(statement.Errors); // se o extrato não for encontrado retorna um BadRequest com a mensagem de erro
            return Ok(statement.Value); // se o extrato for encontrado retorna um Ok com o ReadStatementDto
        }

        [HttpPost("/statement")] // cria um extrato
        public ActionResult<ReadStatementDto> PostStatement(CreateStatementDto createStatementDto)
        {
            var account = _accountService.GetAccountById(createStatementDto.AccountId); // busca a conta pelo id informado no extrato e retorna um Result<ReadAccountDto>
            if (account.IsFailed) return BadRequest(account.Errors); // se a conta não existir retorna um BadRequest com a mensagem de erro
            var statement = _statementService.PostStatement(createStatementDto); // se a conta existir, cria o extrato e retorna um Result<ReadStatementDto>
            if (statement.IsFailed) return BadRequest(statement.Errors); // se o extrato não for criado retorna um BadRequest com a mensagem de erro
            return Ok(statement.Value); // se o extrato for criado retorna um Ok com o ReadStatementDto
        }
    }
}
