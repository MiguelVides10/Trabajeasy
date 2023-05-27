using System.ComponentModel.DataAnnotations;

namespace Trabajeasy.Models
{
    public class publicacion
    {
        [Key]
        public int id_publicacion { get; set; }
        public int? id_empleador { get; set; }
        public int? id_departamento { get; set; }
        public int? id_tipo { get; set; }
        public string? nivel { get; set; }
        public string? salario { get; set; }
        public string? informacion { get; set; }
        public string? puesto { get; set;}

    }
}
