using System.ComponentModel.DataAnnotations.Schema;

namespace VentasViviendasAPI.Models
{
    [Table("Venta")]
    public class Venta
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ViviendaId { get; set; }
        public DateTime FechaVenta { get; set; } = DateTime.Now;
        public decimal ValorTotal { get; set; }

        public Cliente Cliente { get; set; }
        public Vivienda Vivienda { get; set; }
    }
}
