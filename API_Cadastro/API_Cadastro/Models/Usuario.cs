using System.ComponentModel.DataAnnotations;

namespace API_Cadastro.Models
{
    public class Usuario
    {
        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        public string FirstName { get; set; }
        
        public string? Surname { get; set; }

        [Required]
        public int Age { get; set; }
        

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;

    }
}

