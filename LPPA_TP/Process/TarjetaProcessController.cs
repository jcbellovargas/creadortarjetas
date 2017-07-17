using BusinessComponents;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditCardNumberGenerator;

namespace LPPA.Process
{
    public class TarjetaProcessController
    {
        private TarjetaBusinessComponent bll = new TarjetaBusinessComponent();

        public List<Tarjeta> GetAll()
        {
            return bll.GetAll();
        }

        public void Create(Tarjeta tarjeta)
        {
            bll.Create(tarjeta);
        }

        public Tarjeta GetById(int? id)
        {
            return bll.GetById(id);
        }

        public void Delete(Tarjeta tarjeta)
        {
            bll.Delete(tarjeta);
        }

        public void Edit(Tarjeta tarjeta)
        {
            bll.Edit(tarjeta);
        }

        public void Dispose()
        {
            bll.Dispose();
        }

        public void CreateFromSolicitud(Solicitud solicitud) {
            var titular = solicitud.Persona;
            var conyugue = solicitud.Persona.Persona2;

            Tarjeta tarjeta = new Tarjeta();
            tarjeta.limite_credito = solicitud.Persona.ingreso_promedio > 0 ? solicitud.Persona.ingreso_promedio : 5000 ;
            tarjeta.nro_tarjeta = RandomCreditCardNumberGenerator.GenerateCreditCardNumber(solicitud.entidad_emisora);
            Random random = new Random();
            tarjeta.cod_seguridad = random.Next(100, 999);
            tarjeta.fecha_emision = DateTime.Today;
            tarjeta.fecha_vencimiento = DateTime.Today.AddYears(5);
            tarjeta.CreatedBy = solicitud.CreatedBy;
            tarjeta.id_solicitud = solicitud.id_solicitud;
            tarjeta.entidad_emisora = solicitud.entidad_emisora;
            tarjeta.nombre_titular = titular.nombre + " " + titular.apellido;

            bll.Create(tarjeta);

            if (conyugue != null)
            {
                Tarjeta tarjeta2 = new Tarjeta();
                tarjeta2.limite_credito = solicitud.Persona.ingreso_promedio > 0 ? solicitud.Persona.ingreso_promedio : 5000;
                tarjeta2.nro_tarjeta = RandomCreditCardNumberGenerator.GenerateCreditCardNumber(solicitud.entidad_emisora);
                tarjeta2.cod_seguridad = random.Next(100, 999);
                tarjeta2.fecha_emision = DateTime.Today;
                tarjeta2.fecha_vencimiento = DateTime.Today.AddYears(5);
                tarjeta2.CreatedBy = solicitud.CreatedBy;
                tarjeta2.id_solicitud = solicitud.id_solicitud;
                tarjeta2.entidad_emisora = solicitud.entidad_emisora;
                tarjeta2.extension_de = tarjeta.nro_tarjeta;
                tarjeta2.nombre_titular = conyugue.nombre + " " + conyugue.apellido;
                bll.Create(tarjeta2);
            }
        }
    }
}
