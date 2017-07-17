using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessComponents;
using Entities;
using log4net;
using System.Reflection;
using LPPA.Process;

namespace LPPA.WebSite.Controllers
{
    public class BancoController : Controller
    {
        private BancoProcessController process = new BancoProcessController();
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // GET: Banco
        public ActionResult Index()
        {
            this.log.Debug("Debug message");
            this.log.Info("Info message");
            this.log.Warn("Warning message");
            this.log.Error("Error message");
            this.log.Fatal("Fatal message");
            return View(process.GetAll());
        }

        // GET: Banco/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banco banco = process.GetById(id);
            if (banco == null)
            {
                return HttpNotFound();
            }
            return View(banco);
        }

        // GET: Banco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banco/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_banco,nombre,descripcion,direccion_central,email,responsable")] Banco banco)
        {
            if (ModelState.IsValid)
            {
                banco.CreatedBy = User.Identity.Name;
                process.Create(banco);
                return RedirectToAction("Index");
            }

            return View(banco);
        }

        // GET: Banco/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banco banco = process.GetById(id);
            if (banco == null)
            {
                return HttpNotFound();
            }
            TempData["banco"] = banco;
            return View(banco);
        }

        // POST: Banco/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_banco,nombre,descripcion,direccion_central,email,responsable")] Banco banco)
        {
            if (ModelState.IsValid)
            {
                var current_banco = ((Banco)TempData["banco"]);
                if (current_banco.id_banco != banco.id_banco)
                {
                    return HttpNotFound();
                }
                banco.ChangedBy = current_banco.ChangedBy;
                banco.ChangedOn = current_banco.ChangedOn;
                banco.CreatedBy = current_banco.CreatedBy;
                banco.CreatedOn = current_banco.CreatedOn;
                banco.DeletedBy = current_banco.DeletedBy;
                banco.DeletedOn = current_banco.DeletedOn;
                banco.IsDeleted = current_banco.IsDeleted;
                banco.RowId = current_banco.RowId;
                banco.ChangedBy = User.Identity.Name;
                process.Edit(banco);
                return RedirectToAction("Index");
            }
            return View(banco);
        }

        // GET: Banco/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Banco banco = process.GetById(id);
            if (banco == null)
            {
                return HttpNotFound();
            }
            TempData["banco"] = banco;
            return View(banco);
        }

        // POST: Banco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (id != ((Banco)TempData["banco"]).id_banco) {
                return HttpNotFound();
            }
            Banco banco = process.GetById(id);
            banco.DeletedBy = User.Identity.Name;
            process.Delete(banco);
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
