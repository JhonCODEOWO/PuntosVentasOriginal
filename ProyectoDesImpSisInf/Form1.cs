using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using ProyectoDesImpSisInf.Ventanas_Emergentes;
using P_CapaDatos;
using Prod_CapaEntidad;
using Prod_CapaNegocio;

namespace ProyectoDesImpSisInf
{
    public partial class Form1 : Form
    {
        RN_DetalleVenta dv = new RN_DetalleVenta();
        RN_Ventas v = new RN_Ventas();
        BDConexion cnString = new BDConexion();
        private DataTable dtBusqueda;
        private SqlDataAdapter daBusqueda;
        List<VentaProductos> listavp = new List<VentaProductos>(); //Lista que guarda de manera temporal los productos agregados a la tabla
        bool activo = true;
        int m, mx, my;
        double totalventa = 0;
        int productosTotales = 0;

        //797119806
        public Form1(string nombre, string rol)
        {
            InitializeComponent();
            txtAdmOrU.Text = nombre; //Obtenemos los datos de la invocación del formulario padre
            txtName.Text = rol;

            if (rol == "Administrador") //Si el texto es administrador......
            {
                //Habilitamos los botones
                btnProveedores.Enabled = true;
                btnProductos.Enabled = true;
            }
            else
            {
                //Se deshabilitan
                btnProveedores.Enabled = false;
                btnProductos.Enabled = false;
                btnUsuarios.Enabled = false;
                btnVentas.Enabled = false;
            }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Inicialización de elementos
            pnConfirmar.Visible = false;
            //DateTime.Now.ToShortDateString();
            txtBusqueda.Text = "";
            lblDate.Text = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
            lblnumV.Text = Convert.ToString(v.RN_ContarVentas()); //Aumentamos en 1 el total de filas obtenidas para contar el ticket en curso
            lblProductosTotales.Text = "0";
            //dgvBV.DataSource = listavp;
            btnAñadirVenta.Enabled = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Si el texto es diferente de nulo...
                if (txtBusqueda.Text != null)
                {
                    btnAñadirVenta.Enabled = true;

                    //Se realiza una busqueda en base a lo que contenga la caja de texto....
                    SqlConnection cn = new SqlConnection();
                    cn.ConnectionString = cnString.conectar();
                    SqlCommand cmd = new SqlCommand("BuscarProductos", cn);
                    cmd.Parameters.AddWithValue("@Nombre", txtBusqueda.Text);
                    daBusqueda = new SqlDataAdapter(cmd);
                    daBusqueda.SelectCommand.CommandType = CommandType.StoredProcedure;

                    //En base a lo recibido se llena un datatable que sirve como datasourse al datagridview
                    dtBusqueda = new DataTable();
                    daBusqueda.Fill(dtBusqueda);
                    dgvBusqueda.DataSource = null;
                    dgvBusqueda.DataSource = dtBusqueda;
                    Console.WriteLine("En if");
                }
                else
                {
                    //En caso contrario cargamos la lista de venta de nuevo al objeto datagridview
                    //Desactivamos el notón de añadir
                    btnAñadirVenta.Enabled = false;
                    Console.WriteLine("En else");
                    //btnAñadirVenta.Enabled = false;
                    //btnEliminarElemento.Enabled = false;
                    //dtgvBusqueda.DataSource = listavp;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la operación en el coógigo fuente excepción: "+ex.Message, "Error fatal");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int cantidadStock = Convert.ToInt32(dgvBusqueda.Rows[dgvBusqueda.CurrentRow.Index].Cells[2].Value.ToString());
                int cant = Convert.ToInt16(nudCantidad.Value); //Obtiene el valor del numeric uptodown
                productosTotales = 0; //Inicialización de la variable que contabiliza el total de productos
                totalventa = 0; // Inicialización de la variable para el total

                //Si la fila seleccionada es mayor a 0...
                if (dgvBusqueda.SelectedRows.Count > 0 && cantidadStock > 0)
                {
                    string valorcelda = dgvBusqueda.Rows[dgvBusqueda.CurrentRow.Index].Cells[0].Value.ToString(); //Obtiene el valor de la celda que en este caso sera el nombre del producto

                    SqlConnection cn = new SqlConnection();
                    cn.ConnectionString = cnString.conectar();
                    //Se hace una busqueda que recibe una tabla con el nombre y el precio de producto en base a el nombre recibido...
                    SqlCommand cmd = new SqlCommand("SELECT NombreProducto, PrecioProducto FROM Productos WHERE NombreProducto = @vNombre", cn); //Se realiza una busqueda con el nombre
                    cmd.Parameters.AddWithValue("@vNombre", valorcelda); //La variable valor celda permite recibir el nombre del elemento y mandarlo como parametro
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader(); //Leemos la salida..

                    if (dr.Read()) //Si hay algo para leer...
                    {
                        //Se añade un nuevo objeto de tipo venta producto que contendrá lo que el lector encuentre en la columna NombreProducto, precio producto
                        //y por ultimo multiplicará el precio por lo obtenido del numericuptodown
                        VentaProductos vp = new VentaProductos(dr["NombreProducto"].ToString(), Convert.ToDouble(dr["PrecioProducto"].ToString()), cant, Convert.ToDouble(dr["PrecioProducto"].ToString()) * cant);

                        listavp.Add(vp); //Y se añade ese objeto a la lista
                        txtBusqueda.Clear(); //Limpia la caja de texto

                        //Se actualiza la tabla
                        dgvBV.DataSource = null;
                        dgvBV.DataSource = listavp;
                    }
                    // Suma los valores de las filas en la columna cantidad
                    foreach (DataGridViewRow row in dgvBV.Rows) //Se recorre el datagridview y se suma la cantidad que contenga en ese momento 
                    {
                        if (row.Cells["Cantidad"].Value != null) //Si la celda de cantidad es diferente de null..
                        {
                            productosTotales += (Int32)row.Cells["Cantidad"].Value; // Se suman los valores de la celda en productos totales
                        }
                    }

                    //Sma los valores en la columna Subtotal
                    foreach (DataGridViewRow row in dgvBV.Rows) // Recorremos el datagridview en sus filas...
                    {
                        if (row.Cells["Subtotal"].Value != null) // Si el valor de la celda subtotal es diferente de null..
                        {
                            totalventa += (Double)row.Cells["Subtotal"].Value; // se suman los valores de subtotal en sus filas 
                        }
                    }

                    //Se mandan los resultados de los foreach a elementos graficos
                    lblCuenta.Text = Convert.ToString(totalventa); //Se manda el resultado final a sus labels...
                    lblProductosTotales.Text = Convert.ToString(productosTotales);

                    cn.Close(); //Cerramos conexion
                }
                else
                {
                    if (cantidadStock == 0)
                    {
                        MessageBox.Show("No puedes agregar este producto\n¡Ya no tienes unidades en stock!", "Error de asignación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("No se puede ejecutar esta acción si no ha asignado algún producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al realizar la operación "+ex.StackTrace, "Error fatal");
            }
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            AdministrarProveedores p = new AdministrarProveedores();
            p.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Administrar_Productos ap = new  Administrar_Productos();
            ap.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdministrarUsuarios au = new AdministrarUsuarios();
            au.Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Escribe él nombre del producto que deseas en la barra de busqueda\n Posteriormente selecciona la cantidad de productos a vender y agrega a la venta\nPara finalizar solo realiza la venta","Ayuda",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvBV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Venta venta = new Venta();
            venta.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void btnEliminarElemento_Click(object sender, EventArgs e)
        {
            //int CantidadPSelect = Convert.ToInt32(dgvBV.Rows[dgvBV.CurrentRow.Index].Cells[2].Value.ToString());
            if (dgvBV.CurrentRow != null && dgvBV.DataSource.Equals(listavp)) // Si la fila seleccionada es mayor a 0...
            { 
                int CantidadPSelect = Convert.ToInt32(dgvBV.Rows[dgvBV.CurrentRow.Index].Cells[2].Value.ToString()); //Obtiene el total de la fila seleccionada en la columna 2 y se asigna
                double SubtotalSelect = Convert.ToDouble(dgvBV.Rows[dgvBV.CurrentRow.Index].Cells[3].Value.ToString()); //Obtiene el valor del subtotal seleccionado
                productosTotales -= CantidadPSelect; //Se resta el valor de la seleccion en cantidad a la variable productos totales
                totalventa -= SubtotalSelect; // sSe resta el subtotal de la seleccion a el total de venta actual
                listavp.RemoveAt(dgvBV.CurrentRow.Index); //Se borra de la lista el objeto seleccionado
                dgvBV.DataSource = null; //Se reinicia la fuente de datos para mostrar los cambios
                dgvBV.DataSource = listavp;
                lblCuenta.Text = Convert.ToString(totalventa); //Se manda el texto neuvo a los labels
                lblProductosTotales.Text = Convert.ToString(productosTotales);
            }
            else
            {
                MessageBox.Show("No se puede realizar la acción, a continuación se describen los posibles casos por los que no se realizó\n1.- No ha seleccionado algún elemento de la venta aún\n2.- Intentas eliminar algun elemento de la bvusqueda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            Console.WriteLine(dgvBV.Rows.Count);
            if (dgvBV.Rows.Count > 0)
            {

                //activo = false;
                btnRealizarVenta.Enabled = activo;
                btnEliminarElemento.Enabled = activo;
                btnAñadirVenta.Enabled = activo;
                //ControlBtn(activo);
                lblTCantidad.Text = totalventa.ToString();
                txtEfectivo.Clear();
                pnConfirmar.Visible = true;
            }
            else
            {
                MessageBox.Show("No se puede proceder, no ha añadido aún\nningun producto a su venta actual", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //ConfirmaVenta cv = new ConfirmaVenta(Convert.ToInt32(lblCuenta.Text));
            //cv.Show();
        }

        public void ControlBtn(bool activo)
        {
            btnRealizarVenta.Enabled = activo;
            btnEliminarElemento.Enabled = activo;
            btnAñadirVenta.Enabled = activo;
        }

        public void Reiniciar()
        {
            listavp.Clear();
            Console.WriteLine(listavp.Count);
            totalventa = 0;
            productosTotales = 0;
            lblProductosTotales.Text = "0";
            lblCuenta.Text = "0";
            dgvBV.DataSource = null;
            dgvBV.DataSource = listavp;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void dgvBV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double efectivo = Convert.ToDouble(txtEfectivo.Text);
            double cambio = efectivo - Convert.ToDouble(lblCuenta.Text);
            //lblCambio.Text = cambio.ToString();
            try
            {
                double subtotal;
                int idVenta = Convert.ToInt32(lblnumV.Text); //Almacena el contenido del label respectivo a las ventas
                DataTable dataDV = new DataTable();

                string fecha = lblDate.Text;


                v.RN_AgregarVenta(idVenta, totalventa, productosTotales, fecha);
                foreach (DataGridViewRow row in dgvBV.Rows)
                {
                    string nProducto = row.Cells["Nombre"].Value.ToString();
                    int cTotal = Convert.ToInt32(row.Cells["Cantidad"].Value.ToString());
                    subtotal = Convert.ToDouble(row.Cells["Subtotal"].Value.ToString());
                    //Console.WriteLine(nProducto + " " + cTotal);

                    dataDV = dv.RN_IdentificarVenta(nProducto);

                    for (int i = 0; i < dataDV.Rows.Count; i++)
                    {
                        int idObenido = Convert.ToInt32((dataDV.Rows[i]["IdProducto"].ToString()));
                        dv.RN_AgregarVentaDV(idVenta, idObenido, cTotal, subtotal);
                        Console.WriteLine("| IdVenta:" + idVenta + "| IdDetalleVenta:" + idVenta + "| IdProducto:" + idObenido + "| Cantidad:" + cTotal);

                        //dv.RN_AgregarVentaDV(1, idVenta, idObenido, cTotal);
                    }
                }
                lblnumV.Text = Convert.ToString(v.RN_ContarVentas());
                pnConfirmar.Visible = false;
                Reiniciar();
                activo = true;
                ControlBtn(activo);
                btnAñadirVenta.Enabled = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            activo = true;
            pnConfirmar.Visible = false;
            Reiniciar();
            ControlBtn(activo);
            btnAñadirVenta.Enabled = false;
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            Pedidos pedidos = new Pedidos();
            pedidos.Show();
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double Cantidad = 0;
                double Efectivo = 0;
                double resta = 0;
                if (txtEfectivo.Text != "")
                {
                    Efectivo = Convert.ToDouble(txtEfectivo.Text);
                    Cantidad = Convert.ToDouble(lblTCantidad.Text);
                    if (Efectivo > Cantidad)
                    {
                        resta = Efectivo - Cantidad;
                        lblCambioCuenta.Text = Convert.ToString(resta);
                    }
                }
                else
                {
                    Console.WriteLine("En else");
                    Efectivo = 0;
                    Cantidad = 0;
                    resta = 0;
                    lblCambioCuenta.Text = Convert.ToString(resta);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error de texto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void dgvBusqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvBusqueda_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int cantidadStock = Convert.ToInt32(dgvBusqueda.Rows[dgvBusqueda.CurrentRow.Index].Cells[2].Value.ToString());
                int cant = Convert.ToInt16(nudCantidad.Value); //Obtiene el valor del numeric uptodown
                productosTotales = 0; //Inicialización de la variable que contabiliza el total de productos
                totalventa = 0; // Inicialización de la variable para el total

                //Si la fila seleccionada es mayor a 0...
                if (dgvBusqueda.SelectedRows.Count > 0 && cantidadStock > 0)
                {
                    string valorcelda = dgvBusqueda.Rows[dgvBusqueda.CurrentRow.Index].Cells[0].Value.ToString(); //Obtiene el valor de la celda que en este caso sera el nombre del producto

                    SqlConnection cn = new SqlConnection();
                    cn.ConnectionString = cnString.conectar();
                    //Se hace una busqueda que recibe una tabla con el nombre y el precio de producto en base a el nombre recibido...
                    SqlCommand cmd = new SqlCommand("SELECT NombreProducto, PrecioProducto FROM Productos WHERE NombreProducto = @vNombre", cn); //Se realiza una busqueda con el nombre
                    cmd.Parameters.AddWithValue("@vNombre", valorcelda); //La variable valor celda permite recibir el nombre del elemento y mandarlo como parametro
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader(); //Leemos la salida..

                    if (dr.Read()) //Si hay algo para leer...
                    {
                        //Se añade un nuevo objeto de tipo venta producto que contendrá lo que el lector encuentre en la columna NombreProducto, precio producto
                        //y por ultimo multiplicará el precio por lo obtenido del numericuptodown
                        VentaProductos vp = new VentaProductos(dr["NombreProducto"].ToString(), Convert.ToDouble(dr["PrecioProducto"].ToString()), cant, Convert.ToDouble(dr["PrecioProducto"].ToString()) * cant);

                        listavp.Add(vp); //Y se añade ese objeto a la lista
                        txtBusqueda.Clear(); //Limpia la caja de texto

                        //Se actualiza la tabla
                        dgvBV.DataSource = null;
                        dgvBV.DataSource = listavp;
                    }
                    // Suma los valores de las filas en la columna cantidad
                    foreach (DataGridViewRow row in dgvBV.Rows) //Se recorre el datagridview y se suma la cantidad que contenga en ese momento 
                    {
                        if (row.Cells["Cantidad"].Value != null) //Si la celda de cantidad es diferente de null..
                        {
                            productosTotales += (Int32)row.Cells["Cantidad"].Value; // Se suman los valores de la celda en productos totales
                        }
                    }

                    //Sma los valores en la columna Subtotal
                    foreach (DataGridViewRow row in dgvBV.Rows) // Recorremos el datagridview en sus filas...
                    {
                        if (row.Cells["Subtotal"].Value != null) // Si el valor de la celda subtotal es diferente de null..
                        {
                            totalventa += (Double)row.Cells["Subtotal"].Value; // se suman los valores de subtotal en sus filas 
                        }
                    }

                    //Se mandan los resultados de los foreach a elementos graficos
                    lblCuenta.Text = Convert.ToString(totalventa); //Se manda el resultado final a sus labels...
                    lblProductosTotales.Text = Convert.ToString(productosTotales);

                    cn.Close(); //Cerramos conexion
                }
                else
                {
                    if (cantidadStock == 0)
                    {
                        MessageBox.Show("No puedes agregar este producto\n¡Ya no tienes unidades en stock!", "Error de asignación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("No se puede ejecutar esta acción si no ha asignado algún producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X-mx, MousePosition.Y - my);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
    }
}
