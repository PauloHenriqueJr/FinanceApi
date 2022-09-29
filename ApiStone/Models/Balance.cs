using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiStone.Models
{
    public class Balance
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
