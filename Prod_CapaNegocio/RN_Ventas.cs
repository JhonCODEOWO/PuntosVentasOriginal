using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using P_CapaDatos;

namespace Prod_CapaNegocio
{
    public class RN_Ventas
    {
        BD_Ventas V = new BD_Ventas();

        public void RN_AgregarVenta(int id, double pventya, int cventa, string date)
        {
            V.BD_AgregarVenta(id, pventya, cventa, date);
        }

        public void RN_EliminarVenta(int id)
        {
            V.BD_EliminarVenta(id);
        }

        public DataTable RN_MostrarVentas()
        {
            return V.BD_MostrarVentas();
        }
        public DataTable FiltrarPorFechaRecibida(string fecha)
        {
            return V.FiltroPorFecha(fecha);
        }
        public int RN_ContarVentas()
        {
            return V.contarVentas();
        }
    }
}
