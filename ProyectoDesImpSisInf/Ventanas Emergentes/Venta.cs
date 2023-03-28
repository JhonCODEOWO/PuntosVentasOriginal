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
using P_CapaDatos;

namespace ProyectoDesImpSisInf.Ventanas_Emergentes
{
    public partial class Venta : Form
    {
        public Venta()
        {
            InitializeComponent();
            
        }
        RN_Vistas v = new RN_Vistas();
        DataTable dataTableVentas;
        bool Editar = false;
        /*private void ConfigurarListView()
        {
            var Lista = lvVentas;

            lvVentas.Items.Clear();
            Lista.Columns.Clear();
            Lista.View = View.Details;
            Lista.GridLines = false;
            Lista.FullRowSelect = true;
            Lista.Scrollable = true;
            Lista.HideSelection = false;
            //Configuramos las columnas
            Lista.Columns.Add("ID", 30, HorizontalAlignment.Left);//0
            Lista.Columns.Add("Nombre del producto", 200, HorizontalAlignment.Left);//1
            Lista.Columns.Add("Cantidad de Articulos", 230, HorizontalAlignment.Left);//2
            Lista.Columns.Add("Fecha", 230, HorizontalAlignment.Left);//3
        }

        private void LlenarListView(DataTable tablaObtenida)
        {
            lvVentas.Items.Clear();
            for (int i = 0; i < tablaObtenida.Rows.Count; i++)
            {
                DataRow dr = tablaObtenida.Rows[i];
                ListViewItem list = new ListViewItem(dr["IdVenta"].ToString());
                list.SubItems.Add(dr["NombreProducto"].ToString());
                list.SubItems.Add(dr["CantidadDV"].ToString());
                list.SubItems.Add(dr["Fecha"].ToString());
                lvVentas.Items.Add(list);
            }
        }

        private void CargarDatos()
        {
            RN_Vistas v = new RN_Vistas();
            DataTable dato = new DataTable();

            dato = v.VistaProdDeVe();//el datatable obtiene todo lo que el método MostrarMarca retorne
            if (dato.Rows.Count > 0)
            {
                LlenarListView(dato); //Usa el método llenar listview para llenar el datatable
            }
            else
            {
                lvVentas.Items.Clear(); //Borra el listview
            }
        }*/

        private void Venta_Load(object sender, EventArgs e)
        {
            //dataTableVentas = v.VistaProdDeVe();
            dgvVentas.DataSource = v.VistaProdDeVe();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrarFecha_Click(object sender, EventArgs e)
        {
            DataTable filtradaconfecha;
            RN_Ventas ventas = new RN_Ventas();
            //Console.WriteLine(dtpFecha.Value.Year + "-" + dtpFecha.Value.Month + "-" + dtpFecha.Value.Day);
            filtradaconfecha = ventas.FiltrarPorFechaRecibida(dtpFecha.Value.Year + "-" + dtpFecha.Value.Month + "-" + dtpFecha.Value.Day);
            dgvVentas.DataSource = null;
            dgvVentas.DataSource = filtradaconfecha;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvVentas.DataSource = null;
            dgvVentas.DataSource = dataTableVentas;
        }
    }
}
