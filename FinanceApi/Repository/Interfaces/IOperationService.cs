using ApiStone.Data.Dtos.Operation;

namespace FinanceApi.Repository.Interfaces
{
    public interface IOperationService
    {
        Task<IEnumerable<OperationGetDto>> GetAllOperationsAsync(int id);

        Task<IEnumerable<OperationGetDto>> GetOperationByDateAsync(int id, DateTime date);
    }
}
