using ApiStone.Data.Dtos.Account;
using ApiStone.Data.Dtos.Deposit;
using ApiStone.Data.Dtos.Operation;
using ApiStone.Data.Dtos.Withdraw;
using static ApiStone.Enuns.EnumStatus;

namespace ApiStone.Services
{
    public interface IAccountService
    {
        #region Account Methods
        Task<IEnumerable<GetAccountDto>> GetAllAccountsAsync();
        Task<GetAccountDto> GetAccountAsync(int id);
        Task<GetAccountDto> PostAccountAsync(PostAccountDto accountDto);
        Task<GetAccountDto> PutAccountAsync(int id, PutAccountDto accountDto);
        Task<GetAccountDto> DeleteAccountAsync(int id);

        #endregion Account Methods

        #region Deposit Methods
        Task<GetDepositDto> PostDepositAsync(int id, PostDepositDto depositDto);
        Task<GetDepositDto> PostDepositByDateAsync(int id, DateTime date, PostDepositDto depositDto);
        Task<GetDepositDto> GetDepositAsync(int id);

        #endregion Deposit Methods

        #region Withdraw Methods
        Task<GetWithdrawDto> PostWithdrawAsync(int id, PostWithdrawDto withdrawDto);
        Task<GetWithdrawDto> PostWithdrawByDateAsync(int id, DateTime date, PostWithdrawDto withdrawDto);
        Task<GetWithdrawDto> GetWithdrawAsync(int id);

        #endregion Withdraw Methods

        #region Operation Methods
        Task<IEnumerable<GetOperationDto>> GetAllOperationsAsync(int id);

        #endregion Operation Methods

        #region Balance Methods
        Task<AccountBalanceGetDto> GetBalanceAsync(int id);

        #endregion Balance Methods
    }
}
