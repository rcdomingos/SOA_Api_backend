using System;
using System.Data.SqlClient;

namespace SOA_backend.Pers
{
    public class ConnectionFactory
    {
        SqlConnection conn;

        public SqlConnection GetConnectionDB(out string message)
        {
            /*
             * Server=192.168.1.16
             * Initial Catalog=SOA_20202
             * User Id=sa
             * Password = Sql!Express99
             */
          //  conn = new SqlConnection("Server=192.168.1.13; Initial Catalog=SOA_20202; User Id=sa; Password=Sql!Express99");
            conn = new SqlConnection("Server=127.0.0.1; Initial Catalog=SOA_LOCALGUIDES; User Id=sa; Password=Sql!Express99");

            try
            {
                message = "";
                if (conn == null || conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    return conn;
                }
                else
                {
                    return conn;
                }

            }
            catch (Exception e)
            {
                message = "Erro ao abrir a conexão " + e.ToString();
                return null;
            }


        }
    }
}