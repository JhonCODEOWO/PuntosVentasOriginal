using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P_CapaDatos;
using System.Data;

namespace Prod_CapaNegocio
{
    public class RN_Usuario
    {
        BD_Usuarios u = new BD_Usuarios();

        public void RN_AgregarUsuario(int id, string Nombreu, byte admin, int pass)
        {
            u.AñadirUsuario(id, Nombreu, admin, pass);
        }

        public void RN_EliminarUsuario(int id)
        {
            u.EliminarUsuario(id);
        }

        public DataTable MostrarUsuarios()
        {
            return u.BD_MostrarUsuarios();
        }

        public void ModificarUsuario(int id, string Nombre, byte Adminisrador, long Contraseña)
        {
            u.ModificarUsuario(id, Nombre, Adminisrador, Contraseña);
        }
    }
}
