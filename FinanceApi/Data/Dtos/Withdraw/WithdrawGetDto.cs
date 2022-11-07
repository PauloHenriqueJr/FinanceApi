using ApiStone.Converters;
using System.Text.Json.Serialization;
using static ApiStone.Enuns.EnumStatus;

namespace ApiStone.Data.Dtos.Withdraw
{
    public class WithdrawGetDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = "description example: withdraw";
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OperationType Type { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OperationStatus Status { get; set; }
        public decimal Amount { get; set; }
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int AccountId { get; set; }
        public DateTime ScheduledAt { get; set; }
    }
}
