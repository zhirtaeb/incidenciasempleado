using Microsoft.VisualStudio.TestTools.UnitTesting;
using IncidenciasEmpleados.Services;

namespace IncidenciasEmpleados.Tests.Services
{
    [TestClass]
    public class EmpresaServiceTest
    {
        [TestMethod]
        public void AddEmpresa()
        {
            EmpresaService service = new EmpresaService();

            var empresas = service.GetEmpresas().Count;

            service.AddEmpresa(new Entities.Empresa()
            { 
                Name = "Test"
            });

            // Declarar
            Assert.AreEqual(empresas + 1, service.GetEmpresas().Count);
        }
    }
}
