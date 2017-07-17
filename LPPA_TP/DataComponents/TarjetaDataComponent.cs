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
    public class TarjetaDataComponent : BaseDataComponent
    {
        public TarjetaDataComponent() { }

        public void Create(Tarjeta tarjeta)
        {
            tarjeta.CreatedOn = DateTime.Now;
            tarjeta.ChangedOn = DateTime.Now;
            tarjeta.IsDeleted = false;
            tarjeta.RowId = Guid.NewGuid();
            db.Tarjeta.Add(tarjeta);
            db.SaveChanges();
        }

        public List<Tarjeta> GetAll()
        {
            return db.Tarjeta.Where(b => b.IsDeleted == false).ToList();
            //return db.tarjeta.ToList();
        }

        public void Edit(Tarjeta tarjeta)
        {
            tarjeta.ChangedOn = DateTime.Now;
            db.Entry(tarjeta).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Tarjeta tarjeta)
        {
            tarjeta.DeletedOn = DateTime.Now;
            tarjeta.IsDeleted = true;
            db.Entry(tarjeta).State = EntityState.Modified;
            //db.tarjeta.Remove(Tarjeta);
            db.SaveChanges();
        }

        public Tarjeta GetById(int? id)
        {
            return db.Tarjeta.Find(id);
        }
    }
}
