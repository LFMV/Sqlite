using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SqliteDB.BLL;
using SqliteDB.BO;
using SqliteDB.DAL;

namespace SqliteDB
{
    public partial class Form1 : Form
    {
        private BLL.PersonaBLL _personaBLL;

        public Form1()
        {
            InitializeComponent();
            _personaBLL = new PersonaBLL();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            mostrar_personas();
        }        

        public void limpiar()
        {
            txtidpersona.Text = "";
            txtnombre.Text = "";
            txtapellido.Text = "";
            txttelefono.Text = "";
            txtnombre.Focus();
        }

        public void mostrar_personas()
        {
            dgvpersonas.DataSource = null;
            dgvpersonas.DataSource = PersonaDAL.Instancia.Listar();
        }        

        private void btneditar_Click(object sender, EventArgs e)
        {
            BO.PersonaBO person = new BO.PersonaBO()
            {
                IdPersona = int.Parse(txtidpersona.Text),
                Nombre = txtnombre.Text,
                Apellido = txtapellido.Text,
                Telefono = txttelefono.Text
            };

            bool ans = PersonaDAL.Instancia.Editar(person);

            if (ans)
            {
                limpiar();
                mostrar_personas();
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            {
                BO.PersonaBO person = new BO.PersonaBO()
                {
                    IdPersona = int.Parse(txtidpersona.Text)
                };

                bool respuesta = PersonaDAL.Instancia.Eliminar(person);

                if (respuesta)
                {
                    limpiar();
                    mostrar_personas();
                }
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {

            BO.PersonaBO person = new BO.PersonaBO()
            {
                Nombre = txtnombre.Text,
                Apellido = txtapellido.Text,
                Telefono = txttelefono.Text
            };

            bool ans = _personaBLL.Guardar(person);

            if (ans)
            {
                limpiar();
                mostrar_personas();
            }
        }
    }
}
