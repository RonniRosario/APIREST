using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace EjercicioAPIRest.Models
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Producto> productos { get; set; } = new List<Producto>();
    }
}
