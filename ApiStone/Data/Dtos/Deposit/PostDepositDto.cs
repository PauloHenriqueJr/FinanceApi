using System.ComponentModel.DataAnnotations.Schema;
using static ApiStone.Enuns.EnumStatus;

namespace ApiStone.Data.Dtos.Deposit
{
    public class PostDepositDto
    {
        public string? Description { get; set; } = "description example: deposit";
        public decimal Amount { get; set; } // amount of money to be deposited
        public DateTime CreatedAt { get; set; } = DateTime.Now; // date the operation was created
        public DateTime ScheduledAt { get; set; } = DateTime.Now; // date the operation was scheduled
    }
}
