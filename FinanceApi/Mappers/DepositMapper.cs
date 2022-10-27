using ApiStone.Data.Dtos.Deposit;
using ApiStone.Models;
using AutoMapper;

namespace ApiStone.Mappers
{
    public partial class DomainMapperProfile : Profile
    {
        public void DepositMapper()
        {
            CreateMap<Operation, DepositPostDto>().ReverseMap();
            CreateMap<Operation, DepositGetDto>().ReverseMap();
        }
    }
}
