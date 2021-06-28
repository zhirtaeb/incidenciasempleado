using IncidenciasEmpleados.DAL;
using IncidenciasEmpleados.Entities;
using IncidenciasEmpleados.Services.Abstractions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace IncidenciasEmpleados.Services
{
    public class EmpresaService: IEmpresaService
    {

        
        public List<EmpresaDTO> GetEmpresas()
        {
            using (var db = new IncidenciasContext())
            {
                return db.Empresas.Select(x => new EmpresaDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            }
        }
        
        public Empresa GetEmpresa(int id)
        {
            using (var db = new IncidenciasContext())
            {
                return db.Empresas.Find(id);
            }
           
        }

        public bool UpdateEmpresa(Empresa empresa)
        {
            using (var db = new IncidenciasContext())
            {
                db.Entry(empresa).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return true;
            }
        }
        private bool IsEmpresa(int id)
        {
            using (var db = new IncidenciasContext())
            {
                return db.Empresas.Count(e => e.Id == id) > 0;
            }
        }

        public void AddEmpresa(Empresa empresa)
        {
            using (var db = new IncidenciasContext())
            {
                db.Empresas.Add(empresa);
                db.SaveChanges();
            }
        }

       public bool DeleteEmpresa(int id)
        {
            if (!IsEmpresa(id))
                return false;

            using (var db = new IncidenciasContext())
            {
                Empresa empresa = db.Empresas.Find(id);
                db.Empresas.Remove(empresa);
                db.SaveChanges();
            }
           
            return true;
        }

    }
}
