using AutoMapper;

namespace ApiStone.Mappers
{
    public partial class DomainMapperProfile: Profile
    {
        public DomainMapperProfile()
        {
            AccountProfile();
            OperationProfile();
            DepositProfile();
            WithdrawProfile();
        }
    }


}
