using FinanceApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BalanceController : Controller
    {
        private readonly IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        /// <summary>
        /// Method to get balance by account id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBalanceAsync(int id)
        {
            return Ok(await _balanceService.GetBalanceAsync(id));
        }

        /// <summary>
        /// Method to get balance by account id and date
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet("{id}/date/")]
        public async Task<ActionResult> GetBalanceByDateAsync(int id, DateTime date)
        {
            return Ok(await _balanceService.GetBalanceByDateAsync(id, date));
        }
    }
}
