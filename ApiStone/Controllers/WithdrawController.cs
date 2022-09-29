using ApiStone.Data.Dtos.Deposit;
using ApiStone.Data.Dtos.Withdraw;
using ApiStone.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiStone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WithdrawController : ControllerBase
    {
        private readonly WithdrawService _withdrawService;
        private readonly AccountService _accountService;

        public WithdrawController(WithdrawService withdrawService, AccountService accountService)
        {
            _withdrawService = withdrawService;
            _accountService = accountService;
        }

        [HttpPost("/withdraw/{id}")] // saca um valor da conta do cliente pelo id da conta e subtrai o balance
        public ActionResult<ReadWithdrawDto> PostWithdrawById(int id, [FromBody] CreateWithdrawDto withdrawDto)
        {
            var result = _withdrawService.PostWithdrawById(id, withdrawDto);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // lança um saque por data na conta do cliente 
        [HttpPost("/withdraw/date/{date}")]
        public ActionResult<ReadWithdrawDto> PostWithdrawByDate([FromBody] CreateWithdrawDto withdrawDto, string date)
        {
            var account = _accountService.GetAccountById(withdrawDto.AccountId); // busca a conta pelo id informado no saque e retorna um Result<ReadAccountDto>
            if (account.IsFailed) return BadRequest(account.Errors); // se a conta não existir retorna um BadRequest com a mensagem de erro
            var withdraw = _withdrawService.PostWithdrawByDate(withdrawDto, account, date); // se a conta existir, saca o valor da conta e retorna um Result<ReadWithdrawDto>
            if (withdraw.IsFailed) return BadRequest(withdraw.Errors); // se o saque não for realizado retorna um BadRequest com a mensagem de erro
            return Ok(withdraw.Value); // se o saque for realizado retorna um Ok com o ReadWithdrawDto
        }


        [HttpPost("/withdraw/date/{date}/{id}")]
        public ActionResult<ReadWithdrawDto> PostWithdrawByDateById(int id, [FromBody] CreateWithdrawDto withdrawDto, string date)
        {
            var withdraw = _withdrawService.PostWithdrawByDateById(id, withdrawDto, date); // saca o valor da conta pelo id da conta e retorna um Result<ReadWithdrawDto>
            if (withdraw.IsFailed) return BadRequest(withdraw.Errors); // se o saque não for realizado retorna um BadRequest com a mensagem de erro
            return Ok(withdraw.Value); // se o saque for realizado retorna um Ok com o ReadWithdrawDto
        }

        // busca saques futuros por período de data inicial e data final
        [HttpGet("/withdraw/date/{dateInitial}/{dateFinal}/{id}")]
        public ActionResult<ReadWithdrawDto> GetWithdrawByPeriod(int id, string dateInitial, string dateFinal)
        {
            var withdraw = _withdrawService.GetWithdrawByPeriod(id, dateInitial, dateFinal); // busca os saques futuros pelo id da conta e retorna um Result<ReadWithdrawDto>
            if (withdraw.IsFailed) return BadRequest(withdraw.Errors); // se a busca não for realizada retorna um BadRequest com a mensagem de erro
            return Ok(withdraw.Value); // se a busca for realizada retorna um Ok com o ReadWithdrawDto
        }


        [HttpGet("/withdraw")] // busca todos os saques
        public ActionResult<ReadWithdrawDto> GetAllWithdraws()
        {
            var withdraws = _withdrawService.GetAllWithdraws(); // busca todos os saques e retorna um Result<List<ReadWithdrawDto>>
            if (withdraws.IsFailed) return BadRequest(withdraws.Errors); // se não houver saques retorna um BadRequest com a mensagem de erro
            return Ok(withdraws.Value); // se houver saques retorna um Ok com a lista de ReadWithdrawDto
        }

        [HttpGet("/withdraw/{id}")] // busca um saque pelo id
        public ActionResult<ReadWithdrawDto> GetWithdraw(int id)
        {
            var withdraw = _withdrawService.GetWithdraw(id); // busca o saque pelo id e retorna um Result<ReadWithdrawDto>
            if (withdraw.IsFailed) return BadRequest(withdraw.Errors); // se o saque não for encontrado retorna um BadRequest com a mensagem de erro
            return Ok(withdraw.Value); // se o saque for encontrado retorna um Ok com o ReadWithdrawDto
        }

        [HttpGet("/withdraw/account/{id}")] // busca todos os saques de uma conta pelo id da conta
        public ActionResult<ReadWithdrawDto> GetWithdrawByAccountId(int id)
        {
            var withdraws = _withdrawService.GetWithdrawByAccountId(id); // busca os saques pelo id da conta e retorna um Result<List<ReadWithdrawDto>>
            if (withdraws.IsFailed) return BadRequest(withdraws.Errors); // se não houver saques retorna um BadRequest com a mensagem de erro
            return Ok(withdraws.Value); // se houver saques retorna um Ok com a lista de ReadWithdrawDto
        }
    }
}
