using ApiStone.Data.Dtos.Withdraw;
using ApiStone.Models;
using AutoMapper;

namespace ApiStone.Mappers
{
    public partial class DomainMapper : Profile
    {
        public void WithdrawMapper()
        {
            CreateMap<Operation, WithdrawPostDto>().ReverseMap();
            CreateMap<Operation, WithdrawGetDto>().ReverseMap();
        }
    }
}
