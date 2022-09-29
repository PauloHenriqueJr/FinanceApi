using System.Globalization;

namespace ApiStone.Data.Dtos.Statement
{
    public class ReadStatementDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int AccountId { get; set; }
    }
}
