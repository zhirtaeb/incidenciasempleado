using IncidenciasEmpleados.Services;
using IncidenciasEmpleados.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Unity;
using Unity.WebApi;

namespace IncidenciasEmpleados.API
{
    public static class UnityConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();

            container.RegisterType<IEmpleadoService, EmpleadoService>();
            container.RegisterType<IEmpresaService, EmpresaService>();
            container.RegisterType<IIncidenciaService, IncidenciaService>();
            container.RegisterType<ITareaService, TareaService>();

            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}