using ApiStone.Data.Dtos.Deposit;
using ApiStone.Data.Dtos.Operation;
using FinanceApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepositController : Controller
    {
        private IDepositService _depositService;
        
        public DepositController(IDepositService depositService)
        {
            _depositService = depositService;
        }

        /// <summary>
        /// Method to create a new deposit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="depositDto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("{id}")]
        public async Task<DepositGetDto> PostDepositAsync(int id, [FromBody] DepositPostDto depositDto)
        {
            return await _depositService.CreateDepositAsync(id, depositDto);
        }

        /// <summary>
        /// Method to create a new deposit by date
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <param name="depositDto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("{id}/date")]
        public async Task<DepositGetDto> PostDepositByDateAsync(int id, [FromQuery] DateTime date, [FromBody] DepositPostDto depositDto)
        {
            return await _depositService.CreateDepositByDateAsync(id, date, depositDto);
        }
    }
}
