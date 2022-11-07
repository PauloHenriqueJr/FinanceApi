using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using ApiStone.Converters;
using ApiStone.Data;
using static ApiStone.Enuns.EnumStatus;

namespace ApiStone.Data.Dtos.Account
{
    public class AccountGetDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [JsonConverter(typeof(JsonDecimalConverter))]
        public decimal Balance { get; set; } = 0.0M;
        public AccountStatus Status { get; set; }
    }

}
