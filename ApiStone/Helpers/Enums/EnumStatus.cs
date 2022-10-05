namespace ApiStone.Enuns
{
    public class EnumStatus
    {

        #region Status da Operação
        public enum OperationStatus
        {
            Executed, // 0
            Canceled, // 1
            Pending, // 2
            Active, // 3
            Inactive, // 4
            Success, // 5
            Scheduled, // 6
        }

        #endregion Status da Operação

        #region Tipo de Operação
        public enum OperationType
        {
            Deposit, // 0
            Withdraw, // 1
            Balance, // 2
            Transfer, // 3
            FutureDeposit, // 4
            FutureWithdraw, // 5
        }

        #endregion Tipo de Operação

        #region Status da Conta
        public enum AccountStatus
        {
            Active, // 0
            Inactive, // 1
            Canceled, // 2
            Blocked // 3
        }

        #endregion Status da Conta

    }
}