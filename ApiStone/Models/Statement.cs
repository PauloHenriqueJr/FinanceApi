using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiStone.Models
{
    public class Statement
    {
        [Key]
        [Required]
        public int Id { get; set; } 
        [Required]
        public string Description { get; set; } // Description of the transaction (deposit, credit, withdraw, transfer) 
        public double Value { get; set; } // Valor da transação (positivo ou negativo)
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Data da transação
        public string Type { get; set; } // Tipo de transação (Crédito ou Débito)
        public int AccountId { get; set; } // Chave estrangeira para a tabela de contas 
        [JsonIgnore]
        public virtual Account Account { get; set; } // Chave estrangeira para a conta 
        [JsonIgnore]
        public virtual List<Deposit> Deposits { get; set; } // Chave estrangeira para a tabela de depósitos
        [JsonIgnore]
        public virtual List<Withdraw> Withdraws { get; set; } // Chave estrangeira para a tabela de saques
        [JsonIgnore]
        public virtual Balance Balance { get; set; } // Chave estrangeira para a tabela de saldo
    }
}
