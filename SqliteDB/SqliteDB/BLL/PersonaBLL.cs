using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteDB.BLL
{
    public class PersonaBLL
    {
        private DAL.PersonaDAL _personaDAL;
        public PersonaBLL()
        {
            _personaDAL = new DAL.PersonaDAL();
        }

        public bool Guardar(BO.PersonaBO persona)
        {
            return _personaDAL.Guardar(persona);
        }
    }
}
