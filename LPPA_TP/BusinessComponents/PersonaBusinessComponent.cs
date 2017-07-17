using DataComponents;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BusinessComponents
{
    public class PersonaBusinessComponent : BaseBusinessComponent
    {
        private PersonaDataComponent dal;
        public PersonaBusinessComponent()
        {
            dal = new PersonaDataComponent();
        }

        public void Create(Persona Persona)
        {
            dal.Create(Persona);
        }

        public Persona GetById(int? id)
        {
            return dal.GetById(id);
        }

        public List<Persona> GetAll()
        {
           return dal.GetAll();
        }

        public void Edit(Persona Persona)
        {
            dal.Edit(Persona);
        }

        public void Delete(Persona Persona)
        {
            dal.Delete(Persona);
        }
    }
}
