using System.Globalization;
using System.Text.Json.Serialization;

namespace ApiStone.Data.Dtos.Withdraw
{
    public class CreateWithdrawDto
    {
        public string Description { get; set; }
        public double Value { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Type { get; set; }
        [JsonIgnore]
        public int AccountId { get; set; }
    }
}
