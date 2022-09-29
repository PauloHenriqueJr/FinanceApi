using System.Globalization;

namespace ApiStone.Data.Dtos.Deposit
{
    public class UpdateDepositDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Type { get; set; }
        public int AccountId { get; set; }
    }
}
