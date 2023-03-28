using System;
using System.Data;
using P_CapaDatos;

namespace P_CapaNegocio
{
    public class RN_Productos
    {
        public void RN_RegistrarProducto(string id, string NombreP, double PrecioTotal, int Stock)
        {
            BD_Productos p = new BD_Productos();
            p.Agregar_Producto(id, NombreP, PrecioTotal, Stock);
        }

        public void RN_EditarProducto(string id, string NombreP, double PrecioTotal, int Stock)
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
    }
}
