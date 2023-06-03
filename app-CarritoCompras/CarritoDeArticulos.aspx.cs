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
        public List<ArticulosCarrito> listado;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<CarritoDeArticulos> listado = Session["listadoCarrito"] as List<CarritoDeArticulos>;

        }
    }
}