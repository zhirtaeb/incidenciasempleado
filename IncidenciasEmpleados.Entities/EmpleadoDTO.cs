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
    public class EmpleadoDTO
    {
        public int Id { get; set; }
       
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        
        [Display(Name = "Id Empresa")]
        public int EmpresaId { get; set; }
       
        [Display(Name = "Empresa")]
        public string EmpresaName { get; set; }

        
    }
}
