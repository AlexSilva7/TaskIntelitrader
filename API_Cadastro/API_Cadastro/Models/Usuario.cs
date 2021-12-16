using System.ComponentModel.DataAnnotations;

namespace API_Cadastro.Models
{
    public class Usuario
    {
        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        public string FirstName { get; set; }
        /*
         * [FirstName("Primeiro Nome")]
         * especifica como deve aparecer no front
         */
        public string? Surname { get; set; }

        [Required]
        public int Age { get; set; }
        /*
         * [Range(1,100,ErrorMessage="Idade deve ser entre 1 e 150!!")]
         * exemplo de erro criado na classe
         */

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        
        /*
        public Usuario(string name, string? surname, int age)
        {
            FirstName = name;
            Surname = surname;
            Age = age;
        }

        public Usuario(string name, int age)
        {
            FirstName = name;
            Age = age;
        }
        */

    }
}

