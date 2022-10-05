using System.ComponentModel.DataAnnotations;
using static ApiStone.Enuns.EnumStatus;

namespace ApiStone.Data.Dtos.Account
{
    public class AccountPutDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string? UserName { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public decimal Balance { get; set; }
        public AccountStatus Status { get; set; }
    }
}
