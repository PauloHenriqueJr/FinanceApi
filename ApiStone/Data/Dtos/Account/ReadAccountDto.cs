using System.Globalization;
using ApiStone.Data;
using ApiStone.Data.Dtos.Balance;

namespace ApiStone.Data.Dtos.Account
{
    public class ReadAccountDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Cpf { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public double Value { get;  set; }
    }
}
