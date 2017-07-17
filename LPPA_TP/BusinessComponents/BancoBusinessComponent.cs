using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataComponents;
using Entities;

namespace BusinessComponents
{
    public class BancoBusinessComponent : BaseBusinessComponent
    {
        private BancoDataComponent dal = new BancoDataComponent();
        public BancoBusinessComponent(){}

        public void Create(Banco banco)
        {
            dal.Create(banco);
        }

        public Banco GetById(int? id)
        {
            return dal.GetById(id);
        }

        public List<Banco> GetAll()
        {
           return dal.GetAll();
        }

        public void Edit(Banco banco)
        {
            dal.Edit(banco);
        }

        public void Delete(Banco banco)
        {
            dal.Delete(banco);
        }
    }
}
