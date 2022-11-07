using ApiStone.Data.Dtos.Deposit;
using ApiStone.Data.Dtos.Operation;

namespace FinanceApi.Repository.Interfaces
{
    public interface IDepositService
    {
        Task<DepositGetDto> CreateDepositAsync(int id, DepositPostDto depositDto);
        Task<DepositGetDto> CreateDepositByDateAsync(int id, DateTime date, DepositPostDto depositDto);
    }
}
