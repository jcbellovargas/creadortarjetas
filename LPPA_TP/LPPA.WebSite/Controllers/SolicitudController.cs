using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities;
using BusinessComponents;
using LPPA.Process;

namespace LPPA.WebSite.Controllers
{
    public class SolicitudController : Controller
    {
        private SolicitudProcessController process = new SolicitudProcessController();
        private PersonaProcessController persona_process = new PersonaProcessController();
        private TerminalProcessController terminal_process = new TerminalProcessController();
        private BancoProcessController banco_process = new BancoProcessController();
        private TarjetaProcessController tarjeta_process = new TarjetaProcessController();

        // GET: Solicitud
        public ActionResult Index()
        {
            return View(process.GetAll());
        }

        // GET: Solicitud/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud solicitud = process.GetById(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            TempData["solicitud"] = solicitud;
            return View(solicitud);
        }

        // GET: Solicitud/Create
        public ActionResult Create()
        {
            ViewBag.id_persona = new SelectList(persona_process.GetAll(), "id_persona", "nombre");
            ViewBag.id_terminal = new SelectList(terminal_process.GetAll(), "id_terminal", "nombre");
            ViewBag.id_banco = new SelectList(banco_process.GetAll(), "id_banco", "nombre");
            return View();
        }

        // POST: Solicitud/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Persona,id_solicitud,fecha_solicitud,estado_tramite,id_terminal,id_persona,RowId,CreatedOn,CreatedBy,ChangedOn,ChangedBy,DeletedOn,DeletedBy,IsDeleted")] Solicitud solicitud)
        public ActionResult Create( Solicitud solicitud, string conyugue)
        {

            solicitud.CreatedBy = User.Identity.Name;
            // Titular
            solicitud.Persona.CreatedBy = User.Identity.Name;
            // Conyugue
            if (conyugue == "No")
            {
                solicitud.Persona.Persona2 = null;
            }else{
                solicitud.Persona.Persona2.CreatedBy = User.Identity.Name;
            }
            process.Create(solicitud);
            return RedirectToAction("Index");
        }

        // GET: Solicitud/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud solicitud = process.GetById(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_persona = new SelectList(persona_process.GetAll(), "id_persona", "nombre", solicitud.id_persona);
            ViewBag.id_terminal = new SelectList(terminal_process.GetAll(), "id_terminal", "nombre", solicitud.id_terminal);
            ViewBag.id_banco = new SelectList(banco_process.GetAll(), "id_banco", "nombre", solicitud.Persona.id_banco);
            TempData["solicitud"] = solicitud;
            return View(solicitud);
        }

        // POST: Solicitud/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_solicitud,fecha_solicitud,estado_tramite,entidad_emisora,id_terminal,id_persona")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                var current_solicitud = ((Solicitud)TempData["solicitud"]);
                if (current_solicitud.id_solicitud != solicitud.id_solicitud)
                {
                    return HttpNotFound();
                }
                solicitud.ChangedBy = current_solicitud.ChangedBy;
                solicitud.ChangedOn = current_solicitud.ChangedOn;
                solicitud.CreatedBy = current_solicitud.CreatedBy;
                solicitud.CreatedOn = current_solicitud.CreatedOn;
                solicitud.DeletedBy = current_solicitud.DeletedBy;
                solicitud.DeletedOn = current_solicitud.DeletedOn;
                solicitud.IsDeleted = current_solicitud.IsDeleted;
                solicitud.RowId = current_solicitud.RowId;
                solicitud.ChangedBy = User.Identity.Name;
                process.Edit(solicitud);
                return RedirectToAction("Index");
            }
            ViewBag.id_persona = new SelectList(persona_process.GetAll(), "id_persona", "nombre", solicitud.id_persona);
            ViewBag.id_terminal = new SelectList(terminal_process.GetAll(), "id_terminal", "nombre", solicitud.id_terminal);
            return View(solicitud);
        }

        // GET: Solicitud/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud solicitud = process.GetById(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            TempData["solicitud"] = solicitud;
            return View(solicitud);
        }

        // POST: Solicitud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id != ((Solicitud)TempData["solicitud"]).id_solicitud)
            {
                return HttpNotFound();
            }
            
            Solicitud solicitud = process.GetById(id);
            solicitud.DeletedBy = User.Identity.Name;
            process.Delete(solicitud);
            return RedirectToAction("Index");
        }

        public ActionResult CreateCard(int id) {
            Solicitud solicitud = (Solicitud)TempData["solicitud"];

            if (solicitud.estado_tramite != "APROBADA" || solicitud.id_solicitud != id) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            solicitud.CreatedBy = User.Identity.Name;
            tarjeta_process.CreateFromSolicitud(solicitud);
            return View(solicitud);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                process.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
