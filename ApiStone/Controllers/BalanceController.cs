using ApiStone.Data.Dtos.Account;
using ApiStone.Data.Dtos.Balance;
using ApiStone.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiStone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BalanceController:ControllerBase
    {
        private readonly BalanceService _balanceService;
        private readonly AccountService _accountService;

        public BalanceController(BalanceService balanceService, AccountService accountService)
        {
            _balanceService = balanceService;
            _accountService = accountService;
        }

        [HttpGet("/balance/{id}")] // retorna o saldo de uma conta
        public ActionResult<ReadBalanceDto> GetBalance(int id)
        {
            var account = _accountService.GetAccountById(id);
            if (account.IsFailed) return NotFound(account.Errors);
            var balance = _balanceService.GetBalance(id);
            if (balance.IsFailed) return NotFound(balance.Errors);
            return Ok(balance.Value);
        }

        [HttpPut("/balance/{id}")] // atualiza o saldo de uma conta
        public ActionResult<ReadBalanceDto> UpdateBalance(int id, UpdateBalanceDto balanceDto)
        {
            var account = _accountService.GetAccountById(id);
            if (account.IsFailed) return NotFound(account.Errors);
            var balance = _balanceService.UpdateBalance(id, balanceDto);
            if (balance.IsFailed) return BadRequest(balance.Errors);
            return Ok(balance.Value);
        }
    }
}
