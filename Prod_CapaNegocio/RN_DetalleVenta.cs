using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using P_CapaDatos;

namespace Prod_CapaNegocio
{
    public class RN_DetalleVenta
    {
        BD_DetalleVenta v = new BD_DetalleVenta();

        public void RN_AgregarVentaDV(int idv, int idprod, int cantidad, double subtotal)
        {
            v.BD_AgregarVentaDV(idv, idprod, cantidad, subtotal);
        }

        public void RN_EliminarVentaUnaFila(int id)
        {
            v.BD_EliminarVentaUnaFila(id);
        }

        public void RN_EliminarTodosUnaVenta(int id)
        {
            v.BD_EliminarTodosUnaVenta(id);
        }

        public void RN_VaciarVentas()
        {
            v.BD_VaciarVentas();
        }

        public void RN_EditarVentaDV(int iddv, int idv, int idprod, int cantidad)
        {
            v.BD_EditarVentaDV(idv, idprod, cantidad);
        }

        public DataTable RN_MostrarVentasDV()
        {
            return v.BD_MostrarVentasDV();
        }

        public DataTable RN_IdentificarVenta(string Nombre)
        {
            return v.IdentificarProducto(Nombre);
        }
    }
}
