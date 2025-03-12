using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasViviendasAPI.Models
{
    [Table("Vivienda")]
    public class Vivienda
    {
        public int Id { get; set; }
        public int TipoViviendaId { get; set; }
        public int NumeroCuartos { get; set; }
        public int NumeroBanos { get; set; }
        public decimal TamanoM2 { get; set; }
        public int NumeroPisos { get; set; }
        public string Accesorios { get; set; }
        public decimal Precio { get; set; }

        public TipoVivienda TipoVivienda { get; set; }
        public Venta Venta { get; set; }
    }
}
