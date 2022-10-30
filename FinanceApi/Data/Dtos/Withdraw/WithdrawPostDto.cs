using ApiStone.Converters;
using System.Text.Json.Serialization;
using static ApiStone.Enuns.EnumStatus;

namespace ApiStone.Data.Dtos.Withdraw
{
    public class WithdrawPostDto
    {
        public string Description { get; set; } = "description example: withdraw";
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ScheduledAt { get; set; } = DateTime.Now;
        public int AccountId { get; set; }
    }
}
