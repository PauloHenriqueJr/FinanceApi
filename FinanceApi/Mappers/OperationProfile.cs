using ApiStone.Data.Dtos.Operation;
using ApiStone.Models;
using AutoMapper;

namespace ApiStone.Mappers
{
    public partial class DomainMapperProfile : Profile
    {
        public void OperationProfile()
        {
            CreateMap<Operation, OperationPostDto>().ReverseMap();
            CreateMap<Operation, OperationGetDto>().ReverseMap();
            CreateMap<Operation, OperationPutDto>().ReverseMap();
        }
    }
}
