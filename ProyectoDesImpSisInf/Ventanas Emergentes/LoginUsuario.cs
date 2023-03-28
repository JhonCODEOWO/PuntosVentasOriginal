using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P_CapaDatos;
using System.Data.SqlClient;

namespace ProyectoDesImpSisInf.Ventanas_Emergentes
{
    public partial class LoginUsuario : Form
    {
        public LoginUsuario()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BDConexion conect = new BDConexion();
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = conect.conectar();

                SqlCommand cmd = new SqlCommand("SELECT NombreUsuario, Contraseña, Administrador FROM Usuario WHERE NombreUsuario = @vusuario AND Contraseña = @vconstraseña", cn);
                cmd.Parameters.AddWithValue("@vusuario", txtNombreU.Text);
                cmd.Parameters.AddWithValue("@vconstraseña", txtContraseñaU.Text);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable datos = new DataTable();
                sda.Fill(datos);



                if (datos.Rows.Count == 1)
                {
                    this.Hide();
                    Console.WriteLine("Datos insertados");
                    if (datos.Rows[0][2].ToString() == "True")
                    {
                        new Form1(txtNombreU.Text, "Administrador").Show();
                        Console.WriteLine("Administrador");
                        
                    }
                    else if (datos.Rows[0][2].ToString() == "False")
                    {
                    new Form1(txtNombreU.Text, "Usuario").Show();
                    Console.WriteLine("Usuario");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos", "Error al iniciar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error a nivel de código fuente, la excepción encontrada es: "+ ex.Message);
            }
        }

        private void LoginUsuario_Load(object sender, EventArgs e)
        {

        }

        private void txtContraseñaU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNombreU_Leave(object sender, EventArgs e)
        {
            if (txtNombreU.Text == "")
            {
                txtNombreU.Text = "DÍGITE SU NOMBRE DE USUARIO";
                txtNombreU.ForeColor = Color.DimGray;
            }
        }
    }
}
