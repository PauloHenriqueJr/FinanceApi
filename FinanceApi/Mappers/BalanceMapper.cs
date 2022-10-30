using ApiStone.Models;
using AutoMapper;
using FinanceApi.Data.Dtos.Balance;

namespace ApiStone.Mappers
{
    public partial class DomainMapper : Profile
    {
        public void BalanceMapper()
        {
            CreateMap<Account, BalanceGetDto>().ReverseMap();
        }
    }
}
