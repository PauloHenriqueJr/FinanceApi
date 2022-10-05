using ApiStone.Data.Dtos.Operation;
using ApiStone.Models;
using AutoMapper;

namespace ApiStone.Mappers
{
    public partial class DomainMapperProfile : Profile
    {
        public void OperationProfile()
        {
            CreateMap<Operation, PostOperationDto>().ReverseMap();
            CreateMap<Operation, GetOperationDto>().ReverseMap();
            CreateMap<Operation, PutOperationDto>().ReverseMap();
        }
    }
}
