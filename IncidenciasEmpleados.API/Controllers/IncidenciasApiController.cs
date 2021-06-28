using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using IncidenciasEmpleados.Entities;
using IncidenciasEmpleados.Services.Abstractions;

namespace IncidenciasEmpleados.Controllers
{
    public class IncidenciasApiController : ApiController
    {

        private readonly IIncidenciaService _service;

        public IncidenciasApiController(IIncidenciaService service)
        {
            _service = service;
        }

        // GET: api/IncidenciasApi
        /// <summary>
        /// Método que devuelve el listado completo de incidencias
        /// </summary>
        /// <returns>Listado de incidencias</returns>
        public IHttpActionResult GetIncidencias()
        {
            List<IncidenciaDTO> incidencias = _service.GetIncidencias();
            return Ok(incidencias);
        }

        // GET: api/IncidenciasApi/5
        /// <summary>
        /// Método que devuelve la incidencia especificado en el parámetro id
        /// </summary>
        /// <param name="id">Número identificativo de la incidencia</param>
        /// <returns>Incidencia identificada en el parametro</returns>
        [ResponseType(typeof(IncidenciaDTO))]
        public IHttpActionResult GetIncidencia(int id)
        {
            IncidenciaDTO incidencia = _service.GetIncidencia(id);
            if (incidencia == null)
            {
                return NotFound();
            }

            return Ok(incidencia);
        }

        // PUT: api/IncidenciasApi/5
        /// <summary>
        /// Método que actualiza la incidencia pasada como parámetro
        /// </summary>
        /// <param name="incidencia">Incidencia a actualizar</param>
        /// <returns>Estado de la petición</returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIncidencia(Incidencia incidencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_service.UpdateIncidencia(incidencia))
            {
                return NotFound();
            }
            else
            {
                return StatusCode(HttpStatusCode.NoContent); ;
            }

        }

        // POST: api/IncidenciasApi
        /// <summary>
        /// Método que crea una nueva incidencia con el parámetro pasado 
        /// </summary>
        /// <param name="incidencia">Incidencia a incluir</param>
        /// <returns>Estado de la petición</returns>
        [ResponseType(typeof(Incidencia))]
        public IHttpActionResult PostIncidencia(Incidencia incidencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _service.AddIncidencia(incidencia);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/IncidenciasApi/5
        /// <summary>
        /// Método que elimina la incidencia cuyo identificador se ha pasado como parámetro
        /// </summary>
        /// <param name="id">Identificador de la incidencia a eliminar</param>
        /// <returns>Estado de la petición</returns>
        [ResponseType(typeof(Incidencia))]
        public IHttpActionResult DeleteIncidencia(int id)
        {
            IncidenciaDTO incidencia = _service.GetIncidencia(id);
            if (_service.DeleteIncidencia(id))
                return Ok(incidencia);
            else
                return NotFound();
        }


        // GET api/IncidenciasApi/IncidenciasEmpleado/{idEmpleado}
        /// <summary>
        /// Método que lista todas las incidencias del empleado indicado en el parámetro
        /// </summary>
        /// <param name="idEmpleado">Identificador del empleado</param>
        /// <returns>Lista de incidencias filtrada por empleado</returns>
        [Route("api/IncidenciasApi/IncidenciasEmpleado/{idEmpleado}")]
        public IHttpActionResult GetIncidenciasEmpleado(int idEmpleado)
        {

            try
            {
                List<IncidenciaDTO> incidencias = _service.GetIncidenciasEmpleado(idEmpleado);
                return Ok(incidencias);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}