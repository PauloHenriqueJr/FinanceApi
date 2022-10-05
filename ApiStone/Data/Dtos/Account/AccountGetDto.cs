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
        public string? UserName { get; set; }
        public string? Cpf { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [JsonConverter(typeof(JsonDecimalConverter))]
        public decimal Balance { get; set; } 
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountStatus Status { get; set; } 
    }

}
