using System.ComponentModel.DataAnnotations;

namespace Trabajeasy.Models
{
    public class usuario
    {
        [Key]
        public int id_usuario { get; set; }
        public string? nombre { get; set; }
        public string? contrasenha { get; set; }
        public int? tipo_usuario { get; set; }
    }
}
