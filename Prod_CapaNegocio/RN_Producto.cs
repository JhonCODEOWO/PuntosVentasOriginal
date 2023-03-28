using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P_CapaDatos;
using System.Data;

namespace Prod_CapaNegocio
{
    public class RN_Producto
    {
        public void RN_RegistrarProducto(int id, string NombreP, double PrecioTotal, int Stock)
        {
            BD_Productos p = new BD_Productos();
            p.Agregar_Producto(id, NombreP, PrecioTotal, Stock);
        }

        public void RN_EditarProducto(int id, string NombreP, double PrecioTotal, int Stock)
        {
            BD_Productos p = new BD_Productos();
            p.BD_EditarProducto(id, NombreP, PrecioTotal, Stock);
        }

        public DataTable MostrarProductos()
        {
            BD_Productos p = new BD_Productos();
            return p.BD_MostrarProductos();
        }

        public void EliminarProducto(int id)
        {
            BD_Productos p = new BD_Productos();
            p.BD_EliminarProducto(id);
        }

        public DataTable ListarProd()
        {
            BD_Productos p = new BD_Productos();
            return p.ListarProd();
        }
    }
}
