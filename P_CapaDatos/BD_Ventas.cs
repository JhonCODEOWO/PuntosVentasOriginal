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
    public class BD_Ventas : BDConexion
    {
        SqlConnection cn = new SqlConnection();
        public void BD_AgregarVenta(int id, double pventa, int cantp, string fventa)
        {
            try
            {
                cn.ConnectionString = conectar();

                SqlCommand cmd = new SqlCommand("SP_InsertaVenta", cn);
                cmd.CommandTimeout = 10;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdVenta", id);
                cmd.Parameters.AddWithValue("@PrecioVenta", pventa);
                cmd.Parameters.AddWithValue("@CantPVendidos", cantp);
                cmd.Parameters.AddWithValue("@FechaV", fventa);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("La venta se ha registrado exitosamente");
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al realizar la venta: " + ex.Message + ex.StackTrace,
                    "Capa de Datos Venta", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        public DataTable BD_MostrarVentas()
        {
            try
            {
                //cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("SP_MostrarVentas", cn);
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
                    "Capa Datos Venta", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public void BD_EliminarVenta(int id)
        {
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("SP_EliminaVenta", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdVenta", id);

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
                    "Capa Datos Venta", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        public int contarVentas()
        {
            try
            {
                cn.ConnectionString = conectar();
                
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SP_ContarVentas", cn);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataAdapter = null;

                return Convert.ToInt32(dataTable.Rows[0]["Numero de venta"].ToString())+1;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al realizar la transacción: " + ex.Message + ex.StackTrace,
                    "Capa Datos Venta", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return 0;
            }

        }

        public DataTable FiltroPorFecha(string fecha)
        {
            try
            {
                cn.ConnectionString = conectar();

                SqlCommand command = new SqlCommand("SP_FiltrarPorFecha", cn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FechaRecibida", fecha);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable data = new DataTable();
                adapter.Fill(data);
                adapter = null;

                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ ex);
                return null;
            }
        }
    }
}
