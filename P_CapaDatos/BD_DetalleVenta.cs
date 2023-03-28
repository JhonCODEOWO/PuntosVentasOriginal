using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace P_CapaDatos
{
    public class BD_DetalleVenta : BDConexion
    {
        SqlConnection cn = new SqlConnection();
        public void BD_AgregarVentaDV(int idv, int idprod, int cantidad, double subtotal)
        {
            try
            {
                cn.ConnectionString = conectar();

                SqlCommand cmd = new SqlCommand("SP_InsertarDetalleVenta", cn);
                cmd.CommandTimeout = 10;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdVentasDV", idv);
                cmd.Parameters.AddWithValue("@IdProductosDV", idprod);
                cmd.Parameters.AddWithValue("@CantidadDV", cantidad);
                cmd.Parameters.AddWithValue("@Subtotal", subtotal);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al agregar la venta: " + ex.Message + ex.StackTrace,
                    "Capa de Datos DetalleVenta", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        public DataTable BD_MostrarVentasDV()
        {
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("SP_MostrarDetalleVentas", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable data = new DataTable();

                da.Fill(data);
                da = null;
                return data;

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al realizar la consulta: " + ex.Message + ex.StackTrace,
                    "Capa Datos DetalleVenta", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public void BD_EliminarVentaUnaFila(int id)
        {
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("SP_EliminaDetalleVenta", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDetalleVenta", id);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("La venta se ha eliminado exitosamente");

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al eliminar: " + ex.Message + ex.StackTrace,
                    "Capa Datos DetalleVenta", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        public void BD_EliminarTodosUnaVenta(int id)
        {
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("SP_EliminaAllVentaDV", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdDetalleVenta", id);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("La venta se ha eliminado exitosamente");

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al eliminar: " + ex.Message + ex.StackTrace,
                    "Capa Datos DetalleVenta", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        public void BD_VaciarVentas()
        {
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("SP_VaciarDetalleVenta", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("La tabla se ha vaciado exitosamente");

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al vaciar: " + ex.Message + ex.StackTrace,
                    "Capa Datos DetalleVenta", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        public void BD_EditarVentaDV(int idv, int idprod, int cantidad)
        {
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("SP_ActualizaDetalleVenta", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdVentasDV", idv);
                cmd.Parameters.AddWithValue("@IdProductosDV", idprod);
                cmd.Parameters.AddWithValue("@CantidadDV", cantidad);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("La venta se ha editado exitosamente");

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al realizar la venta: " + ex.Message + ex.StackTrace,
                    "Capa Datos DetalleVenta", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        public DataTable IdentificarProducto(string Nombre)
        {
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand command = new SqlCommand("SP_IdentificaProducto", cn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@NombreProducto", Nombre);
                SqlDataAdapter da = new SqlDataAdapter(command);
                
                DataTable data = new DataTable();

                da.Fill(data);
                da = null;
                
                return data;

            }
            catch (Exception ex)
            {
                if(cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al realizar la venta: " + ex.Message + ex.StackTrace,
                    "Capa Datos DetalleVenta", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return null;
            }
        }
    }
}
