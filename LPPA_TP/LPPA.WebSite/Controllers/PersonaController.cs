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
    public class PersonaController : Controller
    {
        //private LPPA_Model db = new LPPA_Model();
        private PersonaProcessController persona_process = new PersonaProcessController();
        private BancoProcessController banco_process = new BancoProcessController();

        // GET: Persona
        public ActionResult Index()
        {
            //var persona = db.Persona.Include(p => p.Banco).Include(p => p.Persona2);
            var persona = persona_process.GetAll();
            return View(persona.ToList());
        }

        // GET: Persona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Persona persona = db.Persona.Find(id);
            Persona persona = persona_process.GetById(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            ViewBag.id_banco = new SelectList(banco_process.GetAll(), "id_banco", "nombre");
            ViewBag.conyugue_de = new SelectList(persona_process.GetAll(), "id_persona", "nombre");
            return View();
        }

        // POST: Persona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_persona,nombre,apellido,conyugue_de,fecha_nacimiento,sexo,tipo_documento,nro_documento,domicilio,situacion_laboral,ingreso_promedio,id_banco,documentacion_adjunta,RowId,CreatedOn,CreatedBy,ChangedOn,ChangedBy,DeletedOn,DeletedBy,IsDeleted")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                persona_process.Create(persona);
                //db.Persona.Add(persona);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_banco = new SelectList(banco_process.GetAll(), "id_banco", "nombre", persona.id_banco);
            ViewBag.conyugue_de = new SelectList(persona_process.GetAll(), "id_persona", "nombre", persona.conyugue_de);
            return View(persona);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Persona persona = db.Persona.Find(id);
            Persona persona = persona_process.GetById(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_banco = new SelectList(banco_process.GetAll(), "id_banco", "nombre", persona.id_banco);
            ViewBag.conyugue_de = new SelectList(persona_process.GetAll(), "id_persona", "nombre", persona.conyugue_de);
            return View(persona);
        }

        // POST: Persona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_persona,nombre,apellido,conyugue_de,fecha_nacimiento,sexo,tipo_documento,nro_documento,domicilio,situacion_laboral,ingreso_promedio,id_banco,documentacion_adjunta")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                persona_process.Edit(persona);
                return RedirectToAction("Index");
            }
            ViewBag.id_banco = new SelectList(banco_process.GetAll(), "id_banco", "nombre", persona.id_banco);
            ViewBag.conyugue_de = new SelectList(persona_process.GetAll(), "id_persona", "nombre", persona.conyugue_de);
            return View(persona);
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Persona persona = db.Persona.Find(id);
            Persona persona = persona_process.GetById(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Persona persona = db.Persona.Find(id);
            Persona persona = persona_process.GetById(id);
            persona_process.Delete(persona);
            //db.Persona.Remove(persona);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                persona_process.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
