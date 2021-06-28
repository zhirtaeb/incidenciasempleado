using IncidenciasEmpleados.Entities;
using System.Collections.Generic;

namespace IncidenciasEmpleados.Services.Abstractions
{
    public interface IEmpresaService
    {
        List<EmpresaDTO> GetEmpresas();

        Empresa GetEmpresa(int id);

        bool UpdateEmpresa(Empresa empresa);

        void AddEmpresa(Empresa empresa);

        bool DeleteEmpresa(int id);
       

    }
}
