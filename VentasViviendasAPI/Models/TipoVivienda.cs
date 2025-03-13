using System.ComponentModel.DataAnnotations.Schema;

namespace VentasViviendasAPI.Models
{
    [Table("TipoVivienda")]
    public class TipoVivienda
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        public ICollection<Vivienda> Viviendas { get; set; } = new List<Vivienda>();
    }
}
