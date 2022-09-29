using ApiStone.Data.Dtos.Account;
using ApiStone.Data.Dtos.Deposit;
using ApiStone.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiStone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepositController : ControllerBase
    {
        private readonly DepositService _depositService;
        private readonly AccountService _accountService;
        public DepositController(DepositService depositService, AccountService accountService)
        {
            _depositService = depositService;
            _accountService = accountService;
        }


        [HttpPost("/deposit/{id}")] // deposita um valor na conta do cliente pelo id da conta
        public ActionResult<ReadDepositDto> PostDepositById(int id, [FromBody] CreateDepositDto depositDto)
        {
            var result = _depositService.PostDepositById(id, depositDto);
            if (result == null) return NotFound();
            return Ok();

        }

        // faz o deposito de um valor futuro na conta do cliente pelo cpf
        [HttpPost("/deposit/future/{id}")]
        public ActionResult PostFutureDeposit(int id, [FromBody] CreateDepositDto depositDto)
        {
            var result = _depositService.PostFutureDeposit(id, depositDto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("/deposit/{id}")] // busca um deposito pelo id
        public ActionResult<List<ReadDepositDto>> GetDepositById(int id)
        {
            var result = _depositService.GetDepositById(id);
            if (result == null) return NotFound("Nenhum deposito encontrado");
            return Ok(result.Value);
        }

        // busca um deposito pelo id da conta e data

        //[HttpGet("/deposit/{id}/date/{date}")]
        //public IActionResult GetDepositByDate(int id, [FromQuery] DateTime date)
        //{
        //    List<ReadDepositDto> readDto = _depositService.GetDepositByDate(id, date);
        //    if (readDto == null) return NotFound();
        //    return Ok(readDto);
        //}

        [HttpGet("/deposit/{id}/{dateInitial}/{dateFinal}")] // retorna um deposito pela data inicial e final
        public IActionResult GetDepositByDate(int id,[FromQuery] string dateInitial, [FromQuery] string dateFinal)
        {
            List<ReadDepositDto> readDto = _depositService.GetDepositByDate(id, dateInitial, dateFinal);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpDelete("/deposit/{id}")] // deleta um deposito pelo id
        public IActionResult DeleteDeposit(int id)
        {
            Result resultado = _depositService.DeleteDeposit(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("/deposit/account/{id}")] // deleta todos os depositos de uma conta pelo id da conta
        public IActionResult DeleteDepositsByAccountId(int id)
        {
            var result = _depositService.DeleteDepositsByAccountId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
