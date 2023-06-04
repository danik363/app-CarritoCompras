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
        public List<Articulo> listaArticulos { get; set; }

        public void cantidadArticulosTotales()
        {
            List<ArticulosCarrito> listadoCarrito = Session["listadoCarrito"] != null
            ? (List<ArticulosCarrito>)Session["listadoCarrito"] : new List<ArticulosCarrito>();

            int cantidadTotales = 0;
            foreach (ArticulosCarrito art in listadoCarrito)
            {
                cantidadTotales += art.cantidad;
                Session.Add("CantidadCarrito", cantidadTotales);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulos = negocio.listar();
                List<Imagen> listImagenes = negocio.listImagenes();
                listaArticulos = asignarImagenArticulos(listaArticulos, listImagenes);
                Session.Add("ListaArticulos", listaArticulos);
                Session.Add("ListaImagenes", listImagenes);
                reRepiter.DataSource = (List<Articulo>)(Session["ListaArticulos"]);
                reRepiter.DataBind();
            }
            listaArticulos = (List<Articulo>)(Session["ListaArticulos"]);
        }

        public List<Articulo> asignarImagenArticulos(List<Articulo> listArt, List<Imagen> listImg)
        { //Asigna la primera imagen que encuentra del articulo a cada articulo

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
            Session["ListaArticulos"] = listArt;
            return listArt;
        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {
            Button btnCarrito = (Button)sender;
            int idArticulo = Convert.ToInt32(btnCarrito.CommandArgument);
            List<ArticulosCarrito> listadoCarrito = Session["listadoCarrito"] != null
            ? (List<ArticulosCarrito>)Session["listadoCarrito"] : new List<ArticulosCarrito>();

            Articulo nuevo = new Articulo();
            nuevo = listaArticulos.Find(a => a.Id == idArticulo);

            if (nuevo != null)
            {
                ArticulosCarrito comprado = new ArticulosCarrito();
                comprado.idArticulo = nuevo.Id;
                comprado.nombre = nuevo.Nombre;
                comprado.precio = nuevo.Precio;
                comprado.cantidad = 1;
                listadoCarrito.Add(comprado);
            }
            Session.Add("listadoCarrito", listadoCarrito);
            cantidadArticulosTotales();
        }

        protected void TxtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listafiltrada = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(TxtFiltro.Text.ToUpper()));
            reRepiter.DataSource = listafiltrada;
            reRepiter.DataBind();
        }
    }
}