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
    public partial class Pedidos : Form
    {
        RN_Pedidos p = new RN_Pedidos();
        RN_Proveedor proveedor = new RN_Proveedor();
        RN_Producto producto = new RN_Producto();
        
        public Pedidos()
        {
            InitializeComponent();
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {
            DataTable pedidiInitial = p.Pedido();
            dgvPedidos.DataSource = pedidiInitial;
            cmbProveedor.DataSource = proveedor.ListarProv();
            cmbProveedor.ValueMember = "NombreProveedor";

            cmbEntregar.DataSource = producto.ListarProd();
            cmbEntregar.ValueMember = "NombreProducto";

            dateEntrega.Value.Day.ToString();

            ValidarPedido(dgvPedidos);
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddPedido_Click(object sender, EventArgs e)
        {
            try
            {
                RN_Pedidos pedidos = new RN_Pedidos();

                //Se almacenan los datos necesarios para la agregacion en las variables....
                int idPedido = Convert.ToInt16(txtId.Text);
                int fkProveedor;
                int fkproducto;
                string nombreprov = cmbProveedor.Text;
                string nombreProd = cmbEntregar.Text;
                int cantidad = Convert.ToInt32(nudCantidad.Value);
                double totalpagar = Convert.ToDouble(txtTAPagar.Text);

                //Se le da formato a la cadena de texto a recibir mediante el datetimepicker
                string fechaFormat = dateEntrega.Value.Year.ToString() + "-" + dateEntrega.Value.Month.ToString() + "-" + dateEntrega.Value.Day.ToString();

                //Se obtienen los id de las tablas correspondientes y se almacenan en las variables para poder usarse despues
                fkProveedor = pedidos.IdRecibido(nombreprov);
                fkproducto = pedidos.IdentificarProducto(nombreProd);

                //Se agrega el nuevo registro mediante el procedimiento almacenado
                pedidos.AgregarPedido(idPedido, fkProveedor, fkproducto, fechaFormat, cantidad, totalpagar);
                DataTable pedido = p.Pedido();
                dgvPedidos.DataSource = null;
                dgvPedidos.DataSource = pedido;
                ValidarPedido(dgvPedidos);

                //Impresiones de consola para corroborar funcionamiento
                Console.WriteLine(fkProveedor + " " + fkproducto + " " + cantidad);
                //Console.WriteLine("IdPedido: " + idPedido + " cmbProveedor: " + nombreprov + " Nombre producto: " + nombreProd + " Fecha: " + fechaFormat);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ ex);
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RN_Pedidos pedidos = new RN_Pedidos();
            int id = Convert.ToInt32(dgvPedidos.Rows[dgvPedidos.CurrentRow.Index].Cells[0].Value);
            string nProducto = dgvPedidos.Rows[dgvPedidos.CurrentRow.Index].Cells[1].Value.ToString();
            DialogResult respuesta;
            respuesta = MessageBox.Show("¿Estas seguro de eliminar el pedido que entregara " + nProducto+"?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                pedidos.EliminarPedido(id);
                dgvPedidos.DataSource = null;
                dgvPedidos.DataSource = p.Pedido();
                ValidarPedido(dgvPedidos);
                Console.WriteLine(id);
            }
        }

        public void ValidarPedido(DataGridView table)
        {
            foreach (DataGridViewRow view in table.Rows)
            {
                if (Convert.ToDateTime(view.Cells["Fecha de entrega"].Value) < DateTime.Now)
                {
                    view.DefaultCellStyle.BackColor = Color.Red;
                    view.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    view.DefaultCellStyle.BackColor = Color.Green;
                    view.DefaultCellStyle.ForeColor= Color.White;
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                RN_Pedidos pedidos = new RN_Pedidos();
                int idPedido = Convert.ToInt16(txtId.Text);
                int fkProveedor;
                int fkproducto;
                string nombreprov = cmbProveedor.Text;
                string nombreProd = cmbEntregar.Text;
                int cantidad = Convert.ToInt32(nudCantidad.Value);
                double totalpagar = Convert.ToDouble(txtTAPagar.Text);
                string fechaFormat = dateEntrega.Value.Year.ToString() + "-" + dateEntrega.Value.Month.ToString() + "-" + dateEntrega.Value.Day.ToString();
                fkProveedor = pedidos.IdRecibido(nombreprov);
                fkproducto = pedidos.IdentificarProducto(nombreProd);

                pedidos.ModificarPedido(idPedido, fkProveedor, fkproducto, fechaFormat, cantidad, totalpagar);
                DataTable pedido = p.Pedido();
                dgvPedidos.DataSource = null;
                dgvPedidos.DataSource = pedido;
                ValidarPedido(dgvPedidos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
    }
}
