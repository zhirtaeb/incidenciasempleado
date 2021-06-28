using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IncidenciasEmpleados.Entities
{
    public class Incidencia
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [Required]
        [ForeignKey("Empleado")]
        public int EmpleadoId { get; set; }

        public Empleado Empleado { get; set; }

        
    }
}
