using ApiStone.Data.Dtos.Account;
using ApiStone.Data.Dtos.Deposit;
using ApiStone.Data.Dtos.Operation;
using ApiStone.Data.Dtos.Withdraw;
using FinanceApi.Repository.Services;
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


        /// <summary>
        /// Create a new account 
        /// </summary>
        /// <param name="accountPostDto"></param>
        /// <returns>Create a new account</returns>
        [HttpPost]
        public async Task<ActionResult> PostAccountAsync([FromBody] AccountPostDto accountPostDto)
        {
            return Ok(await _accountService.PostAccountAsync(accountPostDto));
        }


        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <returns>Get all accounts</returns>
        /// <remarks>This method is for only tests</remarks>
        [HttpGet] // return all accounts for tests only 
        public async Task<IEnumerable<AccountGetDto>> GetAllAccountsAsync()
        {
            return await _accountService.GetAllAccountsAsync();
        }


        /// <summary>
        /// Get an account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Get an account by id</returns>
        /// <remarks>Enter the id of the created account</remarks>
        [HttpGet("{id}")] 
        public async Task<ActionResult> GetAccountAsync(int id)
        {
            return Ok(await _accountService.GetAccountAsync(id));
        }

        /// <summary>
        /// Update an account by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountDto"></param>
        /// <returns>Update an account by id</returns>
        /// <remarks>Enter the id of the created account</remarks>
        [HttpPut("{id}")] 
        public async Task<ActionResult> PutAccountAsync(int id, [FromBody] AccountPutDto accountDto)
        {
            return Ok(await _accountService.PutAccountAsync(id, accountDto));
        }

        /// <summary>
        /// Delete and account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete and account by id</returns>
        /// <remarks>Enter the id of the account you want to delete</remarks>
        [HttpDelete("{id}")] 
        public async Task<ActionResult> DeleteAccount(int id)
        {
            return Ok(await _accountService.DeleteAccountAsync(id));
        }


    }
}