using System.ComponentModel.DataAnnotations;
using static ApiStone.Enuns.EnumStatus;

namespace ApiStone.Models
{
    public class Account
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Cpf { get; set; }
        public decimal Balance { get; set; }
        public AccountStatus Status { get; set; }
        //public string Token { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public virtual List<Operation> Operations { get; set; }

    }
}
