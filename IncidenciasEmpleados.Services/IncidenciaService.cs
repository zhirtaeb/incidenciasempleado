using IncidenciasEmpleados.DAL;
using IncidenciasEmpleados.Entities;
using IncidenciasEmpleados.Services.Abstractions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IncidenciasEmpleados.Services
{
    public class IncidenciaService: IIncidenciaService
    {


        public List<IncidenciaDTO> GetIncidencias()
        {
            using (var db = new IncidenciasContext())
            {
                return db.Incidencias.Include(e => e.Empleado).Select(x => new IncidenciaDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Fecha = x.Fecha,
                    EmpleadoId = x.EmpleadoId,
                    EmpleadoName = x.Empleado.Name
                }).ToList();
            }
        }

        public IncidenciaDTO GetIncidencia(int id)
        {
            using (var db = new IncidenciasContext())
            {
                return db.Incidencias.Include(e => e.Empleado).Where(x => x.Id == id).Select(x => new IncidenciaDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Fecha = x.Fecha,
                    EmpleadoId = x.EmpleadoId,
                    EmpleadoName = x.Empleado.Name
                }).SingleOrDefault();
            }

        }

        public bool UpdateIncidencia(Incidencia Incidencia)
        {
            if (!IsIncidencia(Incidencia.Id))
                return false;
            using (var db = new IncidenciasContext())
            {
                db.Entry(Incidencia).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }
        private bool IsIncidencia(int id)
        {
            using (var db = new IncidenciasContext())
            {
                return db.Incidencias.Count(e => e.Id == id) > 0;
            }
        }

        public int AddIncidencia(Incidencia Incidencia)
        {
            using (var db = new IncidenciasContext())
            {
                db.Incidencias.Add(Incidencia);
                db.SaveChanges();
                return Incidencia.Id;
            }
        }

        public bool DeleteIncidencia(int id)
        {
            if (!IsIncidencia(id))
                return false;

            using (var db = new IncidenciasContext())
            {
                Incidencia Incidencia = db.Incidencias.Find(id);
                db.Incidencias.Remove(Incidencia);
                db.SaveChanges();
            }

            return true;
        }
        public List<IncidenciaDTO> GetIncidenciasEmpleado(int EmpleadoId)
        {
            using (var db = new IncidenciasContext())
            {
                return db.Incidencias.Include(x => x.Empleado).Where(x => x.EmpleadoId == EmpleadoId).Select(x => new IncidenciaDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Fecha = x.Fecha,
                    EmpleadoId = x.EmpleadoId,
                    EmpleadoName = x.Empleado.Name
                }).ToList();
            }
        }

    }
}
