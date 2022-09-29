using ApiStone.Data.Dtos.Account;
using ApiStone.Models;
using AutoMapper;

namespace ApiStone.Profiles
{
    public class AccountProfile: Profile
    {
        public AccountProfile()
        {
            CreateMap<CreateAccountDto, Account>();
            CreateMap<Account, ReadAccountDto>();
            CreateMap<UpdateAccountDto, Account>();
        }
    }
}
