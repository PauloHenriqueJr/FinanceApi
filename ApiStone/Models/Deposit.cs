using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;

namespace ApiStone.Models
{
    public class Deposit
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Value { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ClosedAt { get; set; } 
        public string Type { get; set; }
        public virtual Account Account { get; set; }
        public int AccountId { get; set; }
    }
}
