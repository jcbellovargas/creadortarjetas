using Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessComponents;

namespace LPPA.Process
{
    public class SolicitudProcessController
    {
        private SolicitudBusinessComponent bll = new SolicitudBusinessComponent();
        public Solicitud GetById(int? id)
        {
            return bll.GetById(id);
        }

        public List<Solicitud> GetAll()
        {
            return bll.GetAll();
        }

        public void Delete(Solicitud solicitud)
        {
            bll.Delete(solicitud);
        }

        public void Dispose()
        {
            bll.Dispose();
        }

        public void Edit(Solicitud solicitud)
        {
            bll.Edit(solicitud);
        }

        public void Create(Solicitud solicitud)
        {
            bll.Create(solicitud);
        }

        public List<string> GetEntidadesEmisoras() {

            return bll.GetEntidadesEmisoras();
        }

        public List<string> GetTerminales()
        {
            return bll.GetTerminales();
        }

        public List<string> GetAllStatus()
        {
            return bll.GetAllStatus();
        }
    }
}
