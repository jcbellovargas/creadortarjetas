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
    public class TerminalDataComponent : BaseDataComponent
    {
        public TerminalDataComponent() { }

        public void Create(Terminal Terminal)
        {
            Terminal.CreatedOn = DateTime.Now;
            Terminal.ChangedOn = DateTime.Now;
            Terminal.IsDeleted = false;
            Terminal.RowId = Guid.NewGuid();
            db.Terminal.Add(Terminal);
            db.SaveChanges();
        }

        public List<Terminal> GetAll()
        {
            return db.Terminal.Where(b => b.IsDeleted == false).ToList();
            //return db.Terminal.ToList();
        }

        public void Edit(Terminal Terminal)
        {
            Terminal.ChangedOn = DateTime.Now;
            db.Entry(Terminal).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(Terminal Terminal)
        {
            Terminal.DeletedOn = DateTime.Now;
            Terminal.IsDeleted = true;
            db.Entry(Terminal).State = EntityState.Modified;
            //db.Terminal.Remove(Terminal);
            db.SaveChanges();
        }

        public Terminal GetById(int? id)
        {
            return db.Terminal.Find(id);
        }
    }
}
