using ApiStone.Data.Dtos.Withdraw;
using ApiStone.Models;
using AutoMapper;

namespace ApiStone.Profiles
{
    public class WithdrawProfile : Profile
    {
        public WithdrawProfile()
        {
            CreateMap<CreateWithdrawDto, Withdraw>();
            CreateMap<Withdraw, ReadWithdrawDto>();
            CreateMap<UpdateWithdrawDto, Withdraw>();
        }
    }
}
