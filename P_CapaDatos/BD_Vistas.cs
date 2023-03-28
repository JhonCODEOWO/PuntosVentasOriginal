using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace P_CapaDatos
{
    public class BD_Vistas:BDConexion
    {
        //"data source=.; Initial Catalog=Tienda; Integrated Security=true"
        SqlConnection connection = new SqlConnection();
        public DataTable VistaProdDeVe()
        {
            try
            {

                //SqlConnection cn = new SqlConnection("data source=.; Initial Catalog=Tienda; Integrated Security=true");
                connection.ConnectionString = conectar();
                SqlCommand command = new SqlCommand("SP_VentasUnionProdDetVe", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable data = new DataTable();
                dataAdapter.Fill(data);
                dataAdapter = null;

                return data;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public DataTable FiltroFecha(DateTime Fecha)
        {
            try
            {
                connection.ConnectionString = conectar();
                SqlCommand command = new SqlCommand("SP_VentasUnionProdDetVe", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Fecha", Fecha);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable data = new DataTable();
                dataAdapter.Fill(data);
                dataAdapter = null;

                return data;
            }
            catch (Exception)
            {

                return null;
            }
            
        }
    }
}
