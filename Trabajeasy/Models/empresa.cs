using System.ComponentModel.DataAnnotations;

namespace Trabajeasy.Models
{
    public class empresa
    {
        [Key]
        public int id_empresa { get; set; }
        public string? nombre { get; set; }
    }
}
