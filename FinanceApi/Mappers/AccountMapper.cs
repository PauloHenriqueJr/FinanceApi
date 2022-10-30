using ApiStone.Data.Dtos.Account;
using ApiStone.Models;
using AutoMapper;
using FinanceApi.Data.Dtos.Balance;

namespace ApiStone.Mappers
{
    public partial class DomainMapper : Profile
    {
        public void AccountMapper()
        {
            CreateMap<Account, AccountPostDto>().ReverseMap();
            CreateMap<Account, AccountGetDto>().ReverseMap();
            CreateMap<Account, AccountPutDto>().ReverseMap();
            CreateMap<Account, BalanceGetDto>().ReverseMap();
        }
    }
}
