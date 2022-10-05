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
        Task<IEnumerable<AccountGetDto>> GetAllAccountsAsync();
        Task<AccountGetDto> GetAccountAsync(int id);
        Task<AccountGetDto> PostAccountAsync(AccountPostDto accountDto);
        Task<AccountGetDto> PutAccountAsync(int id, AccountPutDto accountDto);
        Task<AccountGetDto> DeleteAccountAsync(int id);

        #endregion Account Methods

        #region Deposit Methods
        Task<DepositGetDto> PostDepositAsync(int id, DepositPostDto depositDto);
        Task<DepositGetDto> PostDepositByDateAsync(int id, DateTime date, DepositPostDto depositDto);
        Task<DepositGetDto> GetDepositAsync(int id);

        #endregion Deposit Methods

        #region Withdraw Methods
        Task<WithdrawGetDto> PostWithdrawAsync(int id, WithdrawPostDto withdrawDto);
        Task<WithdrawGetDto> PostWithdrawByDateAsync(int id, DateTime date, WithdrawPostDto withdrawDto);
        Task<WithdrawGetDto> GetWithdrawAsync(int id);

        #endregion Withdraw Methods

        #region Operation Methods
        Task<IEnumerable<OperationGetDto>> GetAllOperationsAsync(int id);

        #endregion Operation Methods

        #region Balance Methods
        Task<AccountBalanceGetDto> GetBalanceAsync(int id);

        #endregion Balance Methods
    }
}
