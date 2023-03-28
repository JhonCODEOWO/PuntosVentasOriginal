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
    public partial class Detalle_Venta : Form
    {
        public Detalle_Venta()
        {
            InitializeComponent();
        }

        bool Editar = false;
        private void ConfigurarListView()
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
            Lista.Columns.Add("ID DetalleVenta", 40, HorizontalAlignment.Left);//0
            Lista.Columns.Add("ID Venta", 200, HorizontalAlignment.Left);//1
            Lista.Columns.Add("ID Productos", 230, HorizontalAlignment.Left);//2
            Lista.Columns.Add("Cantidad", 250, HorizontalAlignment.Left);//3
            Lista.Columns.Add("Precio", 280, HorizontalAlignment.Left);//4
        }

        private void LlenarListView(DataTable tablaObtenida)
        {
            lvVentas.Items.Clear();
            for (int i = 0; i < tablaObtenida.Rows.Count; i++)
            {
                DataRow dr = tablaObtenida.Rows[i];
                ListViewItem list = new ListViewItem(dr["IdDetalleVenta"].ToString());
                list.SubItems.Add(dr["IdVentasDV"].ToString());
                list.SubItems.Add(dr["IdProductosDV"].ToString());
                list.SubItems.Add(dr["CantidadDV"].ToString());
                list.SubItems.Add(dr["PrecioDV"].ToString());
                lvVentas.Items.Add(list);
            }
        }

        private void CargarDatos()
        {
            RN_DetalleVenta v = new RN_DetalleVenta();
            DataTable dato = new DataTable();

            dato = v.RN_MostrarVentasDV();//el datatable obtiene todo lo que el método MostrarMarca retorne
            if (dato.Rows.Count > 0)
            {
                LlenarListView(dato); //Usa el método llenar listview para llenar el datatable
            }
            else
            {
                lvVentas.Items.Clear(); //Borra el listview
            }
        }

        private void Detalle_Venta_Load(object sender, EventArgs e)
        {
            ConfigurarListView();
            CargarDatos();
        }
    }
}
