using System.ComponentModel.DataAnnotations;

namespace ApiStone.Data.Dtos.Account
{
    public class CreateAccountDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Cpf { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
    }
}
