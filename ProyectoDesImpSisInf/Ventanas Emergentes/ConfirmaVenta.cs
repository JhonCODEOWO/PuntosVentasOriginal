using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoDesImpSisInf.Ventanas_Emergentes
{
    public partial class ConfirmaVenta : Form
    {
        public ConfirmaVenta(int Total)
        {
            InitializeComponent();
            lblTCantidad.Text = Convert.ToString(Total);
        }

        private void ConfirmaVenta_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Tag = textBox1.Text;
            this.Close();
        }
    }
}
