using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prod_CapaNegocio;

namespace ProyectoDesImpSisInf.Ventanas_Emergentes
{
    public partial class AdministrarUsuarios : Form
    {
        byte typeUser = 0;
        bool editar = false;
        public AdministrarUsuarios()
        {
            InitializeComponent();
        }

        private void ConfigurarListView()
        {
            var Lista = lvUsu;

            lvUsu.Items.Clear();
            Lista.Columns.Clear();
            Lista.View = View.Details;
            Lista.GridLines = false;
            Lista.FullRowSelect = true;
            Lista.Scrollable = true;
            Lista.HideSelection = false;
            //Configuramos las columnas
            Lista.Columns.Add("ID", 40, HorizontalAlignment.Left);//0
            Lista.Columns.Add("Nombre del usuario", 150, HorizontalAlignment.Left);//1
            Lista.Columns.Add("¿Es administrador?", 150, HorizontalAlignment.Left);//2
            Lista.Columns.Add("Password", 100, HorizontalAlignment.Left);//2
        }

        private void LLenarLista(DataTable tablaObtenida)
        {
            lvUsu.Items.Clear();
            for (int i = 0; i < tablaObtenida.Rows.Count; i++)
            {
                DataRow dr = tablaObtenida.Rows[i];
                ListViewItem list = new ListViewItem(dr["IdUsuario"].ToString());
                list.SubItems.Add(dr["NombreUsuario"].ToString());
                list.SubItems.Add(dr["Administrador"].ToString());
                list.SubItems.Add(dr["Contraseña"].ToString());
                lvUsu.Items.Add(list);
            }
        }

        private void CargarDatos()
        {
            RN_Usuario u = new RN_Usuario();
            DataTable dato = new DataTable();

            dato = u.MostrarUsuarios();
            if (dato.Rows.Count > 0)
            {
                LLenarLista(dato);
            }
            else
            {
                lvUsu.Items.Clear();
            }
        }

        private void AdministrarUsuarios_Load(object sender, EventArgs e)
        {
            ConfigurarListView();
            CargarDatos();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            editar = false;
            txtIdUsu.Focus();
            DatosUsu.Visible= true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            editar = true;
            if (lvUsu.SelectedItems.Count > 0)
            {
                var lsv = lvUsu.SelectedItems[0];
                txtIdUsu.Text = lsv.SubItems[0].Text;
                txtNombreUsu.Text = lsv.SubItems[1].Text;
                chbAdmin.Checked = Convert.ToBoolean(lsv.SubItems[2].Text);
                txtContraseña.Text = lsv.SubItems[3].Text;
            }
            DatosUsu.Visible= true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            RN_Usuario usuario = new RN_Usuario();
            DialogResult respuesta;
            int id = Convert.ToInt32(lvUsu.SelectedItems[0].Text);
            if (lvUsu.SelectedItems.Count > 0)
            {
                respuesta = MessageBox.Show("¿Estas seguro de eliminar el usuario?\nADVERTENCIA: NO PODRÁ ACCEDER MAS A LA APLICACIÓN", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    usuario.RN_EliminarUsuario(id);
                }
            }
            else
            {
                MessageBox.Show("Porfavor selecciona alguno de los elementos", "Error en la operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAplicarCambios_Click(object sender, EventArgs e)
        {
            RN_Usuario u = new RN_Usuario();
            if (txtIdUsu.Text.Length == 0 || txtNombreUsu.Text.Length == 0 || txtContraseña.Text.Length == 0)
            {
                MessageBox.Show("Por favor rellene todos los campos", "Error de operacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (editar == true)
            {
                if (txtContraseña.Text == txtConfirmarPass.Text)
                {
                    u.ModificarUsuario(Convert.ToInt32(txtIdUsu.Text), txtNombreUsu.Text, Convert.ToByte(chbAdmin.Checked), Convert.ToInt32(txtContraseña.Text));
                    CargarDatos();
                    DatosUsu.Visible = false;
                    editar = false;
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show("Verifica que las contraseñas coincidan", "Las contraseñas no coinciden");
                }
            }
            else
            {
                if (txtContraseña.Text == txtConfirmarPass.Text)
                {
                    u.RN_AgregarUsuario(Convert.ToInt32(txtIdUsu.Text), txtNombreUsu.Text, Convert.ToByte(chbAdmin.Checked), Convert.ToInt32(txtContraseña.Text));
                    CargarDatos();
                    DatosUsu.Visible = false;
                }
                else
                {
                    MessageBox.Show("Verifica que las contraseñas coincidan", "Las contraseñas no coinciden");
                }
            }
        }

        private void DatosUsu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DatosUsu.Visible = false;
        }

        private void btnEliminarUsu_Click(object sender, EventArgs e)
        {
            RN_Usuario u = new RN_Usuario();
            if (lvUsu.SelectedItems.Count > 0)
            {
                u.RN_EliminarUsuario(Convert.ToInt32(txtIdUsu.Text));
                CargarDatos();
                DatosUsu.Visible = false;
            }
            
        }

        private void pnl_titu_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pnl_titu_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
