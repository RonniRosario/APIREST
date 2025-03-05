
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EjercicioAPIRest.Models
{
    public class Proveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProveedor { get; set; }
        [MinLength(3)]
        public string Nombre { get; set; }
        [Phone]
        public string Contacto { get; set; }

        public virtual ICollection<Producto> productos { get; set; } = new List<Producto>();

    }
}
