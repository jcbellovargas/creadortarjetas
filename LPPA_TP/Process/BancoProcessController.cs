using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessComponents;
using Entities;

namespace LPPA.Process
{
    public class BancoProcessController
    {
        private BancoBusinessComponent bll = new BancoBusinessComponent();
        public List<Banco> GetAll()
        {
            return bll.GetAll();
        }

        public void Create(Banco banco)
        {
            bll.Create(banco);
        }

        public Banco GetById(int? id)
        {
            return bll.GetById(id);
        }

        public void Delete(Banco banco)
        {
            bll.Delete(banco);
        }

        public void Edit(Banco banco)
        {
            bll.Edit(banco);
        }

        public void Dispose()
        {
            bll.Dispose();
        }
    }
}
