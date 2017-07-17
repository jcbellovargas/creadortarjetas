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
    public class PersonaDataComponent : BaseDataComponent
    {
        public PersonaDataComponent(){}

        public void Create(Persona Persona) {
            Persona.CreatedOn = DateTime.Now;
            Persona.ChangedOn = DateTime.Now;
            Persona.IsDeleted = false;
            Persona.RowId = Guid.NewGuid();
            db.Persona.Add(Persona);
            db.SaveChanges();
        }

        public List<Persona> GetAll()
        {
            //return db.Persona.Where(b => b.IsDeleted == false).ToList();
            return db.Persona.Include(p => p.Banco).Include(p => p.Persona2).Where(p => p.IsDeleted == false).ToList();
            //return db.Persona.ToList();
        }

        public void Edit(Persona Persona)
        {
            Persona.ChangedOn = DateTime.Now;
            db.Entry(Persona).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Persona Persona)
        {
            Persona.DeletedOn = DateTime.Now;
            Persona.IsDeleted = true;
            db.Entry(Persona).State = EntityState.Modified;
            //db.Persona.Remove(Persona);
            db.SaveChanges();
        }

        public Persona GetById(int? id)
        {
            return db.Persona.Find(id);
        }
    }
}
