using SqliteDB.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using SqliteDB.HelperClass;
using System.Data;
using System.Data.SqlClient;

namespace SqliteDB.DAL
{
    public class PersonaDAL
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString;

        private static PersonaDAL _instancia = null;

        private dbConnectionSqlite conn;
        private DataTable DtResult;
        private SQLiteParameter[] SqliteParameters;
        private SQLiteDataAdapter mySQLiteAdapter;

        public PersonaDAL()
        {
            conn = new dbConnectionSqlite();
            DtResult = new DataTable();
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

        public bool InsertUser(BO.PersonaBO persona)
        {
            //bool respuesta = true;

            //using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            //{
            //    conexion.Open();
            //    string query = "insert into Persona(Nombre,Apellido,Telefono) values (@nombre,@apellido,@telefono)";

            //    SQLiteCommand cmd = new SQLiteCommand(query, conexion);
            //    cmd.Parameters.Add(new SQLiteParameter("@nombre", persona.Nombre));
            //    cmd.Parameters.Add(new SQLiteParameter("@apellido", persona.Apellido));
            //    cmd.Parameters.Add(new SQLiteParameter("@telefono", persona.Telefono));
            //    cmd.CommandType = System.Data.CommandType.Text;

            //    if (cmd.ExecuteNonQuery() < 1)
            //    {
            //        respuesta = false; 
            //    }
            //}

            //return respuesta;

            conn = new dbConnectionSqlite();
            string query = "insert into Persona(Nombre,Apellido,Telefono) values (@nombre,@apellido,@telefono)";

            SQLiteParameter[] sqlParameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@nombre", persona.Nombre),
                new SQLiteParameter("@apellido", persona.Apellido),
                new SQLiteParameter("@telefono", persona.Telefono)
            };

            return conn.executeSQLiteSelectQuery(query, sqlParameters) == true ? true : false;


        }

        public bool UpdateUser(BO.PersonaBO persona)
        {
            //bool respuesta = true;

            //using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            //{
            //    conexion.Open();
            //    string query = "update Persona set Nombre=@nombre ,Apellido=@apellido ,Telefono=@telefono where id=@idPersona";

            //    SQLiteCommand cmd = new SQLiteCommand(query, conexion);
            //    cmd.Parameters.Add(new SQLiteParameter("@idPersona", obj.IdPersona));
            //    cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.Nombre));
            //    cmd.Parameters.Add(new SQLiteParameter("@apellido", obj.Apellido));
            //    cmd.Parameters.Add(new SQLiteParameter("@telefono", obj.Telefono));
            //    cmd.CommandType = System.Data.CommandType.Text;

            //    if (cmd.ExecuteNonQuery() < 1)
            //    {
            //        respuesta = false;
            //    }
            //}

            conn = new dbConnectionSqlite();
            string query = "update Persona set Nombre=@nombre ,Apellido=@apellido ,Telefono=@telefono where id=@idPersona";

            SQLiteParameter[] sqlParameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@idPersona", persona.IdPersona),
                new SQLiteParameter("@nombre", persona.Nombre),
                new SQLiteParameter("@apellido", persona.Apellido),
                new SQLiteParameter("@telefono", persona.Telefono)
            };

            return conn.executeSQLiteSelectQuery(query, sqlParameters) == true ? true : false;
        }

        public bool DeleteUser(BO.PersonaBO persona)
        {
            //bool respuesta = true;

            //using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            //{
            //    conexion.Open();
            //    string query = "delete from Persona where id=@idPersona";

            //    SQLiteCommand cmd = new SQLiteCommand(query, conexion);
            //    cmd.Parameters.Add(new SQLiteParameter("@idPersona", obj.IdPersona));
            //    cmd.CommandType = System.Data.CommandType.Text;

            //    if (cmd.ExecuteNonQuery() < 1)
            //    {
            //        respuesta = false;
            //    }
            //}

            //return respuesta;

            conn = new dbConnectionSqlite();
            string query = "delete from Persona where id=@idPersona";

            SQLiteParameter[] sqlParameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@idPersona", persona.IdPersona)
            };

            return conn.executeSQLiteSelectQuery(query, sqlParameters) == true ? true : false;
        }

        public DataTable ShowAllUsers()
        {
            //List<BO.PersonaBO> oLista = new List<BO.PersonaBO>();
            //SQLiteCommand mySQLiteCommand = new SQLiteCommand();
            //DataTable dataTable = new DataTable();
            //DataSet ds = new DataSet();

            //using (SQLiteConnection conexion = new SQLiteConnection(cadena))
            //{
            //    conexion.Open();
            //    string query = "select Id,Nombre,Apellido,Telefono from Persona";
            //    SQLiteCommand cmd = new SQLiteCommand(query, conexion);
            //    cmd.CommandType = System.Data.CommandType.Text;

            //    using (SQLiteDataReader dr = cmd.ExecuteReader())
            //    {
            //        DataTable dt = new DataTable();
            //        dt.Load(dr); 


            //        while (dr.Read())
            //        {
            //            oLista.Add(new BO.PersonaBO()
            //            {
            //                IdPersona = int.Parse(dr["Id"].ToString()),
            //                Nombre = dr["Nombre"].ToString(),
            //                Apellido = dr["Apellido"].ToString(),
            //                Telefono = dr["Telefono"].ToString()
            //            });
            //        }
            //    }

            //}

            //return oLista;

            conn = new dbConnectionSqlite();
            SQLiteParameter[] sqlParameters = new SQLiteParameter[0];
            DataTable dataTable = new DataTable();

            string query = "select Id,Nombre,Apellido,Telefono from Persona";            

            return dataTable = conn.executeSPDT(query, sqlParameters);


        }
    }
}

