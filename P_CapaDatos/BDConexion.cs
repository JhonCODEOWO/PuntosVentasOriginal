using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_CapaDatos
{
    public class BDConexion
    {
        public string conectar()
        {
            return "data source=.; Initial Catalog=Tienda; Integrated Security=true";
        }
    }
}
