using System.ComponentModel.DataAnnotations;
using static ApiStone.Enuns.EnumStatus;

namespace ApiStone.Data.Dtos.Account
{
    public class AccountPostDto
    {
        public string? UserName { get; set; }
        [Required]
        public string? Cpf { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
    }
}
