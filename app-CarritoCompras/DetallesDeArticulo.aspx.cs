using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace app_CarritoCompras
{
    public partial class DetallesDeArticulo : System.Web.UI.Page
    {
        public List<Imagen> ListaImagen { get; set; }
        public Articulo articulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if(id != "")
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    List<Articulo> auxList = new List<Articulo>();  

                    ListaImagen = negocio.listImagenes(id);

                    auxList = negocio.listar(id);
                     
                    articulo = auxList[0]; //Solo saco lo del indice 0 ya que la query solo me trae un elemento dentro de la ListaImagen


                }


            }

        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {
            ///LOGICA DE SESION PARA AÑADIR CARRITO
        }
    }
}