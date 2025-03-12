using System.ComponentModel.DataAnnotations.Schema;

namespace VentasViviendasAPI.Models
{
    [Table("TipoVivienda")]
    public class TipoVivienda
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Vivienda> Viviendas { get; set; }
    }
}
