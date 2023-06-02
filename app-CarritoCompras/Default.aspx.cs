using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace app_CarritoCompras
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack) //Solo se da cuando apenas ingresas a la pagina
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> listaArticulos = negocio.listar(); //Solo trae informacion del articulo no la imagen
                List<Imagen> listImagenes = negocio.listImagenes(); //Trae todas las imagenes

                listaArticulos = asignarImagenArticulos(listaArticulos, listImagenes);  //Se le asigna una imagen a cada uno

                reRepiter.DataSource = listaArticulos; 
                reRepiter.DataBind();
            }

        }
        public List<Articulo> asignarImagenArticulos(List<Articulo> listArt, List<Imagen> listImg) { //Asigna la primera imagen que encuentra del articulo a cada articulo

            foreach (Imagen img in listImg)
            {
                foreach (Articulo art in listArt)
                {
                    if (img.IdArticulo == art.Id & art.Imagen == null) //Verifica que el articulo no tenga una imagen y que la imagen que se quiere agregar tenga el mismo IdArt que el id del articulo
                    {
                        art.Imagen = img;
                    }
                }
            }
            return listArt;
        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {
            Button btnCarrito = (Button)sender;

            if (Session["Carrito"] == null)
            {
                Session.Add("Carrito", new List<string>());
            }
            else
            {

                ((List<string>)Session["Carrito"]).Add(btnCarrito.CommandArgument.ToString());
            }
        }
    }
}