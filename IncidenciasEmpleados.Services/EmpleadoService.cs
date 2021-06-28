using IncidenciasEmpleados.DAL;
using IncidenciasEmpleados.Entities;
using IncidenciasEmpleados.Services.Abstractions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IncidenciasEmpleados.Services
{
    public class EmpleadoService : IEmpleadoService
    {

        public List<EmpleadoDTO> GetEmpleados()
        {
            using (var db = new IncidenciasContext())
            {
                return db.Empleados.Include(e => e.Empresa).Select(x => new EmpleadoDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    EmpresaId = x.EmpresaId,
                    EmpresaName = x.Empresa.Name
                }).ToList();
            }
        }

        public EmpleadoDTO GetEmpleado(int id)
        {
            using (var db = new IncidenciasContext())
            {
                return db.Empleados.Include(e => e.Empresa).Where(e => e.Id == id).Select(x => new EmpleadoDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    EmpresaId = x.EmpresaId,
                    EmpresaName = x.Empresa.Name
                }).SingleOrDefault();
            }

        }

        public bool UpdateEmpleado(Empleado empleado)
        {
            if (!IsEmpleado(empleado.Id))
                return false;
            using (var db = new IncidenciasContext())
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }
        public static bool IsEmpleado(int id)
        {
            using (var db = new IncidenciasContext())
            {
                return db.Empleados.Count(e => e.Id == id) > 0;
            }
        }

        public void AddEmpleado(Empleado empleado)
        {
            using (var db = new IncidenciasContext())
            {
                db.Empleados.Add(empleado);
                db.SaveChanges();
            }
        }

        public bool DeleteEmpleado(int id)
        {
            if (!IsEmpleado(id))
                return false;

            using (var db = new IncidenciasContext())
            {
                Empleado empleado = db.Empleados.Find(id);
                db.Empleados.Remove(empleado);
                db.SaveChanges();
            }

            return true;
        }



    }
}
