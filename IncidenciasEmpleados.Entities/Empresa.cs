using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidenciasEmpleados.Entities
{

    public class Empresa
    {
        public Empresa()
        {
            Empleados = new List<Empleado>();
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Empleado> Empleados { get; set; }

        }
}
