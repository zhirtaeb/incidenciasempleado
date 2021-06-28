using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IncidenciasEmpleados.Entities
{

    public class EmpresaDTO
    {

        public int Id { get; set; }

        [Display(Name = "Empresa")]
        public string Name { get; set; }


    }
}
