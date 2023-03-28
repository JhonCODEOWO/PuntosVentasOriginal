using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P_CapaDatos;
using System.Data;

namespace Prod_CapaNegocio
{
    public class RN_Vistas
    {
        BD_Vistas v = new BD_Vistas();
        public DataTable VistaProdDeVe()
        {
            return v.VistaProdDeVe();
        }
    }
}
