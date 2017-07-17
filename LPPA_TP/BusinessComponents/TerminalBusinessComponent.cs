using DataComponents;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BusinessComponents
{
    public class TerminalBusinessComponent : BaseBusinessComponent
    {
        private TerminalDataComponent dal;
        public TerminalBusinessComponent()
        {
            dal = new TerminalDataComponent();
        }

        public void Create(Terminal Terminal)
        {
            dal.Create(Terminal);
        }

        public Terminal GetById(int? id)
        {
            return dal.GetById(id);
        }

        public List<Terminal> GetAll()
        {
            return dal.GetAll();
        }

        public void Edit(Terminal Terminal)
        {
            dal.Edit(Terminal);
        }

        public void Delete(Terminal Terminal)
        {
            dal.Delete(Terminal);
        }
    }
}
