using System.ComponentModel.DataAnnotations;

namespace Trabajeasy.Models
{
    public class departamentos
    {
        [Key]
        public int id_depto { get; set; }
        public string? nombre_depto { get; set; }
    }
}
