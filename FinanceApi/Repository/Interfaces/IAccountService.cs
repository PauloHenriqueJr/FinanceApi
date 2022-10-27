using ApiStone.Data.Dtos.Account;
using ApiStone.Data.Dtos.Deposit;
using ApiStone.Data.Dtos.Operation;
using ApiStone.Data.Dtos.Withdraw;
using static ApiStone.Enuns.EnumStatus;

namespace FinanceApi.Repository.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountGetDto>> GetAllAccountsAsync();
        Task<AccountGetDto> GetAccountAsync(int id);
        Task<AccountGetDto> PostAccountAsync(AccountPostDto accountDto);
        Task<AccountGetDto> PutAccountAsync(int id, AccountPutDto accountDto);
        Task<AccountGetDto> DeleteAccountAsync(int id);
    }
}
