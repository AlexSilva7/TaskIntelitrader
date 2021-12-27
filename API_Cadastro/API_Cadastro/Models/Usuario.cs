using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Cadastro.Models
{
    [Table("Users")]
    public class Usuario
    {

        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        [Column("FirstName")]
        public string Name { get; set; }
        

        public string? Surname { get; set; }

        [Required]
        public int Age { get; set; } = -1;
        

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;

    }
}

