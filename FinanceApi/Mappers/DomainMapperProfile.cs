using AutoMapper;

namespace ApiStone.Mappers
{
    public partial class DomainMapperProfile: Profile
    {
        public DomainMapperProfile()
        {
            AccountMapper();
            BalanceMapper();
            OperationMapper();
            DepositMapper();
            WithdrawMapper();
        }
    }


}
