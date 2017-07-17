using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Data.Entity;

namespace DataComponents
{
    public class SolicitudDataComponent : BaseDataComponent
    {
        public SolicitudDataComponent() { }

        public void Create(Solicitud solicitud)
        {
            // Titular
            solicitud.Persona.CreatedOn = DateTime.Now;
            solicitud.Persona.ChangedOn = DateTime.Now;
            solicitud.Persona.IsDeleted = false;
            solicitud.Persona.RowId = Guid.NewGuid();
            // Conyugue
            if (solicitud.Persona.Persona2 != null) {
                solicitud.Persona.Persona2.CreatedOn = DateTime.Now;
                solicitud.Persona.Persona2.ChangedOn = DateTime.Now;
                solicitud.Persona.Persona2.IsDeleted = false;
                //solicitud.Persona.Persona2.conyugue_de = solicitud.Persona.id_persona;
                solicitud.Persona.Persona2.RowId = Guid.NewGuid();
            }
            solicitud.CreatedOn = DateTime.Now;
            solicitud.ChangedOn = DateTime.Now;
            solicitud.IsDeleted = false;
            solicitud.RowId = Guid.NewGuid();
            solicitud.fecha_solicitud = DateTime.Now;
            db.Solicitud.Add(solicitud);
            db.SaveChanges();
        }

        public List<string> GetAllStatus()
        {
            return db.Solicitud.Where(s => s.IsDeleted == false).Select(s => s.estado_tramite).ToList();
        }

        public List<string> GetTerminales()
        {
            return db.Solicitud.Where(s => s.IsDeleted == false).Select(s => s.Terminal.nombre).ToList();
        }

        public List<string> GetEntidadesEmisoras()
        {
            return db.Solicitud.Where(s => s.IsDeleted == false).Select(s => s.entidad_emisora).ToList();
        }

        public List<Solicitud> GetAll()
        {
            return db.Solicitud.Include(s => s.Persona).Include(s => s.Terminal).Where(s => s.IsDeleted == false).ToList();
        }

        public void Edit(Solicitud solicitud)
        {
            solicitud.ChangedOn = DateTime.Now;
            db.Entry(solicitud).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Solicitud solicitud)
        {
            solicitud.DeletedOn = DateTime.Now;
            solicitud.IsDeleted = true;
            db.Entry(solicitud).State = EntityState.Modified;
            //db.Solicitud.Remove(solicitud);
            db.SaveChanges();
        }

        public Solicitud GetById(int? id)
        {
            return db.Solicitud.Find(id);
        }
    }
}
