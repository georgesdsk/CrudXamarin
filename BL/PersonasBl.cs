using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public class PersonasBl
    {
        Listados dal;

        public PersonasBl()
        {
            this.dal = new Listados();
        }

        public async Task<List<clsPersona>> getPersonas()
        {
            return await dal.getPersonasDAL();
        }

        public async Task borrarPersona(int idPersona)
        {
            await dal.borrarPersona(idPersona);
        }
    }
}