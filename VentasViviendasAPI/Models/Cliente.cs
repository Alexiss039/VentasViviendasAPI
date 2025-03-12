using System.ComponentModel.DataAnnotations.Schema;

namespace VentasViviendasAPI.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        public ICollection<Venta> Ventas { get; set; }
    }
}
