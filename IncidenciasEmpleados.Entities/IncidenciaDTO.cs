using System;
using System.ComponentModel.DataAnnotations;

namespace IncidenciasEmpleados.Entities
{
    public class IncidenciaDTO
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        public DateTime Fecha { get; set; }
        public string FechaDisplay
        {
            get
            {
                return Fecha.ToShortDateString();
            }
        }

        [Display(Name = "Id Empleado")]
        public int EmpleadoId { get; set; }
        [Display(Name = "Empleado")]
        public string EmpleadoName { get; set; }

        
    }
}
