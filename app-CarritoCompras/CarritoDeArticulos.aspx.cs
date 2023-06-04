using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace app_CarritoCompras
{
    public partial class CarritoDeArticulos : System.Web.UI.Page
    {
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<ArticulosCarrito> ListaCarrito = Session["listadoCarrito"] as List<ArticulosCarrito>;
            
                if (ListaCarrito == null)
                {
                    ListaCarrito = new List<ArticulosCarrito>();
                    Session["listadoCarrito"] = ListaCarrito;
                }
            }
        }

        public bool articuloRepetido(int id)
        {
            List<ArticulosCarrito> listadoCarrito = Session["listadoCarrito"] != null
            ? (List<ArticulosCarrito>)Session["listadoCarrito"] : new List<ArticulosCarrito>();
            
            foreach(ArticulosCarrito art in listadoCarrito)
            {
                if(art.idArticulo == id)
                {
                    return true;
                }
            }
            return false;
        }

        public int cantidadArticulos(int id)
        {
            List<ArticulosCarrito> listadoCarrito = Session["listadoCarrito"] != null
            ? (List<ArticulosCarrito>)Session["listadoCarrito"] : new List<ArticulosCarrito>();

           int cantidadTotal=0;
           foreach (ArticulosCarrito art in listadoCarrito)
            {
                if (art.idArticulo == id)
                {
                    cantidadTotal += art.cantidad;
                }
            }
            return cantidadTotal;

        }
    }
}