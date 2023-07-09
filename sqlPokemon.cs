using Clases;
using System;
using System.Data.SqlClient;
using System.Data;

namespace Estructuras
{
    public class sqlPokemon
    {
        clsPokemon objPokemon = new clsPokemon();

        public sqlPokemon(clsPokemon o)
        {
            this.objPokemon = o;
        }

        public DataTable consultaPokemon()
        {
            try
            {
                byte[] imagenByte;
                sqlConexion oConsulta = new sqlConexion();

                using (SqlConnection conn = new SqlConnection(oConsulta.cadenaConexion()))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        string nombrePS = "CONSULTAR_POKEMON";
                        cmd.Parameters.Add("pokeId", SqlDbType.SmallInt).Value = this.objPokemon.idPoke;
                        DataTable datos = oConsulta.consultaPokemon(nombrePS, cmd);

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if(reader.Read())
                        {
                            imagenByte = (byte[])reader["imagen"];
                        }
                        conn.Close();

                        return datos; 
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
