using IncidenciasEmpleados.Entities;
using System.Linq;

namespace IncidenciasEmpleados.Services.Abstractions
{
    public interface ITareaService
    {


        IQueryable<Tarea> GetTareas();

        Tarea GetTarea(int id);

        bool UpdateTarea(int id, Tarea Tarea);
       
        void AddTarea(Tarea Tarea);

        bool DeleteTarea(int id);
        
    }
}
