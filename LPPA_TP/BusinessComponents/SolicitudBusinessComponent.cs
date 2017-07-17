using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataComponents;
using Entities;

namespace BusinessComponents
{
    public class SolicitudBusinessComponent : BaseBusinessComponent
    {
        private SolicitudDataComponent dal = new SolicitudDataComponent();
        private PersonaBusinessComponent bll_persona = new PersonaBusinessComponent();
        private static string SOLICITUD_RECHAZADA = "RECHAZADA";
        private static string SOLICITUD_APROBADA = "APROBADA";
        private static decimal? PUNTAJE_MINIMO = 15000;
        public SolicitudBusinessComponent() { }

        public void Create(Solicitud solicitud)
        {

            this.ValidarElibigilidad(solicitud);

            dal.Create(solicitud);
        }

        public Solicitud GetById(int? id)
        {
            return dal.GetById(id);
        }

        public List<Solicitud> GetAll()
        {
            return dal.GetAll();
        }

        public List<string> GetEntidadesEmisoras()
        {
            return dal.GetEntidadesEmisoras();
        }

        public List<string> GetTerminales()
        {
            return dal.GetTerminales();
        }

        public List<string> GetAllStatus()
        {
            return dal.GetAllStatus();
        }

        public void Edit(Solicitud solicitud)
        {
            dal.Edit(solicitud);
        }

        public void Delete(Solicitud solicitud)
        {
            dal.Delete(solicitud);
        }

        private void ValidarElibigilidad(Solicitud solicitud) {
            var titular = solicitud.Persona;
            var conyugue = solicitud.Persona.Persona2;
            decimal? puntaje = 0;
            puntaje += titular.ingreso_promedio;
            if (titular.documentacion_adjunta != null) {
                puntaje += 2000;
            }
            if (conyugue != null)
            {
                puntaje += conyugue.ingreso_promedio;
                puntaje += 1000;
                if (conyugue.documentacion_adjunta != null) {
                    puntaje += 1000;
                }
            }
            var today = DateTime.Today;
            var age = today.Year - titular.fecha_nacimiento.Year;
            if (age >= 30)
            {
                puntaje += 1000;
            }

            if (puntaje >= PUNTAJE_MINIMO)
            {
                solicitud.estado_tramite = SOLICITUD_APROBADA;
            }
            else {
                solicitud.estado_tramite = SOLICITUD_RECHAZADA;
            }
        }
    }
}
