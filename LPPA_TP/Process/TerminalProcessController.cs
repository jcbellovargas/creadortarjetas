using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessComponents;
using Entities;

namespace LPPA.Process
{
    public class TerminalProcessController
    {
        private TerminalBusinessComponent bll = new TerminalBusinessComponent();
        public List<Terminal> GetAll()
        {
            return bll.GetAll();
        }

        public void Create(Terminal terminal)
        {
            bll.Create(terminal);
        }

        public Terminal GetById(int? id)
        {
            return bll.GetById(id);
        }

        public void Delete(Terminal terminal)
        {
            bll.Delete(terminal);
        }

        public void Edit(Terminal terminal)
        {
            bll.Edit(terminal);
        }

        public void Dispose()
        {
            bll.Dispose();
        }
    }
}
