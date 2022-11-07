using ApiStone.Data.Dtos.Operation;
using ApiStone.Data.Dtos.Withdraw;

namespace FinanceApi.Repository.Interfaces
{
    public interface IWithdrawService
    {
        Task<WithdrawGetDto> CreateWithdrawAsync(int id, WithdrawPostDto withdrawDto);
        Task<WithdrawGetDto> CreateWithdrawByDateAsync(int id, DateTime date, WithdrawPostDto withdrawDto);
    }
}
