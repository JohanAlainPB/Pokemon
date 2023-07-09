using System;
using System.Data;
using System.Web.UI;
using Clases;
using Estructuras;

namespace inventario
{
    public partial class DetallesInventario : Page
    {
        clsSalida objSalida = new clsSalida();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {                
                sqlPokemon accionPokemon = new sqlPokemon(new clsPokemon
                {
                    idPoke = Convert.ToInt32(idPoke.Text)
                });

                DataTable datos = accionPokemon.consultaPokemon();                

                if (datos.Rows.Count < 1) 
                {
                    throw new Exception("No se encontraron resultados");
                }
                else
                {
                    string nomnbre = datos.Rows[0]["pokename"].ToString();
                    string vida = datos.Rows[0]["HP"].ToString();
                    string ataque = datos.Rows[0]["attack"].ToString();
                    string descripcion = datos.Rows[0]["abilitydescrip"].ToString();
                    string defensa = datos.Rows[0]["defense"].ToString();
                    string habilidad = datos.Rows[0]["abilityname"].ToString();

                    byte[] imagenBytes = (byte[])datos.Rows[0]["imagen"];
                    string imagenBase64 = Convert.ToBase64String(imagenBytes);
                    string imagenUrl = "data:image/png;base64," + imagenBase64;

                    nombrePokemon.InnerText = nomnbre;
                    vidaPokemon.InnerText = vida;
                    ataquePokemon.InnerText = ataque;
                    descripcionPokemon.InnerText = descripcion;
                    defensaPokemon.InnerText = defensa;

                    imagenPokemon.ImageUrl = imagenUrl;

                }
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}