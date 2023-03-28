using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P_CapaDatos;
using System.Data;

namespace Prod_CapaNegocio
{
    public class RN_Pedidos
    {
        BD_Pedido pedido = new BD_Pedido();

        public void AgregarPedido(int id, int fkproveedor, int fkproducto, string fecha, int cantidad, double totalpagar)
        {
            pedido.AgregarPedido(id, fkproveedor, fkproducto, fecha, cantidad, totalpagar);
        }

        public void EliminarPedido(int id)
        {
            pedido.EliminarPedido(id);
        }
        public int IdRecibido(string nombre)
        {
            return pedido.IdRecibida(nombre);
        }

        public int IdentificarProducto(string nombreP)
        {
            return pedido.IdentificarProducto(nombreP);
        }

        public DataTable Pedido()
        {
            return pedido.VistaPedido();
        }
        public void ModificarPedido(int id, int fkproveedor, int fkproducto, string fecha, int cantidad, double totalpagar)
        {
            pedido.ModificarPedido(id, fkproveedor, fkproducto, fecha, cantidad, totalpagar);
        }
    }
}
