using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
namespace P_CapaDatos
{
    public class BD_Usuarios:BDConexion
    {
        SqlConnection cn = new SqlConnection();
        public void AñadirUsuario(int id, string Nombre, byte Adminisrador, long Contraseña)
        {
            try
            {
                cn.ConnectionString = conectar();

                SqlCommand cmd = new SqlCommand("SP_LlenaUsuario", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", id);
                cmd.Parameters.AddWithValue("@NombreUsuario", Nombre);
                cmd.Parameters.AddWithValue("@Administrador", Adminisrador);
                cmd.Parameters.AddWithValue("@Contraseña", Contraseña);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show("El usuario se ha registrado exitosamente");
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al realizar la transacción: " + ex.Message + ex.StackTrace,
                    "Capa Datos Usuario", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        public void EliminarUsuario(int id)
        {
            try
            {
                cn.ConnectionString = conectar();

                SqlCommand cmd = new SqlCommand("SP_EliminaUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", id);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show("El usuario se ha eliminado exitosamente");
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al realizar la transacción: " + ex.Message + ex.StackTrace,
                    "Capa Datos Usuario", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        public DataTable BD_MostrarUsuarios()
        {
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("SP_MostrarUsuarios", cn);
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

        public void ModificarUsuario(int id, string Nombre, byte Adminisrador, long Contraseña)
        {
            try
            {
                cn.ConnectionString = conectar();

                SqlCommand command = new SqlCommand("SP_ActualizaUsuario", cn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdUsuario", id);
                command.Parameters.AddWithValue("@NombreUsuario", Nombre);
                command.Parameters.AddWithValue("@Administrador", Adminisrador);
                command.Parameters.AddWithValue("@Contraseña", Contraseña);
                cn.Open();
                command.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show("Se ha modificado el usuario "+ Nombre.ToLower() + " por seguridad se reiniciará la aplicación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
