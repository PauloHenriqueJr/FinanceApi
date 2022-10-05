using System.ComponentModel.DataAnnotations;
using static ApiStone.Enuns.EnumStatus;

namespace ApiStone.Data.Dtos.Account
{
    public class PostAccountDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? UserName { get; set; }
        [Required]
        public string? Cpf { get; set; }
        public decimal Balance { get; set; }
        public AccountStatus Status { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
    }
}
