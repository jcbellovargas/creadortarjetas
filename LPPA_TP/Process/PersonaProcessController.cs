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
    public class PersonaProcessController
    {
        private PersonaBusinessComponent bll = new PersonaBusinessComponent();
        public Persona GetById(int? id)
        {
            return bll.GetById(id);
        }

        public List<Persona> GetAll()
        {
            return bll.GetAll();
        }

        public void Delete(Persona persona)
        {
            bll.Delete(persona);
        }

        public void Dispose()
        {
            bll.Dispose();
        }

        public void Edit(Persona persona)
        {
            bll.Edit(persona);
        }

        public void Create(Persona persona)
        {
            bll.Create(persona);
        }
    }
}
