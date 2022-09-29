using ApiStone.Data;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;

namespace ApiStone.Models
{
    public class Account
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Cpf { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public virtual Balance Balance { get; set; }
        public virtual List<Statement> Statements { get; set; }
        public virtual List<Deposit> Deposits { get; set; }
        public virtual List<Withdraw> Withdraws { get; set; }

    }
}
