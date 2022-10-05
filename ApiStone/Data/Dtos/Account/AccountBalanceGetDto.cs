using ApiStone.Converters;
using System.Text.Json.Serialization;

namespace ApiStone.Data.Dtos.Account
{
    public class AccountBalanceGetDto
    {
        public string? UserName { get; set; }
        [JsonConverter(typeof(JsonDecimalConverter))]
        public decimal Balance { get; set; }
    }
}
