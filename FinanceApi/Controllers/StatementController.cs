using ApiStone.Data.Dtos.Operation;
using FinanceApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatementController : Controller
    {
        private readonly IStatementService _operationService;

        public StatementController(IStatementService operationService)
        {
            _operationService = operationService;
        }

        /// <summary>
        /// Method to get all operations by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("{id}")]
        public async Task<IEnumerable<OperationGetDto>> GetAllOperationsAsync(int id)
        {
            try
            {
                return await _operationService.GetAllOperationsAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        /// <summary>
        /// Method to get operation by date
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet("{id}/date")]
        public async Task<IEnumerable<OperationGetDto>> GetOperationByDateAsync(int id, [FromQuery] DateTime date)
        {
            return await _operationService.GetOperationByDateAsync(id, date);
        }
    }
}
