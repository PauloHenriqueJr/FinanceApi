using ApiStone.Data.Dtos.Statement;
using ApiStone.Models;
using AutoMapper;

namespace ApiStone.Profiles
{
    public class StatementProfile : Profile
    {
        public StatementProfile()
        {
            CreateMap<CreateStatementDto, Statement>();
            CreateMap<ReadStatementDto, Statement>();
            CreateMap<Statement, ReadStatementDto>();
        }
    }
}
