using ApiStone.Data.Dtos.Withdraw;
using FinanceApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WithdrawController : Controller
    {
        private readonly IWithdrawService _withdrawService;

        public WithdrawController(IWithdrawService withdrawService)
        {
            _withdrawService = withdrawService;
        }

        /// <summary>
        /// Method to create a new withdraw
        /// </summary>
        /// <param name="id"></param>
        /// <param name="withdrawDto"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public async Task<WithdrawGetDto> PostWithdrawAsync(int id, [FromBody] WithdrawPostDto withdrawDto)
        {
            try
            {
                return await _withdrawService.PostWithdrawAsync(id, withdrawDto);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method to create a new withdraw by date
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="withdrawDto"></param>
        /// <returns></returns>
        [HttpPost("{id}/date")]
        public async Task<WithdrawGetDto> PostWithdrawByDateAsync(int id, [FromQuery] DateTime date, WithdrawPostDto withdrawDto)
        {
            return await _withdrawService.PostWithdrawByDateAsync(id, date, withdrawDto);
        }
    }
}
