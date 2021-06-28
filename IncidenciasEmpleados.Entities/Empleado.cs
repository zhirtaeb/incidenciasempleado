using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidenciasEmpleados.Entities
{
    [Serializable]
    public class Empleado
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Empresa")]
        public int EmpresaId { get; set; }

        public Empresa Empresa { get; set; }

        public ICollection<Tarea> Tareas { get; set; }

        public ICollection<Incidencia> Incidencias { get; set; }
    }
}
