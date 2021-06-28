using IncidenciasEmpleados.Entities;
using System.Collections.Generic;

namespace IncidenciasEmpleados.Services.Abstractions
{
    public interface IIncidenciaService
    {
        List<IncidenciaDTO> GetIncidencias();

        IncidenciaDTO GetIncidencia(int id);

        bool UpdateIncidencia(Incidencia Incidencia);
        
        int AddIncidencia(Incidencia Incidencia);

        bool DeleteIncidencia(int id);

        List<IncidenciaDTO> GetIncidenciasEmpleado(int EmpleadoId);
        
    }
}
