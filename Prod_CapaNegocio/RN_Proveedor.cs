using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using P_CapaDatos;

namespace Prod_CapaNegocio
{
    public class RN_Proveedor
    {
        BD_Proveedores p = new BD_Proveedores();

        public void RN_AgregarProveedor(int id, string NombreProv, long NumTelefono)
        {
            p.AgregarProveedor(id, NombreProv, NumTelefono);
        }

        public void RN_EditarProveedor(int id, string NombreProv, long NumTelefono)
        {
            p.BD_EditarProveedor(id, NombreProv, NumTelefono);
        }

        public void RN_EliminarProveedor(int id)
        {
            p.BD_EliminarProveedor(id);
        }

        public DataTable MostrarProveedores()
        {
            return p.BD_MostrarProveedores();
        }

        public DataTable ListarProv()
        {
            return p.ListarProv();
        }
    }
}
