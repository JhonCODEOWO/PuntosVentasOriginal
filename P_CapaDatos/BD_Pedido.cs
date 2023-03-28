using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace P_CapaDatos
{
    public class BD_Pedido : BDConexion
    {
        SqlConnection connection = new SqlConnection();

        public void AgregarPedido(int id, int fkproveedor, int fkproducto, string fecha, int cantidad, double totalpagar)
        {
            try
            {
                connection.ConnectionString = conectar();
                SqlCommand command = new SqlCommand("SP_InsertarPedido", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdPedido", id);
                command.Parameters.AddWithValue("@IdProveedorPedido", fkproveedor);
                command.Parameters.AddWithValue("@IdProductoPedido", fkproducto);
                command.Parameters.AddWithValue("@FechaEntregaPedido", fecha);
                command.Parameters.AddWithValue("@CantidadDeProductosPedido", cantidad);
                command.Parameters.AddWithValue("@PrecioDeCompraPedido", totalpagar);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Se ha agregado el pedido");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción generada al realizar la transaccion: "+ex.Message);
            }
            
        }

        public void EliminarPedido(int id)
        {
            try
            {
                connection.ConnectionString = conectar();

                SqlCommand command = new SqlCommand("SP_EliminaPedido", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdPedido", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Pedido eliminado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        public DataTable VistaPedido()
        {
            try
            {
                connection.ConnectionString = conectar();
                SqlCommand command = new SqlCommand("SP_VistaPedidosProductosProveedores", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable data = new DataTable();
                dataAdapter.Fill(data);
                dataAdapter = null;

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            
        }

        public int IdRecibida(string prov)
        {
            try
            {
                int id = 0;
                connection.ConnectionString = conectar();
                SqlCommand command = new SqlCommand("SP_IdentificaProveedor", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NombreProv", prov);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable data = new DataTable();
                dataAdapter.Fill(data);
                dataAdapter = null;

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    id = Convert.ToInt32(data.Rows[i]["IdProveedor"].ToString());
                }

                return id;
            }
            catch (Exception ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                MessageBox.Show("Error al realizar la transacción: " + ex.Message + ex.StackTrace,
                    "Capa Datos Pedido", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return 0;
            }
        }


        public int IdentificarProducto(string Nombre)
        {
            try
            {
                int id = 0;
                connection.ConnectionString = conectar();
                SqlCommand command = new SqlCommand("SP_IdentificaProducto", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NombreProducto", Nombre);
                SqlDataAdapter da = new SqlDataAdapter(command);

                DataTable data = new DataTable();

                da.Fill(data);
                da = null;

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    id = Convert.ToInt32(data.Rows[i]["IdProducto"].ToString());
                }
                return id;

            }
            catch (Exception ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                MessageBox.Show("Error al realizar la venta: " + ex.Message + ex.StackTrace,
                    "Capa Datos DetalleVenta", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return 0;
            }
        }

        public void ModificarPedido(int id, int fkproveedor, int fkproducto, string fecha, int cantidad, double totalpagar)
        {
            try
            {
                connection.ConnectionString = conectar();
                SqlCommand command = new SqlCommand("SP_ActualizaPedido", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdPedido", id);
                command.Parameters.AddWithValue("@IdProveedorPedido", fkproveedor);
                command.Parameters.AddWithValue("@IdProductoPedido", fkproducto);
                command.Parameters.AddWithValue("@FechaEntregaPedido", fecha);
                command.Parameters.AddWithValue("@CantidadDeProductosPedido", cantidad);
                command.Parameters.AddWithValue("@PrecioDeCompraPedido", totalpagar);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Pedido modificado");
            }
            catch (Exception ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                MessageBox.Show("Error al realizar la modificación: " + ex.Message + ex.StackTrace,
                    "Capa Datos DetalleVenta", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }
    }
}
