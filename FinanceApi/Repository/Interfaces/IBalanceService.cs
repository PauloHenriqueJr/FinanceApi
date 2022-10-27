using FinanceApi.Data.Dtos.Balance;

namespace FinanceApi.Repository.Interfaces
{
    public interface IBalanceService
    {
        Task<BalanceGetDto> GetBalanceAsync(int id);

        Task<BalanceGetDto> GetBalanceByDateAsync(int id, DateTime date);

    }
}
