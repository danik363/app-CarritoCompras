using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace app_CarritoCompras
{
    public partial class Master : System.Web.UI.MasterPage
    {

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
            cantidadArticulosTotales();

        }
    }
}