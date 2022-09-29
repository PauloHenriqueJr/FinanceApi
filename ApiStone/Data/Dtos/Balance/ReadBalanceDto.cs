

using System.Globalization;

namespace ApiStone.Data.Dtos.Balance
{
    public class ReadBalanceDto
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public string CreatedAt { get; set; }
        public int AccountId { get; set; }
    }
}
