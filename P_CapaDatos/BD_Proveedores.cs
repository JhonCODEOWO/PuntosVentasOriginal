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
    public class BD_Proveedores : BDConexion
    {
        SqlConnection cn = new SqlConnection();
        public void AgregarProveedor(int id, string NombreProv, long NumTelefono)
        {
            try
            {
                cn.ConnectionString = conectar();

                SqlCommand cmd = new SqlCommand("SP_InsertaProveedor", cn);
                cmd.CommandTimeout = 10;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProveedor", id);
                cmd.Parameters.AddWithValue("@NombreProveedor", NombreProv);
                cmd.Parameters.AddWithValue("@Telefono", NumTelefono);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("El proveedor se ha registrado exitosamente");
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al realizar la transacción: " + ex.Message + ex.StackTrace,
                    "Capa de Datos Proveedor", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        public void BD_EditarProveedor(int id, string NombreProv, long NumTelefono)
        {
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("SP_ActualizaProveedor", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProveedor", id);
                cmd.Parameters.AddWithValue("@NombreProveedor", NombreProv);
                cmd.Parameters.AddWithValue("@Telefono", NumTelefono);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("El proveedor se ha editado exitosamente");

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al realizar la transacción: " + ex.Message + ex.StackTrace,
                    "Capa Datos Proveedor", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        public DataTable BD_MostrarProveedores()
        {
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("SP_MostrarProveedores", cn);
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
                    "Capa Datos Proveedor", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public void BD_EliminarProveedor(int id)
        {
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("SP_EliminaProveedor", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProveedor", id);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("El proveedor se ha eliminado exitosamente");

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al editar: " + ex.Message + ex.StackTrace,
                    "Capa Datos Proveedor", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        public DataTable ListarProv()
        {
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd= new SqlCommand("SP_ListarProveedores", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                adapter = null;
                return dataTable;

            }
            catch (Exception e)
            {
                return null;
            }
            
        }
    }
}
