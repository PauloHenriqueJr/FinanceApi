using ApiStone.Data.Dtos.Account;
using ApiStone.Data.Dtos.Deposit;
using ApiStone.Data.Dtos.Operation;
using ApiStone.Data.Dtos.Withdraw;
using ApiStone.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiStone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        #region Properties
        private AccountService _accountService;

        #endregion

        #region Constructor
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        #endregion


        #region Account Methods 
        
        [HttpPost("/account")] // cria uma conta
        public async Task<ActionResult> PostAccountAsync([FromBody] PostAccountDto accountPostDto)
        {
            try
            {
                var accountReadDto = await _accountService.PostAccountAsync(accountPostDto);
                return Ok(accountReadDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/account")] // retorna todas as contas apenas para teste, não usado em produção
        public async Task<IEnumerable<GetAccountDto>> GetAllAccountsAsync()
        {
            try
            {
                var accounts = await _accountService.GetAllAccountsAsync();
                return accounts;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet("/account/{id}")] // retorna uma conta
        public async Task<ActionResult> GetAccountAsync(int id)
        {
            try
            {
                var account = await _accountService.GetAccountAsync(id);
                return Ok(account);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut("/account/{id}")] // atualiza uma conta
        public async Task<ActionResult> PutAccountAsync(int id, [FromBody] PutAccountDto accountDto)
        {
            try
            {
                var result = await _accountService.PutAccountAsync(id, accountDto);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("/account/{id}")] // deleta uma conta
        public async Task<ActionResult> DeleteAccount(int id)
        {
            try
            {
                var result = await _accountService.DeleteAccountAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion Account Methods

        #region Deposit Methods
        
        #region Deposit Post
        [HttpPost("/deposit/{id}")] // deposita um valor na conta
        public async Task<ActionResult> PostDepositAsync(int id, [FromBody] PostDepositDto depositDto)
        {
            try
            {
                var result = await _accountService.PostDepositAsync(id, depositDto);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion Deposit Post

        #region Deposit Post By Date
        [HttpPost("/deposit-future/{id}")] // deposita um valor na conta por data especifica no formato yyyy-MM-dd na url
        public async Task<ActionResult> PostDepositByDateAsync(int id, [FromQuery] DateTime date, [FromBody] PostDepositDto depositDto)
        {
            try
            {
                var result = await _accountService.PostDepositByDateAsync(id, date, depositDto);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion Deposit Post By Date

        #region Deposit Get By Id

        [HttpGet("/deposit/{id}")] // retorna uma operação de deposito
        public async Task<ActionResult> GetDepositAsync(int id)
        {
            try
            {
                var result = await _accountService.GetDepositAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion Deposit Get By Id

        #endregion Deposit Methods

        #region Withdraw Methods

        #region Withdraw Post

        [HttpPost("/withdraw/{id}")] // saca um valor da conta
        public async Task<ActionResult> PostWithdrawAsync(int id, [FromBody] PostWithdrawDto withdrawDto)
        {
            try
            {
                var result = await _accountService.PostWithdrawAsync(id, withdrawDto);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion Withdraw Post

        #region Withdraw Post By Date

        [HttpPost("/withdraw-future/{id}")] // saca um valor da conta por data especifica no formato yyyy-MM-dd na url
        public async Task<ActionResult> PostWithdrawByDateAsync(int id, [FromQuery] DateTime date, [FromBody] PostWithdrawDto withdrawDto)
        {
            try
            {
                var result = await _accountService.PostWithdrawByDateAsync(id, date, withdrawDto);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion Withdraw Post By Date

        #region Withdraw Get By Id

        [HttpGet("/withdraw/{id}")] // retorna uma operação de saque
        public async Task<ActionResult> GetWithdrawAsync(int id)
        {
            try
            {
                var result = await _accountService.GetWithdrawAsync(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion Withdraw Get By Id

        #endregion Withdraw Methods

        #region Statement Methods

        #region Get Statement By Account Id
        
        [HttpGet("/statement/{id}")] // retorna todas as operações de deposito apenas para teste, não usado em produção
        public async Task<IEnumerable<GetOperationDto>> GetAllOperationsAsync(int id)
        {
            try
            {
                var operations = await _accountService.GetAllOperationsAsync(id);
                return operations;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion Get Statement By Account Id

        #endregion Statement Methods

        #region Balance Methods

        #region Get Balance By Account Id

        [HttpGet("/balance/{id}")] // retorna o saldo da conta
        public async Task<ActionResult> GetBalanceAsync(int id)
        {
            try
            {
                var balance = await _accountService.GetBalanceAsync(id);
                return Ok(balance);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion Get Balance By Account Id

        #region Get Balance By Account Id And Date

        [HttpGet("/balance-future/{id}")] // retorna o saldo da conta por data especifica no formato yyyy-MM-dd na url
        public async Task<ActionResult> GetBalanceByDateAsync(int id, [FromQuery] DateTime date)
        {
            try
            {
                var balance = await _accountService.GetBalanceByDateAsync(id, date);
                return Ok(balance);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        #endregion Get Balance By Account Id And Date

        #endregion Balance Methods
    }
}
