using ApiStone.Converters;
using System.Text.Json.Serialization;
using static ApiStone.Enuns.EnumStatus;

namespace ApiStone.Data.Dtos.Operation
{
    public class GetOperationDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OperationType Type { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OperationStatus Status { get; set; }
        [JsonConverter(typeof(JsonDecimalConverter))]
        public decimal Amount { get; set; }
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime ScheduledAt { get; set; } = DateTime.Now;
    }
}
