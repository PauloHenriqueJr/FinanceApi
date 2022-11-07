using ApiStone.Converters;
using System.Text.Json.Serialization;

namespace FinanceApi.Data.Dtos.Balance
{
    public class BalanceGetDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string? UserName { get; set; }
        [JsonConverter(typeof(JsonDecimalConverter))]
        public decimal Balance { get; set; }
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime CreatedAt { get; set; }
    }
}
