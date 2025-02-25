using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjercicioAPIRest.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }
        [EmailAddress(ErrorMessage ="El email debe de tener un formato correcto")]
        public string Email { get; set; }
        [MinLength(10)]
        public string password { get; set; }
        [Required]
        
        public DateTime FechaNacimiento { get; set; }


    }
}
