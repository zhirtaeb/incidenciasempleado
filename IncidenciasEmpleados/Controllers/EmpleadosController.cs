using System;
using System.Collections.Generic;
using System.Web.Mvc;
using IncidenciasEmpleados.Entities;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using IncidenciasEmpleados.Helpers;

namespace IncidenciasEmpleados.Controllers
{
    public class EmpleadosController : Controller
    {
        //Hosted web API REST Service base url  
        private const string baseUrl = "http://localhost:52389/";
        private const string GetUrl = "api/EmpleadosApi/";
        private const string EmpresasURL = "api/EmpresasApi/";
        private const string IncidenciasURL = "api/IncidenciasApi/IncidenciasEmpleado/";

        public async Task<ActionResult> Index()
        {
            List<EmpleadoDTO> empleados = await HttpClientHelper.GetAllAsync<EmpleadoDTO>(baseUrl, GetUrl);
            return View(empleados);
            
        }

        // GET: Empleados/Details/5
        public async Task<ActionResult> Details(int? id)
        {

            
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoDTO empleado = await HttpClientHelper.GetAsync<EmpleadoDTO>(baseUrl, GetUrl, id.Value.ToString());
            if (empleado == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.IncidenciaList = await HttpClientHelper.GetAllAsync<IncidenciaDTO>(baseUrl, IncidenciasURL, id);

            return View(empleado);
            
        }

        // GET: Empleados/Create
        public async Task<ActionResult> Create()
        {
            List<EmpresaDTO> empresas = await HttpClientHelper.GetAllAsync<EmpresaDTO>(baseUrl, EmpresasURL);

            ViewBag.EmpresaId = new SelectList(empresas, "Id", "Name");
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,EmpresaId")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl + "api/EmpleadosApi/");

                    //HTTP POST
                    var postTask = await client.PostAsJsonAsync<Empleado>("empleado", empleado);
                    
                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }

                }
            }
            List<EmpresaDTO> empresas = await HttpClientHelper.GetAllAsync<EmpresaDTO>(baseUrl, EmpresasURL);
            ViewBag.EmpresaId = new SelectList(empresas, "Id", "Name", empleado.EmpresaId);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoDTO empleado = await HttpClientHelper.GetAsync<EmpleadoDTO>(baseUrl, GetUrl, id.Value.ToString());
            if (empleado == null)
            {
                return HttpNotFound();
            }
            
            List<EmpresaDTO> empresas = await HttpClientHelper.GetAllAsync<EmpresaDTO>(baseUrl, EmpresasURL);
            ViewBag.EmpresaId = new SelectList(empresas, "Id", "Name", empleado.EmpresaId);
            return View(empleado);
        }

        // PUT: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,EmpresaId")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl + GetUrl);

                    var putTask = await client.PutAsJsonAsync<Empleado>("empleado", empleado);
                }
                return RedirectToAction("Index");
            }
            List<EmpresaDTO> empresas = await HttpClientHelper.GetAllAsync<EmpresaDTO>(baseUrl, EmpresasURL);
            ViewBag.EmpresaId = new SelectList(empresas, "Id", "Name", empleado.EmpresaId);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoDTO empleado = await HttpClientHelper.GetAsync<EmpleadoDTO>(baseUrl, GetUrl, id.Value.ToString());
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
             using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl + GetUrl);

                var putTask = await client.DeleteAsync( id.ToString());
            }
            return RedirectToAction("Index");
        }

    }
}
