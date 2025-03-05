using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EjercicioAPIRest.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        
        public int IdCategoria { get; set; }
        public int IdProveedor { get; set; }

        [ForeignKey("IdProveedor")]
        public virtual Proveedor? Proveedor { get; set; }
        [ForeignKey("IdCategoria")]

        public virtual Categoria? Categoria { get; set; } 

    }
}
