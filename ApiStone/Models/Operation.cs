using System.ComponentModel.DataAnnotations;
using static ApiStone.Enuns.EnumStatus;

namespace ApiStone.Models
{
    public class Operation
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string? Description { get; set; }
        public OperationType Type { get; set; }
        public OperationStatus Status { get; set; } 
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ScheduledAt { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
