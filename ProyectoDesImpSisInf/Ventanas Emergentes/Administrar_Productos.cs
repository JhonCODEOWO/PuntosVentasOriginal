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
using Prod_CapaEntidad;

namespace ProyectoDesImpSisInf.Ventanas_Emergentes
{
    public partial class Administrar_Productos : Form
    {
        public Administrar_Productos()
        {
            InitializeComponent();
        }
        bool Editar = false;
        bool eliminar = false;
        private void ConfigurarListView()
        {
            var Lista = lvProductos;

            lvProductos.Items.Clear();
            Lista.Columns.Clear();
            Lista.View = View.Details;
            Lista.GridLines = false;
            Lista.FullRowSelect = true;
            Lista.Scrollable = true;
            Lista.HideSelection = false;
            //Configuramos las columnas
            Lista.Columns.Add("ID", 39, HorizontalAlignment.Left);//0
            Lista.Columns.Add("Nombre del producto", 133, HorizontalAlignment.Left);//1
            Lista.Columns.Add("Precio unitario", 133, HorizontalAlignment.Left);//2
            Lista.Columns.Add("En stock", 133, HorizontalAlignment.Left);//3
        }

        private void LlenarListView(DataTable tablaObtenida)
        {
            lvProductos.Items.Clear();
            for (int i = 0; i < tablaObtenida.Rows.Count; i++)
            {
                DataRow dr = tablaObtenida.Rows[i];
                ListViewItem list = new ListViewItem(dr["IdProducto"].ToString());
                list.SubItems.Add(dr["NombreProducto"].ToString());
                list.SubItems.Add(dr["PrecioProducto"].ToString());
                list.SubItems.Add(dr["CantidadProducto"].ToString());
                lvProductos.Items.Add(list);
            }
        }

        private void CargarDatos()
        {
            try
            {
                RN_Producto p = new RN_Producto();
                DataTable dato = new DataTable();

                dato = p.MostrarProductos();//el datatable obtiene todo lo que el método MostrarMarca retorne
                if (dato.Rows.Count > 0)
                {
                    LlenarListView(dato); //Usa el método llenar listview para llenar el datatable
                }
                else
                {
                    lvProductos.Items.Clear(); //Borra el listview
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error a cargar la tabla: " + ex.StackTrace);
            }
            
        }
        private void Administrar_Productos_Load(object sender, EventArgs e)
        {
            
            ConfigurarListView();
            CargarDatos();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RN_Producto obj = new RN_Producto(); //Creamos un objeto de la clase
            if (txt_NombreP.Text.Trim().Length < 0) //Si el nombre en su longtud es menor a 0
            {
                MessageBox.Show("Ingresa el nombre de la categoria",
                    "Registrar Categoria", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation); //Mostramos una advertencia
                return;
            }
            if (Editar == false) //Si editar es falso..
            {
                //Nuevo
                obj.RN_RegistrarProducto(Convert.ToInt32(txt_IdP.Text), txt_NombreP.Text, Convert.ToDouble(txtPrecioVP.Text), Convert.ToInt32(nudCantP.Value));
                panel_Datos.Visible = false;
                CargarDatos();
                txt_NombreP.Text = "";
            }
            else
            {
                //Editar
                obj.RN_EditarProducto(Convert.ToInt32(txt_IdP.Text), txt_NombreP.Text, Convert.ToDouble(txtPrecioVP.Text), Convert.ToInt32(nudCantP.Value));
                panel_Datos.Visible = false;
                CargarDatos();
                txt_NombreP.Text = "";
                Editar = false;
            }
            ReiniciarCampos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RN_Producto producto = new RN_Producto();
            DialogResult respuesta;
            int id = Convert.ToInt32(lvProductos.SelectedItems[0].Text);
            respuesta = MessageBox.Show("¿Estás seguro de elimianr este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                producto.EliminarProducto(id);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Activar_EntradasPanel();
            if (lvProductos.SelectedItems.Count > 0)
            {
                var lsv = lvProductos.SelectedItems[0];
                txt_IdP.Text = lsv.SubItems[0].Text;
                txt_NombreP.Text = lsv.SubItems[1].Text;
                txtPrecioVP.Text = lsv.SubItems[2].Text;
                nudCantP.Value = Convert.ToInt32(lsv.SubItems[3].Text);
            }
            panel_Datos.Visible = true;
            txt_IdP.Focus();
            Editar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Activar_EntradasPanel();
            panel_Datos.Visible = true; //Muestra el panel oculto
            txt_IdP.Focus(); //Coloca el cursor en el txtNombre
            Editar = false; //Enviamos un editar como falso para que no se actualicen los registros
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RN_Producto obj = new RN_Producto();
            obj.EliminarProducto(Convert.ToInt32(txt_IdP.Text));
            panel_Datos.Visible = false;
            CargarDatos();
        }

        private void btnCerrarPanel_Click(object sender, EventArgs e)
        {
            if (eliminar == true)
            {
                Activar_EntradasPanel();
            }
            else
            {
                Desactivar_EntradasPanel();
            }
            ReiniciarCampos();
            panel_Datos.Visible = false;
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReiniciarCampos()
        {
            txt_IdP.Text = "";
            txt_NombreP.Text = "";
            txtPrecioVP.Text = "";
            nudCantP.Value = 1;
        }

        private void Desactivar_EntradasPanel()
        {
            txt_NombreP.Enabled = false;
            txtPrecioVP.Enabled = false;
            nudCantP.Enabled = false;
        }

        private void Activar_EntradasPanel()
        {
            txt_NombreP.Enabled = true;
            txtPrecioVP.Enabled = true;
            nudCantP.Enabled = true;
        }
    }
}
