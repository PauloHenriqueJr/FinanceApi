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

        #region Account Post

        /// <summary>
        /// Create a new account 
        /// </summary>
        /// <param name="accountPostDto"></param>
        /// <returns>Create a new account</returns>
        [HttpPost("/account")] // cria uma conta
        public async Task<ActionResult> PostAccountAsync([FromBody] AccountPostDto accountPostDto)
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

        #endregion Account Post

        #region Account GetAll 

        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <returns>Get all accounts</returns>
        /// <remarks>This method is for only tests</remarks>
        [HttpGet("/account")] // retorna todas as contas apenas para teste, não usado em produção
        public async Task<IEnumerable<AccountGetDto>> GetAllAccountsAsync()
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

        #endregion Account GetAll

        #region Account Get By Id 

        /// <summary>
        /// Get an account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Get an account by id</returns>
        /// <remarks>Enter the id of the created account</remarks>
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

        #endregion Account Get By Id

        #region Account Put By Id

        /// <summary>
        /// Update an account by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountDto"></param>
        /// <returns>Update an account by id</returns>
        /// <remarks>Enter the id of the created account</remarks>
        [HttpPut("/account/{id}")] // atualiza uma conta
        public async Task<ActionResult> PutAccountAsync(int id, [FromBody] AccountPutDto accountDto)
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

        #endregion Account Put By Id

        #region Account Delete By Id

        /// <summary>
        /// Delete and account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete and account by id</returns>
        /// <remarks>Enter the id of the account you want to delete</remarks>
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

        #endregion Account Delete By Id

        #endregion Account Methods

        #region Deposit Methods

        #region Deposit Post

        /// <summary>
        /// Create a new deposit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="depositDto"></param>
        /// <returns>Create a new deposit</returns>
        /// <remarks>Insert the id of the account created in the header and other information in the body of the request</remarks>
        [HttpPost("/deposit/{id}")] // deposita um valor na conta
        public async Task<ActionResult> PostDepositAsync(int id, [FromBody] DepositPostDto depositDto)
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

        /// <summary>
        /// Create a new future deposit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="depositDto"></param>
        /// <returns>Create a new future deposit</returns>
        /// <remarks>Enter the created account id and deposit date in the header and other information in the request body</remarks>
        [HttpPost("/deposit-future/{id}")] // deposita um valor na conta por data especifica no formato yyyy-MM-dd na url
        public async Task<ActionResult> PostDepositByDateAsync(int id, [FromQuery] DateTime date, [FromBody] DepositPostDto depositDto)
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

        /// <summary>
        /// Get deposit by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Get deposit by id</returns>
        /// <remarks>Enter the id of the deposit you want</remarks>
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

        /// <summary>
        /// Create new withdraw
        /// </summary>
        /// <param name="id"></param>
        /// <param name="withdrawDto"></param>
        /// <returns>Create new withdraw</returns>
        /// <remarks>Insert the id of the account created in the header and other information in the body of the request</remarks>
        [HttpPost("/withdraw/{id}")] // saca um valor da conta
        public async Task<ActionResult> PostWithdrawAsync(int id, [FromBody] WithdrawPostDto withdrawDto)
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

        /// <summary>
        /// Create a new future withdraw
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="withdrawDto"></param>
        /// <returns>Create a new future withdraw</returns>
        /// <remarks>Enter the created account id and withdraw date in the header and other information in the request body</remarks>
        [HttpPost("/withdraw-future/{id}")] // saca um valor da conta por data especifica no formato yyyy-MM-dd na url
        public async Task<ActionResult> PostWithdrawByDateAsync(int id, [FromQuery] DateTime date, [FromBody] WithdrawPostDto withdrawDto)
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

        /// <summary>
        /// Get withdraw by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Get withdraw by id</returns>
        /// <remarks>Enter the id of the withdraw you want</remarks>
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

        /// <summary>
        /// Get all operations by accountId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Get all operations by accountId</returns>
        /// <remarks>Enter the id of the account you want</remarks>
        [HttpGet("/statement/{id}")] // retorna todas as operações de deposito apenas para teste, não usado em produção
        [ProducesResponseType(typeof(OperationGetDto), 200)]
        public async Task<IEnumerable<OperationGetDto>> GetAllOperationsAsync(int id)
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

        #region Get Statement By Account Id And Date

        /// <summary>
        /// Get operation by accountId and future date
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <returns>Get operation by accountId and future date</returns>
        /// <remarks>Enter the account id you want and the date</remarks>
        [HttpGet("/statement-date/{id}")] // return all operations by accountId and future date in the format yyyy-MM-dd in the url
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<OperationGetDto>> GetOperationsByDateAsync(int id, [FromQuery] DateTime date)
        {
            try
            {
                var operations = await _accountService.GetOperationsByDateAsync(id, date);
                return operations;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion Get Statement By Account Id And Date

        #endregion Statement Methods

        #region Balance Methods

        #region Get Balance By Account Id

        /// <summary>
        /// Get an account balance by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Get an account balance by id</returns>
        /// <remarks>Enter the id of the created account</remarks>
        [HttpGet("/balance/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

        /// <summary>
        /// Get an account balance by future date
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <returns>Get an account balance by future date</returns>
        /// <remarks>Enter the account id you want and the date </remarks>
        [HttpGet("/balance-future/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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