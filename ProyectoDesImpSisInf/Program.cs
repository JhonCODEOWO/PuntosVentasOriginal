using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoDesImpSisInf.Ventanas_Emergentes;

namespace ProyectoDesImpSisInf
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginUsuario());
            //Application.Run(new Pedidos());
            //Application.Run(new Venta());
            //Application.Run(new Form1("Jonathan", "Administrador"));
        }
    }
}
