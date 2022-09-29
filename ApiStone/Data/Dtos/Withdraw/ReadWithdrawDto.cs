using System.Globalization;

namespace ApiStone.Data.Dtos.Withdraw
{
    public class ReadWithdrawDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public double Value { get; set; } // Value é o valor do saque
    }
}
