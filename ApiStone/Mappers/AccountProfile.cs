using ApiStone.Data.Dtos.Account;
using ApiStone.Models;
using AutoMapper;

namespace ApiStone.Mappers
{
    public partial class DomainMapperProfile : Profile
    {
        public void AccountProfile()
        {
            CreateMap<Account, AccountPostDto>().ReverseMap();
            CreateMap<Account, AccountGetDto>().ReverseMap();
            CreateMap<Account, AccountPutDto>().ReverseMap();
            CreateMap<Account, AccountBalanceGetDto>().ReverseMap();
        }
    }
}
