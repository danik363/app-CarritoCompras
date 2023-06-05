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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ActualizarCantidadArticulos();
            }
        }

        public void ActualizarCantidadArticulos()
        {
            List<ArticulosCarrito> listadoCarrito = Session["listadoCarrito"] as List<ArticulosCarrito> ?? new List<ArticulosCarrito>();
            int cantidadTotales = 0;
            foreach (ArticulosCarrito art in listadoCarrito)
            {
                cantidadTotales += art.cantidad;
            }
            Session["CantidadCarrito"] = cantidadTotales;

            // Actualizar el valor en el control de la página
            var cantidadCarrito = FindControl("cantidadCarrito") as Literal;
            if (cantidadCarrito != null)
            {
                cantidadCarrito.Text = cantidadTotales.ToString();
            }
        }



    }
}
