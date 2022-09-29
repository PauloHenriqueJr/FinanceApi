using System.Globalization;

namespace ApiStone.Data.Dtos.Deposit
{
    public class ReadDepositDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Type { get; set; }
    }
}
