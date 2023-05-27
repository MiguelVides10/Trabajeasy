using System.ComponentModel.DataAnnotations;

namespace Trabajeasy.Models
{
    public class empleador
    {
        [Key]
        public int id_empleador { get; set; }
        public int? id_usuario { get; set; }
        public int? id_empresa { get; set; }
    }
}
