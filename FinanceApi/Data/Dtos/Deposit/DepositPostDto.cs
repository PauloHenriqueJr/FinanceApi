using System.ComponentModel.DataAnnotations.Schema;
using static ApiStone.Enuns.EnumStatus;

namespace ApiStone.Data.Dtos.Deposit
{
    public class DepositPostDto
    {
        public string? Description { get; set; } = "description example: deposit";
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public OperationType Type { get; set; }
    }
}
