using ApiStone.Converters;
using System.Text.Json.Serialization;
using static ApiStone.Enuns.EnumStatus;

namespace ApiStone.Data.Dtos.Withdraw
{
    public class PostWithdrawDto
    {
        public string Description { get; set; } = "description example: withdraw";
        public decimal Amount { get; set; } // amount of money to be withdrawn
        public DateTime CreatedAt { get; set; } = DateTime.Now; // date the operation was created
        public DateTime ScheduledAt { get; set; } = DateTime.Now; // date the operation was scheduled
    }
}
