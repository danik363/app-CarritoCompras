﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace app_CarritoCompras
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articulo= new ArticuloNegocio();
            dgvArticulos.DataSource = articulo.listarConSP();
            dgvArticulos.DataBind();

        }
    }
}