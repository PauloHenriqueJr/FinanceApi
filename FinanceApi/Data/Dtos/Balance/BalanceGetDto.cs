using ApiStone.Converters;
using System.Text.Json.Serialization;

namespace FinanceApi.Data.Dtos.Balance
{
    public class BalanceGetDto
    {
        public string? UserName { get; set; }
        [JsonConverter(typeof(JsonDecimalConverter))]
        public decimal Balance { get; set; }
    }
}
