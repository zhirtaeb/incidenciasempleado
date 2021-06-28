using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IncidenciasEmpleados.DAL;
using IncidenciasEmpleados.Entities;
using IncidenciasEmpleados.Helpers;

namespace IncidenciasEmpleados.Controllers
{
    public class IncidenciasController : Controller
    {
        private const string baseUrl = "http://localhost:52389/";
        private const string GetUrl = "api/IncidenciasApi/";
        private const string EmpleadosURL = "api/EmpleadosApi/";

        // GET: Incidencias
        public async Task<ActionResult> Index()
        {
            List<IncidenciaDTO> incidencias = await HttpClientHelper.GetAllAsync<IncidenciaDTO>(baseUrl, GetUrl);
            return View(incidencias);

        }

       
        // GET: Incidencias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncidenciaDTO incidencia = await HttpClientHelper.GetAsync<IncidenciaDTO>(baseUrl, GetUrl, id.Value.ToString());
            if (incidencia == null)
            {
                return HttpNotFound();
            }
            return View(incidencia);
        }

        // GET: Incidencias/Create
        public async Task<ActionResult> Create()
        {
            List<EmpleadoDTO> empleados = await HttpClientHelper.GetAllAsync<EmpleadoDTO>(baseUrl, EmpleadosURL);
            ViewBag.EmpleadoId = new SelectList(empleados, "Id", "Name");
            return View();
        }
   

        // POST: Incidencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Fecha,EmpleadoId")] Incidencia incidencia)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl + GetUrl);

                var postTask = await client.PostAsJsonAsync<Incidencia>("incidencia", incidencia);

                if (postTask.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }

            List<EmpleadoDTO> empleados = await HttpClientHelper.GetAllAsync<EmpleadoDTO>(baseUrl, EmpleadosURL);
            ViewBag.EmpleadoId = new SelectList(empleados, "Id", "Name");
            return View(incidencia);
        }

        
        // GET: Incidencias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncidenciaDTO incidencia = await HttpClientHelper.GetAsync<IncidenciaDTO>(baseUrl, GetUrl, id.Value.ToString());
            if (incidencia == null)
            {
                return HttpNotFound();
            }
            List<EmpleadoDTO> empleados = await HttpClientHelper.GetAllAsync<EmpleadoDTO>(baseUrl, EmpleadosURL);
            ViewBag.EmpleadoId = new SelectList(empleados, "Id", "Name", incidencia.EmpleadoId);
            return View(incidencia);
        }

        // PUT: Incidencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Fecha,EmpleadoId")] Incidencia incidencia)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl + GetUrl);

                    var putTask = await client.PutAsJsonAsync<Incidencia>("incidencia", incidencia);
                }
                return RedirectToAction("Index");
            }
            List<EmpleadoDTO> empleados = await HttpClientHelper.GetAllAsync<EmpleadoDTO>(baseUrl, EmpleadosURL);
            ViewBag.EmpleadoId = new SelectList(empleados, "Id", "Name", incidencia.EmpleadoId);
            return View(incidencia);
        }

        // GET: Incidencias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncidenciaDTO incidencia = await HttpClientHelper.GetAsync<IncidenciaDTO>(baseUrl, GetUrl, id.Value.ToString());
            if (incidencia == null)
            {
                return HttpNotFound();
            }
            return View(incidencia);
        }

        // POST: Incidencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl + GetUrl);

                var putTask = await client.DeleteAsync(id.ToString());
            }
            return RedirectToAction("Index");
        }

    }
}
