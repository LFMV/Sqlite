using SqliteDB.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace SqliteDB.DAL
{
    public class PersonaDAL
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        private static PersonaDAL _instancia = null;

        public PersonaDAL()
        {

        }

        public static PersonaDAL Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new PersonaDAL();
                }
                return _instancia;
            }
        }

        public bool Guardar(BO.PersonaBO persona)
        {
            bool respuesta = true;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "insert into Persona(Nombre,Apellido,Telefono) values (@nombre,@apellido,@telefono)";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@nombre", persona.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@apellido", persona.Apellido));
                cmd.Parameters.Add(new SQLiteParameter("@telefono", persona.Telefono));
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false; 
                }
            }

            return respuesta;
        }

        public List<BO.PersonaBO> Listar()
        {
            List<BO.PersonaBO> oLista = new List<BO.PersonaBO>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "select Id,Nombre,Apellido,Telefono from Persona";
                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.CommandType = System.Data.CommandType.Text;

                using(SQLiteDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new BO.PersonaBO()
                        {
                            IdPersona = int.Parse(dr["Id"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Telefono = dr["Telefono"].ToString()
                        });
                    }
                }

            }

            return oLista;
        }

        public bool Editar(BO.PersonaBO obj)
        {
            bool respuesta = true;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "update Persona set Nombre=@nombre ,Apellido=@apellido ,Telefono=@telefono where id=@idPersona";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@idPersona", obj.IdPersona));
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
                cmd.Parameters.Add(new SQLiteParameter("@apellido", obj.Apellido));
                cmd.Parameters.Add(new SQLiteParameter("@telefono", obj.Telefono));
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool Eliminar(BO.PersonaBO obj)
        {
            bool respuesta = true;

            using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            {
                conexion.Open();
                string query = "delete from Persona where id=@idPersona";

                SQLiteCommand cmd = new SQLiteCommand(query, conexion);
                cmd.Parameters.Add(new SQLiteParameter("@idPersona", obj.IdPersona));
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }
    }
}
