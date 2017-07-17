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
    public class BancoDataComponent : BaseDataComponent
    {
        public BancoDataComponent(){}

        public void Create(Banco banco) {
            banco.CreatedOn = DateTime.Now;
            banco.ChangedOn = DateTime.Now;
            banco.IsDeleted = false;
            banco.RowId = Guid.NewGuid();
            db.Banco.Add(banco);
            db.SaveChanges();
        }

        public List<Banco> GetAll()
        {
            return db.Banco.Where(b => b.IsDeleted == false).ToList();
            //return db.Banco.ToList();
        }

        public void Edit(Banco banco)
        {
            banco.ChangedOn = DateTime.Now;
            db.Entry(banco).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Banco banco)
        {
            banco.DeletedOn = DateTime.Now;
            banco.IsDeleted = true;
            db.Entry(banco).State = EntityState.Modified;
            //db.Banco.Remove(banco);
            db.SaveChanges();
        }

        public Banco GetById(int? id)
        {
            return db.Banco.Find(id);
        }
    }
}
