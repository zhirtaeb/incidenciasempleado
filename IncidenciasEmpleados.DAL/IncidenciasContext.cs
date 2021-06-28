using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncidenciasEmpleados.Entities;

namespace IncidenciasEmpleados.DAL
{
    public class IncidenciasContext:DbContext
    {

        public IncidenciasContext() : base("IncidenciasContext")
        {
            Database.SetInitializer<IncidenciasContext>(new DropCreateDatabaseAlways<IncidenciasContext>());
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Incidencia> Incidencias { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
