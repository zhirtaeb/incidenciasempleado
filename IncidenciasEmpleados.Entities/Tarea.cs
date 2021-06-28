using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidenciasEmpleados.Entities
{
    public class Tarea
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [Index("Ix_EmpleadoFecha", Order = 1, IsUnique = true)]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [Required]
        [Index("Ix_EmpleadoFecha", Order = 2, IsUnique = true)]
        [ForeignKey("Empleado")]
        public int EmpleadoId { get; set; }
        
        public Empleado Empleado { get; set; }

    }
}
