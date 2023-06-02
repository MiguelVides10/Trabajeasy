using System.ComponentModel.DataAnnotations;

namespace Trabajeasy.Models
{
    public class recurso
    {
        [Key]
        public int id_recurso { get; set; }
        public string? tipo { get; set; }
        public string? informacion { get; set; }
        public string? url { get; set; }
    }
}
