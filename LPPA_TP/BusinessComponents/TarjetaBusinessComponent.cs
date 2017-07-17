using DataComponents;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BusinessComponents
{
    public class TarjetaBusinessComponent : BaseBusinessComponent
    {
        private TarjetaDataComponent dal;
        public TarjetaBusinessComponent()
        {
            dal = new TarjetaDataComponent();
        }

        public void Create(Tarjeta tarjeta)
        {
            dal.Create(tarjeta);
        }

        public Tarjeta GetById(int? id)
        {
            return dal.GetById(id);
        }

        public List<Tarjeta> GetAll()
        {
            return dal.GetAll();
        }

        public void Edit(Tarjeta tarjeta)
        {
            dal.Edit(tarjeta);
        }

        public void Delete(Tarjeta tarjeta)
        {
            dal.Delete(tarjeta);
        }
    }
}
