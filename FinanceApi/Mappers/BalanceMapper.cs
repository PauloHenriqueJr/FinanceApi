using ApiStone.Models;
using AutoMapper;
using FinanceApi.Data.Dtos.Balance;

namespace ApiStone.Mappers
{
    public partial class DomainMapperProfile : Profile
    {
        public void BalanceMapper()
        {
            CreateMap<Account, BalanceGetDto>().ReverseMap();
        }
    }
}
