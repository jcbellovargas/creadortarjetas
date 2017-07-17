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
    public class TerminalController : Controller
    {
        private TerminalProcessController process = new TerminalProcessController();

        // GET: Terminal
        public ActionResult Index()
        {
            return View(process.GetAll());
        }

        // GET: Terminal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminal terminal = process.GetById(id);
            if (terminal == null)
            {
                return HttpNotFound();
            }
            return View(terminal);
        }

        // GET: Terminal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Terminal/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_terminal,nombre,descripcion,direccion")] Terminal terminal)
        {
            if (ModelState.IsValid)
            {
                terminal.CreatedBy = User.Identity.Name;
                process.Create(terminal);
                return RedirectToAction("Index");
            }

            return View(terminal);
        }

        // GET: Terminal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminal terminal = process.GetById(id);
            if (terminal == null)
            {
                return HttpNotFound();
            }
            TempData["terminal"] = terminal;
            return View(terminal);
        }

        // POST: Terminal/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_terminal,nombre,descripcion,direccion")] Terminal terminal)
        {
            if (ModelState.IsValid)
            {
                var current_terminal = ((Terminal)TempData["terminal"]);
                if (current_terminal.id_terminal != terminal.id_terminal)
                {
                    return HttpNotFound();
                }
                terminal.ChangedBy = current_terminal.ChangedBy;
                terminal.ChangedOn = current_terminal.ChangedOn;
                terminal.CreatedBy = current_terminal.CreatedBy;
                terminal.CreatedOn = current_terminal.CreatedOn;
                terminal.DeletedBy = current_terminal.DeletedBy;
                terminal.DeletedOn = current_terminal.DeletedOn;
                terminal.IsDeleted = current_terminal.IsDeleted;
                terminal.RowId = current_terminal.RowId;
                terminal.ChangedBy = User.Identity.Name;
                process.Edit(terminal);
                return RedirectToAction("Index");
            }
            return View(terminal);
        }

        // GET: Terminal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminal terminal = process.GetById(id);
            if (terminal == null)
            {
                return HttpNotFound();
            }
            TempData["terminal"] = terminal;
            return View(terminal);
        }

        // POST: Terminal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id != ((Terminal)TempData["terminal"]).id_terminal)
            {
                return HttpNotFound();
            }
            Terminal terminal = process.GetById(id);
            terminal.DeletedBy = User.Identity.Name;
            process.Delete(terminal);
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
