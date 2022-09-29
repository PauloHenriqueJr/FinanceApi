using ApiStone.Data.Dtos.Deposit;
using ApiStone.Models;
using AutoMapper;

namespace ApiStone.Profiles
{
    public class DepositProfile:Profile
    {
        public DepositProfile()
        {
            CreateMap<CreateDepositDto, Deposit>();
            CreateMap<Deposit, ReadDepositDto>();
            CreateMap<UpdateDepositDto, Deposit>();
        }
    }
}
