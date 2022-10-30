using ApiStone.Data.Dtos.Operation;
using ApiStone.Models;
using AutoMapper;

namespace ApiStone.Mappers
{
    public partial class DomainMapper : Profile
    {
        public void OperationMapper()
        {
            CreateMap<Operation, OperationPostDto>().ReverseMap();
            CreateMap<Operation, OperationGetDto>().ReverseMap();
            CreateMap<Operation, OperationPutDto>().ReverseMap();
        }
    }
}
