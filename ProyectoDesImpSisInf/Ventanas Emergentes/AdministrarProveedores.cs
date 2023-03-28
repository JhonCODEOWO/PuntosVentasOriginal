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
    public partial class AdministrarProveedores : Form
    {
        public AdministrarProveedores()
        {
            InitializeComponent();
        }

        bool Editar = false;
        private void ConfigurarListView()
        {
            var Lista = lvProv;

            lvProv.Items.Clear();
            Lista.Columns.Clear();
            Lista.View = View.Details;
            Lista.GridLines = false;
            Lista.FullRowSelect = true;
            Lista.Scrollable = true;
            Lista.HideSelection = false;
            //Configuramos las columnas
            Lista.Columns.Add("ID", 40, HorizontalAlignment.Left);//0
            Lista.Columns.Add("Nombre del proveedor", 200, HorizontalAlignment.Left);//1
            Lista.Columns.Add("Número Telefónico", 230, HorizontalAlignment.Left);//2
        }

        private void LlenarListView(DataTable tablaObtenida)
        {
            lvProv.Items.Clear();
            for (int i = 0; i < tablaObtenida.Rows.Count; i++)
            {
                DataRow dr = tablaObtenida.Rows[i];
                ListViewItem list = new ListViewItem(dr["IdProveedor"].ToString());
                list.SubItems.Add(dr["NombreProveedor"].ToString());
                list.SubItems.Add(dr["Telefono"].ToString());
                lvProv.Items.Add(list);
            }
        }

        private void CargarDatos()
        {
            RN_Proveedor p = new RN_Proveedor();
            DataTable dato = new DataTable();

            dato = p.MostrarProveedores();//el datatable obtiene todo lo que el método MostrarMarca retorne
            if (dato.Rows.Count > 0)
            {
                LlenarListView(dato); //Usa el método llenar listview para llenar el datatable
            }
            else
            {
                lvProv.Items.Clear(); //Borra el listview
            }
        }
        private void AdministrarProveedores_Load(object sender, EventArgs e)
        {
            ConfigurarListView();
            CargarDatos();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            panel_Datos.Visible = true;
            Editar = false;
            txt_IdProv.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RN_Proveedor prov = new RN_Proveedor();
            if (txt_NombreProv.Text.Trim().Length < 0 || txt_IdProv.Text.Length == 0 || txtNumTel.Text.Length == 0) //Si el nombre en su longtud es menor a 0
            {
                MessageBox.Show("Asegúrate de llenar todos los campos",
                    "Verifica tus datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation); //Mostramos una advertencia
                return;
            }
            if (Editar == false) //Si editar es falso..
            {
                //Nuevo
                prov.RN_AgregarProveedor(Convert.ToInt32(txt_IdProv.Text), txt_NombreProv.Text, Convert.ToInt64(txtNumTel.Text));
                panel_Datos.Visible = false;
                CargarDatos();
                txt_NombreProv.Text = "";
            }
            else
            {
                //Editar
                prov.RN_EditarProveedor(Convert.ToInt32(txt_IdProv.Text), txt_NombreProv.Text, Convert.ToInt64(txtNumTel.Text));
                panel_Datos.Visible = false;
                CargarDatos();
                txt_NombreProv.Text = "";
                Editar = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            RN_Proveedor proveedor = new RN_Proveedor();
            DialogResult result;
            if (lvProv.SelectedItems.Count > 0)
            {
                int dato = Convert.ToInt32(lvProv.SelectedItems[0].Text);
                //string nProv = lvProv.SelectedItems[1].Text;
                Console.WriteLine(lvProv.TabIndex);
                result = MessageBox.Show("¿Estas seguro de querer eliminar el proveedor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Console.WriteLine("En if");
                    proveedor.RN_EliminarProveedor(dato);
                    CargarDatos();
                }
            }
            else
            {
                MessageBox.Show("Para eliminar selecciona un elemento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lvProv.SelectedItems.Count > 0)
            {
                var lsv = lvProv.SelectedItems[0];
                txt_IdProv.Text = lsv.SubItems[0].Text;
                txt_NombreProv.Text = lsv.SubItems[1].Text;
                txtNumTel.Text = lsv.SubItems[2].Text;

                panel_Datos.Visible = true;
                txt_IdProv.Focus();
                Editar = true;
            }
            else
            {
                MessageBox.Show("Error, debe de seleccionar algun elemento de la tabla", "Verificar selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReiniciarCampos();
            panel_Datos.Visible = false;
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RN_Proveedor rp = new RN_Proveedor();
            rp.RN_EliminarProveedor(Convert.ToInt16(txt_IdProv.Text));
            panel_Datos.Visible = false;
            txt_IdProv.Text = "";
            CargarDatos();
        }

        private void ReiniciarCampos()
        {
            txt_IdProv.Text = "";
            txtNumTel.Text = "";
            txt_NombreProv.Text = "";
        }
    }
}
