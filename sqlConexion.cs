using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace Estructuras
{
    public class sqlConexion
    {
        public string strConexion;
        public string strDataBase;
        public string strTable;
        public string cConexion;

        public sqlConexion() 
        {
            strConexion = ObtenerConexion();
        }
        public string cadenaConexion()
        {
            return ObtenerConexion();
        }

        public string ObtenerConexion()
        {
            try
            {
                int counter = 1;
                string line;

                string cDS = "";
                string cBD = "";
                string cUsr = "";
                string cPsw = "";

                string path = HttpContext.Current.Server.MapPath("~\\");
                string path2 = AppDomain.CurrentDomain.BaseDirectory;

                StreamReader file = new StreamReader(path2 + "UserSql.txt");

                while ((line = file.ReadLine()) != null)
                {
                    switch (counter)
                    {
                        case 1:
                            cDS = line; 
                            break;
                        case 2:
                            cBD = line;
                            break;
                        case 3:
                            cUsr = line;
                            break;
                        case 4:
                            cPsw = line;
                            break;
                    }
                    counter++;
                }
                cConexion = "Data Source=" + cDS + ";Initial Catalog=" + cBD + ";Persist Security Info=True;User ID=" + cUsr + ";Password=" + cPsw + "";
                file.Close();
                return cConexion;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable consultaPokemon(string nombrePS, SqlCommand c) 
        {
            SqlConnection conn = new SqlConnection();
            DataTable dt = new DataTable("dt");
            try
            {                                
                conn.ConnectionString = cadenaConexion();
                SqlCommand cmd = new SqlCommand();
                cmd = c;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombrePS;
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw new Exception("Error al ingresar a la base de datos." + ex.Message);
            }
        }
    }
}
