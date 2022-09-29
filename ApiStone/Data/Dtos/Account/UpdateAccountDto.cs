using System.ComponentModel.DataAnnotations;

namespace ApiStone.Data.Dtos.Account
{
    public class UpdateAccountDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }   
    }
}
