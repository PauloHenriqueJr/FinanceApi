using AutoMapper;

namespace ApiStone.Mappers
{
    public partial class DomainMapper: Profile
    {
        public DomainMapper()
        {
            AccountMapper();
            BalanceMapper();
            OperationMapper();
            DepositMapper();
            WithdrawMapper();
        }
    }


}
