using ApiStone.Converters;
using System.Text.Json.Serialization;
using static ApiStone.Enuns.EnumStatus;

namespace ApiStone.Data.Dtos.Withdraw
{
    public class GetWithdrawDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = "description example: withdraw";
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OperationType Type { get; set; } // 1 = deposit, 2 = withdraw
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OperationStatus Status { get; set; } // 1 = pending, 2 = completed, 3 = canceled
        public decimal Amount { get; set; } // amount of money to be withdrawn
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime CreatedAt { get; set; } = DateTime.Now; // date the operation was created
    }
}
