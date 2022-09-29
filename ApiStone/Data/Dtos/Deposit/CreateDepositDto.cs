using System.Globalization;
using System.Text.Json.Serialization;

namespace ApiStone.Data.Dtos.Deposit
{
    public class CreateDepositDto
    {
        public string Description { get; set; }
        public double Value { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [JsonIgnore]
        public int AccountId { get; set; }
        
    }
}
