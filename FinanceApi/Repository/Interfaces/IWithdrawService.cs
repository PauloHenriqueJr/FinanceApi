using ApiStone.Data.Dtos.Operation;
using ApiStone.Data.Dtos.Withdraw;

namespace FinanceApi.Repository.Interfaces
{
    public interface IWithdrawService
    {
        Task<WithdrawGetDto> PostWithdrawAsync(int id, WithdrawPostDto withdrawDto);
        Task<WithdrawGetDto> PostWithdrawByDateAsync(int id, DateTime date, WithdrawPostDto withdrawDto);
    }
}
