using IncidenciasEmpleados.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidenciasEmpleados.DAL
{
    public class IncidenciasInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<IncidenciasContext>
    {
        protected override void Seed(IncidenciasContext context)
        {
            var empresas = new List<Empresa>
            {
            new Empresa{Id=1,Name="Mutiny"},
            new Empresa{Id=2,Name="Mobile SC"},
            new Empresa{Id=3,Name="Computering SL"}
            };
            empresas.ForEach(s => context.Empresas.Add(s));
            context.SaveChanges();

            var empleados = new List<Empleado>
            {
            new Empleado{Id=1,Name="Juan Lagar", EmpresaId= 1},
            new Empleado{Id=2,Name="Juan Antonio Ruiz", EmpresaId= 1},
            new Empleado{Id=3,Name="Javier Mota", EmpresaId= 1},
            new Empleado{Id=4,Name="Lucia Sanchez", EmpresaId= 1},
            new Empleado{Id=5,Name="Paloma Altamira", EmpresaId= 2},
            new Empleado{Id=6,Name="Luis Suarez", EmpresaId= 2}
            };

            empleados.ForEach(s => context.Empleados.Add(s));
            context.SaveChanges();

            var incidencias = new List<Incidencia>
            {
                new Incidencia{Id=1,EmpleadoId=1,Fecha=new DateTime(2021,05,17),Name="Luz pasillo fundida"},
                new Incidencia{Id=2,EmpleadoId=1,Fecha=new DateTime(2021,05,18),Name="Abrir ventanas Planta 1"},
                new Incidencia{Id=3,EmpleadoId=1,Fecha=new DateTime(2021,05,18),Name="Abrir ventanas Planta 2"},
                new Incidencia{Id=4,EmpleadoId=1,Fecha=new DateTime(2021,05,19),Name="Limpiar mesa manager"},
                new Incidencia{Id=5,EmpleadoId=1,Fecha=new DateTime(2021,05,20),Name="Limpiar mesa Planta 2 Mesa A"},
                new Incidencia{Id=6,EmpleadoId=2,Fecha=new DateTime(2021,05,18),Name="Intermitente izq fundido"},
                new Incidencia{Id=7,EmpleadoId=2,Fecha=new DateTime(2021,05,19),Name="Pastillas freno"},
                new Incidencia{Id=8,EmpleadoId=2,Fecha=new DateTime(2021,05,20),Name="Disco viaje"},
                new Incidencia{Id=9,EmpleadoId=5,Fecha=new DateTime(2021,05,18),Name="Login usuarios"},
                new Incidencia{Id=10,EmpleadoId=5,Fecha=new DateTime(2021,05,20),Name="Combo empleados"}
            };
            incidencias.ForEach(s => context.Incidencias.Add(s));
            context.SaveChanges();

            var tareas = new List<Tarea>
            {
                new Tarea{Id=1,EmpleadoId=1,Fecha=new DateTime(2021,05,18),Name="Limpiar mesas"},
                new Tarea{Id=2,EmpleadoId=1,Fecha=new DateTime(2021,05,20),Name="Ventilación"},
                new Tarea{Id=3,EmpleadoId=2,Fecha=new DateTime(2021,05,18),Name="Gasolina"}
            };
            tareas.ForEach(s => context.Tareas.Add(s));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
