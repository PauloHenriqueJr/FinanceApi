using ApiStone.Data.Dtos.Deposit;
using ApiStone.Data.Dtos.Operation;

namespace FinanceApi.Repository.Interfaces
{
    public interface IDepositService
    {
        Task<DepositGetDto> PostDepositAsync(int id, DepositPostDto depositDto);
        Task<DepositGetDto> PostDepositByDateAsync(int id, DateTime date, DepositPostDto depositDto);
    }
}
