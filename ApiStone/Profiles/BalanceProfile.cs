using ApiStone.Data.Dtos.Balance;
using ApiStone.Models;
using AutoMapper;

namespace ApiStone.Profiles
{
    public class BalanceProfile : Profile
    {
        public BalanceProfile()
        {
            CreateMap<CreateBalanceDto, Balance>();
            CreateMap<Balance, ReadBalanceDto>();
            CreateMap<UpdateBalanceDto, Balance>();
        }
    }
}
