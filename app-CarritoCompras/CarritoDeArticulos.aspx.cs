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
            List<ArticulosCarrito> ListaCarrito = Session["listadoCarrito"] as List<ArticulosCarrito>;
            
            if (ListaCarrito == null)
            {
                ListaCarrito = new List<ArticulosCarrito>();
                Session["listadoCarrito"] = ListaCarrito;
            }
            dgvCarrito.DataSource = ListaCarrito;
            dgvCarrito.DataBind();
        }
    }
}