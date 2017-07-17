using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities;
using LPPA.Process;

namespace LPPA.WebSite.Controllers
{
    public class TarjetaController : Controller
    {
        private TarjetaProcessController process = new TarjetaProcessController();
        private SolicitudProcessController solicitud_process = new SolicitudProcessController();

        // GET: Tarjeta
        public ActionResult Index()
        {
            return View(process.GetAll());
        }

        // GET: Tarjeta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjeta tarjeta = process.GetById(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta);
        }

        // GET: Tarjeta/Create
        public ActionResult Create()
        {
            ViewBag.id_solicitud = new SelectList(solicitud_process.GetAll(), "id_solicitud", "estado_tramite");
            return View();
        }

        // POST: Tarjeta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tarjeta,id_solicitud,nombre_titular,nro_tarjeta,cod_seguridad,fecha_emision,fecha_vencimiento,entidad_emisora,extension_de,limite_credito,RowId,CreatedOn,CreatedBy,ChangedOn,ChangedBy,DeletedOn,DeletedBy,IsDeleted")] Tarjeta tarjeta)
        {
            if (ModelState.IsValid)
            {
                process.Create(tarjeta);
                return RedirectToAction("Index");
            }

            ViewBag.id_solicitud = new SelectList(solicitud_process.GetAll(), "id_solicitud", "estado_tramite", tarjeta.id_solicitud);
            return View(tarjeta);
        }

        // GET: Tarjeta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjeta tarjeta = process.GetById(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_solicitud = new SelectList(solicitud_process.GetAll(), "id_solicitud", "estado_tramite", tarjeta.id_solicitud);
            return View(tarjeta);
        }

        // POST: Tarjeta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tarjeta,id_solicitud,nombre_titular,nro_tarjeta,cod_seguridad,fecha_emision,fecha_vencimiento,entidad_emisora,extension_de,limite_credito,RowId,CreatedOn,CreatedBy,ChangedOn,ChangedBy,DeletedOn,DeletedBy,IsDeleted")] Tarjeta tarjeta)
        {
            if (ModelState.IsValid)
            {
                process.Edit(tarjeta);
                return RedirectToAction("Index");
            }
            ViewBag.id_solicitud = new SelectList(solicitud_process.GetAll(), "id_solicitud", "estado_tramite", tarjeta.id_solicitud);
            return View(tarjeta);
        }

        // GET: Tarjeta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarjeta tarjeta = process.GetById(id);
            if (tarjeta == null)
            {
                return HttpNotFound();
            }
            return View(tarjeta);
        }

        // POST: Tarjeta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarjeta tarjeta = process.GetById(id);
            process.Delete(tarjeta);
            return RedirectToAction("Index");
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
