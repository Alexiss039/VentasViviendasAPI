using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentasViviendasAPI.Models
{
    [Table("Vivienda")]
    public class Vivienda
    {
        public int Id { get; set; }

        [Column("tipo_vivienda_id")]
        public int TipoViviendaId { get; set; }

        [Column("numero_cuartos")]
        public int NumeroCuartos { get; set; }

        [Column("numero_banos")]
        public int NumeroBanos { get; set; }

        [Column("tamano_m2")]
        public decimal TamanoM2 { get; set; }

        [Column("numero_pisos")]
        public int NumeroPisos { get; set; }

        [Column("accesorios")]
        public string Accesorios { get; set; }

        [Column("precio")]
        public decimal Precio { get; set; }

        [ForeignKey("TipoViviendaId")]
        public TipoVivienda? TipoVivienda { get; set; }

 
        public Venta? Venta { get; set; }
    }
}
