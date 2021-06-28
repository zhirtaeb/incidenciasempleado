using IncidenciasEmpleados.DAL;
using IncidenciasEmpleados.Entities;
using IncidenciasEmpleados.Services.Abstractions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace IncidenciasEmpleados.Services
{
    public class TareaService: ITareaService
    {

        
        public IQueryable<Tarea> GetTareas()
        {
            using (var db = new IncidenciasContext())
            {
                return db.Tareas.Include(e => e.Empleado);
            }
        }
        
        public Tarea GetTarea(int id)
        {
            using (var db = new IncidenciasContext())
            {
                return db.Tareas.Find(id);
            }
           
        }

        public bool UpdateTarea(int id, Tarea Tarea)
        {
            using (var db = new IncidenciasContext())
            {
                db.Entry(Tarea).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsTarea(id))
                    {
                        return false;
                    }
                    else
                    {
                        throw;
                    }
                }
                return true;
            }
        }
        private bool IsTarea(int id)
        {
            using (var db = new IncidenciasContext())
            {
                return db.Tareas.Count(e => e.Id == id) > 0;
            }
        }

        public void AddTarea(Tarea Tarea)
        {
            using (var db = new IncidenciasContext())
            {
                db.Tareas.Add(Tarea);
                db.SaveChanges();
            }
        }

       public bool DeleteTarea(int id)
        {
            if (!IsTarea(id))
                return false;

            using (var db = new IncidenciasContext())
            {
                Tarea Tarea = db.Tareas.Find(id);
                db.Tareas.Remove(Tarea);
                db.SaveChanges();
            }
           
            return true;
        }

    }
}
