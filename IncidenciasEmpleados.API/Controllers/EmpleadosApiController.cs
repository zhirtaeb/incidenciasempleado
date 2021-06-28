using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using IncidenciasEmpleados.Entities;
using IncidenciasEmpleados.Services.Abstractions;

namespace IncidenciasEmpleados.API.Controllers
{
    public class EmpleadosApiController : ApiController
    {

        private readonly IEmpleadoService _service;

        public EmpleadosApiController(IEmpleadoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Método que devuelve el listado de empleados
        /// </summary>
        /// <returns>Listado de empleados</returns>
        public IHttpActionResult GetEmpleados()
        {
            List<EmpleadoDTO> empleados = _service.GetEmpleados();
            return Ok(empleados);
        }

        // GET: api/EmpleadosApi/5
        /// <summary>
        /// Método que devuelve el empleado especificado en el parámetro id
        /// </summary>
        /// <param name="id">Número identificativo del empleado</param>
        /// <returns>Empleado identificado en el parametro</returns>
        [ResponseType(typeof(EmpleadoDTO))]
        public IHttpActionResult GetEmpleado(int id)
        {
            EmpleadoDTO empleado = _service.GetEmpleado(id);
            if (empleado == null)
            {
                return NotFound();
            }

            return Ok(empleado);
        }

        // PUT: api/EmpleadosApi/5
        /// <summary>
        /// Método que actualiza el empleado pasado como parámetro
        /// </summary>
        /// <param name="empleado">Empleado a actualizar</param>
        /// <returns>Estado de la petición</returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpleado(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!_service.UpdateEmpleado(empleado))
            { 
                return NotFound();
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent); 
            }
            
        }

        // POST: api/EmpleadosApi
        /// <summary>
        /// Método que crea un nuevo empleado con el parámetro pasado 
        /// </summary>
        /// <param name="empleado">Empleado a incluir</param>
        /// <returns>Estado de la petición</returns>
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult PostEmpleado(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.AddEmpleado(empleado);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/EmpleadosApi/5
        /// <summary>
        /// Método que elimina el empleado cuyo identificador se ha pasado como parámetro
        /// </summary>
        /// <param name="id">Identificador del empleado a eliminar</param>
        /// <returns>Estado de la petición</returns>
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult DeleteEmpleado(int id)
        {
            EmpleadoDTO empleado = _service.GetEmpleado(id);
            if (_service.DeleteEmpleado(id))
                return Ok(empleado);
            else
                return NotFound();
            
        }

    }
}