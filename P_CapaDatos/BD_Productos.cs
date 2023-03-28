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
    public class BD_Productos : BDConexion
    {
        SqlConnection cn = new SqlConnection();
        public void Agregar_Producto(int id, string NombreP, double PrecioTotal, int Stock)
        {
            try
            {
                cn.ConnectionString = conectar();

                SqlCommand cmd = new SqlCommand("SP_InsertaProductos", cn);
                cmd.CommandTimeout = 10;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", id);
                cmd.Parameters.AddWithValue("@NombreProducto", NombreP);
                cmd.Parameters.AddWithValue("@PrecioProducto", PrecioTotal);
                cmd.Parameters.AddWithValue("@CantidadProducto", Stock);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("El producto se ha registrado exitosamente");
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al realizar la transacción: " + ex.Message + ex.StackTrace,
                    "Capa de Datos Producto", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        public void BD_EditarProducto(int id, string NombreP, double PrecioTotal, int Stock)
        {
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("SP_ActualizaProductos", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", id);
                cmd.Parameters.AddWithValue("@NombreProducto", NombreP);
                cmd.Parameters.AddWithValue("@PrecioProducto", PrecioTotal);
                cmd.Parameters.AddWithValue("@CantidadProducto", Stock);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("El producto se ha editado exitosamente");

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al realizar la transacción: " + ex.Message + ex.StackTrace,
                    "Capa Datos Marca", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        public DataTable BD_MostrarProductos()
        {
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("SP_MostrarProductos", cn);
                
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
                    "Capa Datos Categoria", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public void BD_EliminarProducto(int idProd)
        {
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("SP_EliminaProductos", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", idProd);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("La categoria se ha eliminado exitosamente");

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al editar: " + ex.Message + ex.StackTrace,
                    "Capa Datos Marca", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        public DataTable ListarProd()
        {
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("SP_ListarProductos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                adapter = null;
                return dataTable;

            }
            catch (Exception e)
            {
                MessageBox.Show("Excepción encontrada: " + e);
                return null;
            }
        }
    }
}
