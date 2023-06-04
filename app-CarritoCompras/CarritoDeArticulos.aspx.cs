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
            }
        }

        public bool articuloRepetido(int id)
        {
            List<ArticulosCarrito> listadoCarrito = Session["listadoCarrito"] != null
            ? (List<ArticulosCarrito>)Session["listadoCarrito"] : new List<ArticulosCarrito>();

            foreach (ArticulosCarrito art in listadoCarrito)
            {
                if (art.idArticulo == id)
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

            int cantidadTotal = 0;
            foreach (ArticulosCarrito art in listadoCarrito)
            {
                if (art.idArticulo == id)
                {
                    cantidadTotal += art.cantidad;
                }
            }
            return cantidadTotal;

        }
        public decimal totalCompra(int id)
        {
            decimal total = 0;
            List<ArticulosCarrito> listadoCarrito = Session["listadoCarrito"] != null
            ? (List<ArticulosCarrito>)Session["listadoCarrito"] : new List<ArticulosCarrito>();
            foreach (ArticulosCarrito art in listadoCarrito)
            {
                if (art.idArticulo == id)
                {
                    total += art.precio;
                }
            }
            return total;
        }
        protected void ActualizarLabel()
        {
            decimal total = compraFinal();

            // Asigna el valor al Text del Label
            lblTotal.Text = total.ToString();
        }

        public decimal compraFinal()
        {

            decimal final = 0;
            List<ArticulosCarrito> listadoCarrito = Session["listadoCarrito"] != null
            ? (List<ArticulosCarrito>)Session["listadoCarrito"] : new List<ArticulosCarrito>();
            foreach (ArticulosCarrito art in listadoCarrito)
            {
                final += art.precio;
            }
            return final;
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = sender as Button;
            List<ArticulosCarrito> listadoCarrito = Session["listadoCarrito"] as List<ArticulosCarrito>;
            List<ArticulosCarrito> nuevaListaCarrito = new List<ArticulosCarrito>();
            if (btnEliminar != null)
            {
                string idSeleccionado = btnEliminar.CommandArgument;
                int idEliminar;
                if (!string.IsNullOrEmpty(idSeleccionado))
                {
                    if (int.TryParse(idSeleccionado, out idEliminar))
                    {
                        int cantidad = cantidadArticulos(idEliminar);
                        if (cantidad > 1)
                        {
                            ArticulosCarrito articuloAEliminar = listadoCarrito.FirstOrDefault(a => a.idArticulo == idEliminar);
                            listadoCarrito.Remove(articuloAEliminar);
                            nuevaListaCarrito = listadoCarrito;
                        }
                        else
                        {
                            foreach(ArticulosCarrito art in listadoCarrito)
                            {
                                if (cantidadArticulos(art.idArticulo) > 1)
                                {
                                    if (art.idArticulo != idEliminar)
                                    {
                                        nuevaListaCarrito.Add(art);
                                    }
                                }
                            }
                        }
                    
                    }
                }
                    Session["listadoCarrito"] = nuevaListaCarrito;
                }
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