using ApiStone.Data.Dtos.Account;
using ApiStone.Models;
using AutoMapper;

namespace ApiStone.Mappers
{
    public partial class DomainMapperProfile : Profile
    {
        public void AccountProfile()
        {
            CreateMap<Account, PostAccountDto>().ReverseMap();
            CreateMap<Account, GetAccountDto>().ReverseMap();
            CreateMap<Account, PutAccountDto>().ReverseMap();
            CreateMap<Account, AccountBalanceGetDto>().ReverseMap();
        }
    }
}
