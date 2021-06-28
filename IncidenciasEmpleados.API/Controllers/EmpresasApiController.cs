using IncidenciasEmpleados.Entities;
using IncidenciasEmpleados.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace IncidenciasEmpleados.Controllers
{
    public class EmpresasApiController : ApiController
    {

        private readonly IEmpresaService _service;

        public EmpresasApiController(IEmpresaService service)
        {
            _service = service;
        }

        // GET: api/EmpresasApi
        /// <summary>
        /// Método que devuelve el listado de empresas
        /// </summary>
        /// <returns>Listado de empresas</returns>
        public IHttpActionResult GetEmpresas()
        {
            List<EmpresaDTO> empleados = _service.GetEmpresas();
            return Ok(empleados);
        }

        // GET: api/EmpresasApi/5
        /// <summary>
        /// Método que devuelve la empresa especificado en el parámetro id
        /// </summary>
        /// <param name="id">Número identificativo de la empresa</param>
        /// <returns>Empresa identificada en el parametro</returns>
        [ResponseType(typeof(Empresa))]
        public IHttpActionResult GetEmpresa(int id)
        {
            Empresa empresa = _service.GetEmpresa(id);
            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }

        // PUT: api/EmpresasApi/5
        /// <summary>
        /// Método que actualiza la empresa pasada como parámetro
        /// </summary>
        /// <param name="empresa">Empleado a actualizar</param>
        /// <returns>Estado de la petición</returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpresa(Empresa empresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           try
            {
                _service.UpdateEmpresa( empresa);
            }
            catch (Exception)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EmpresasApi
        /// <summary>
        /// Método que crea una nueva empresa con el parámetro pasado 
        /// </summary>
        /// <param name="empresa">Empresa a incluir</param>
        /// <returns>Estado de la petición</returns>
        [ResponseType(typeof(Empresa))]
        public IHttpActionResult PostEmpresa(Empresa empresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.AddEmpresa(empresa);

            return CreatedAtRoute("DefaultApi", new { id = empresa.Id }, empresa);
        }

        // DELETE: api/EmpresasApi/5
        /// <summary>
        /// Método que elimina la empresa cuyo identificador se ha pasado como parámetro
        /// </summary>
        /// <param name="id">Identificador de la empresa a eliminar</param>
        /// <returns>Estado de la petición</returns>
        [ResponseType(typeof(Empresa))]
        public IHttpActionResult DeleteEmpresa(int id)
        {
            if (_service.DeleteEmpresa(id))
            {
                Empresa empresa = _service.GetEmpresa(id);
                return Ok(empresa);
            }
            else
                return NotFound();
        }

    }
}