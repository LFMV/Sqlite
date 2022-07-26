using System;
using System.Collections.Generic;
using System.Data;
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

        public bool InsertUser(BO.PersonaBO persona)
        {
            return _personaDAL.InsertUser(persona);
        }

        public bool UpdateUser(BO.PersonaBO person)
        {
            return _personaDAL.UpdateUser(person);
        }

        public bool DeleteUser(BO.PersonaBO person)
        {
            return _personaDAL.DeleteUser(person);
        }

        public DataTable ShowAllUsers()
        {
            return _personaDAL.ShowAllUsers();
        }
    }
}
