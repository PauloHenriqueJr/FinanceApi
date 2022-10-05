using ApiStone.Data.Dtos.Withdraw;
using ApiStone.Models;
using AutoMapper;

namespace ApiStone.Mappers
{
    public partial class DomainMapperProfile : Profile
    {
        public void WithdrawProfile()
        {
            CreateMap<Operation, PostWithdrawDto>().ReverseMap();
            CreateMap<Operation, GetWithdrawDto>().ReverseMap();
        }
    }
}
