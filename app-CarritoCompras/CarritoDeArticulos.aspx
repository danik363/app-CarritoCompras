<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CarritoDeArticulos.aspx.cs" Inherits="app_CarritoCompras.CarritoDeArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%@ Import Namespace="Dominio" %>
    <%
        List<ArticulosCarrito> listadoCarrito = Session["listadoCarrito"] as List<ArticulosCarrito>;
        List<int> idsMostrados = new List<int>();
        foreach (Dominio.ArticulosCarrito art in listadoCarrito)
        {
            int cantidadmostrada =cantidadArticulos(art.idArticulo);
            decimal total = totalCompra(art.idArticulo);
            if (!idsMostrados.Contains(art.idArticulo)){
                idsMostrados.Add(art.idArticulo);
        %>
            <div class="col w-auto">
                <div class="card">
                    <div class="card-body">
                        <h1 class="card-title"><%:art.nombre%></h1>
                        <h4 class="card-text">Total de la compra: </h4>
                        <h5 class="card-text"> $ <%:total%></h5>
                        <h4 class="card-text">Cantidad de articulos en el carrito</h4>
                        <h5 class="card-text"><%:cantidadmostrada%></h5>
                        <asp:Button runat="server" Text="Quitar del carrito" CssClass="btn btn-danger" ID="btnEliminar" OnClick="btnEliminar_Click"  />
                    </div>
                </div>
        </div>
       <%}
      }%><asp:Button runat="server" Text="Atrás" CssClass="btn btn-outline-primary" ID="btnVolver" />
</asp:Content>
