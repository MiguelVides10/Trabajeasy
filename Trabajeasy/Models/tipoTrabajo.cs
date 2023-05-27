using System.ComponentModel.DataAnnotations;

namespace Trabajeasy.Models
{
    public class tipoTrabajo
    {
        [Key]
        public int id_tipo_trabajo { get; set; }
        public string? area { get; set; }
    }
}
