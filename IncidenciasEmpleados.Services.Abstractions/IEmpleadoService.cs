using IncidenciasEmpleados.Entities;
using System.Collections.Generic;

namespace IncidenciasEmpleados.Services.Abstractions
{
    public interface IEmpleadoService
    {


        List<EmpleadoDTO> GetEmpleados();

        EmpleadoDTO GetEmpleado(int id);

        bool UpdateEmpleado(Empleado empleado);

        void AddEmpleado(Empleado empleado);

        bool DeleteEmpleado(int id);

    }
}
