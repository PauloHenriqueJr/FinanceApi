using ApiStone.Converters;
using System.Text.Json.Serialization;
using static ApiStone.Enuns.EnumStatus;

namespace ApiStone.Data.Dtos.Operation
{
    public class OperationPostDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public OperationType Type { get; set; }
        [JsonConverter(typeof(JsonDecimalConverter))]
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int AccountId { get; set; }
    }
}
