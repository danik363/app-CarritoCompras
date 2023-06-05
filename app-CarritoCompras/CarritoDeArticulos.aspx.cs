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
                ActualizarLabel();
                BindRepeater();
            }
        }

        protected void rptCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idArticulo;
                if (int.TryParse(e.CommandArgument.ToString(), out idArticulo))
                {
                    EliminarArticulo(idArticulo);
                    var master = Master as Master;
                    if (master != null)
                    {
                        master.ActualizarCantidadArticulos();
                    }
                    ActualizarLabel();
                    BindRepeater();
                }
            }
        }

        private void EliminarArticulo(int idArticulo)
        {
            List<ArticulosCarrito> listadoCarrito = Session["listadoCarrito"] as List<ArticulosCarrito>;

            if (listadoCarrito != null)
            {
                ArticulosCarrito articuloAEliminar = listadoCarrito.FirstOrDefault(a => a.idArticulo == idArticulo);

                if (articuloAEliminar != null)
                {
                    listadoCarrito.Remove(articuloAEliminar);
                    Session["listadoCarrito"] = listadoCarrito;
                    
                }
            }
        }

        protected void BindRepeater()
        {
            List<ArticulosCarrito> listadoCarrito = Session["listadoCarrito"] as List<ArticulosCarrito>;

            if (listadoCarrito != null)
            {
                rptCarrito.DataSource = listadoCarrito;
                rptCarrito.DataBind();
            }
        }

        protected void ActualizarLabel()
        {
            decimal total = compraFinal();

            lblTotal.Text = total.ToString();
        }

        public decimal compraFinal()
        {
            decimal final = 0;
            List<ArticulosCarrito> listadoCarrito = Session["listadoCarrito"] as List<ArticulosCarrito>;

            if (listadoCarrito != null)
            {
                final = listadoCarrito.Sum(a => a.precio);
            }

            return final;
        }

        public string totalCompra(int idArticulo)
        {
            List<ArticulosCarrito> listadoCarrito = Session["listadoCarrito"] as List<ArticulosCarrito>;

            if (listadoCarrito != null)
            {
                ArticulosCarrito articulo = listadoCarrito.FirstOrDefault(a => a.idArticulo == idArticulo);

                if (articulo != null)
                {
                    decimal total = articulo.precio * articulo.cantidad;
                    return total.ToString();
                }
            }

            return "0";
        }

        public string cantidadArticulos(int idArticulo)
        {
            List<ArticulosCarrito> listadoCarrito = Session["listadoCarrito"] as List<ArticulosCarrito>;

            if (listadoCarrito != null)
            {
                int cantidad = listadoCarrito.Where(a => a.idArticulo == idArticulo).Sum(a => a.cantidad);
                return cantidad.ToString();
            }

            return "0";
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnVolverSin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
