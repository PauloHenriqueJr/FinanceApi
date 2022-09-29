using System.Globalization;

namespace ApiStone.Data.Dtos.Withdraw
{
    public class UpdateWithdrawDto
    {
        public string Description { get; set; }
        public double Value { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Type { get; set; }
        public int AccountId { get; set; }
    }
}
