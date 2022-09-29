using ApiStone.Data.Dtos.Account;
using ApiStone.Models;
using ApiStone.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiStone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("/account")] // cria uma conta
        public IActionResult CreateAccount([FromBody] CreateAccountDto accountDto)
        {
            var result = _accountService.CreateAccount(accountDto);
            if (result == null) return NotFound();
            return Ok();
        }

        [HttpGet("/account")] // retorna todas as contas apenas para teste, não usado em produção
        public IActionResult GetAllAccounts()
        {
            var accounts = _accountService.GetAllAccounts();
            return Ok(accounts);
        }

        [HttpGet("/account/{id}")] // retorna uma conta
        public ActionResult<ReadAccountDto> GetAccountById(int id)
        {
            var account = _accountService.GetAccountById(id);
            if (account.IsFailed) return NotFound(account.Errors);
            return Ok(account.Value);
        }

        [HttpPut("/account/{id}")] // atualiza uma conta
        public ActionResult<ReadAccountDto> UpdateAccount(int id, [FromBody] UpdateAccountDto accountDto)
        {
            var account = _accountService.UpdateAccount(id, accountDto);
            if (account.IsFailed) return BadRequest(account.Errors);
            return Ok(account.Value);
        }

        [HttpDelete("/account/{id}")] // deleta uma conta
        public ActionResult<ReadAccountDto> DeleteAccount(int id)
        {
            var account = _accountService.DeleteAccount(id);
            if (account.IsFailed) return BadRequest(account.Errors);
            return Ok(account.Value);
        }

        

    }
}
