<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CarritoDeArticulos.aspx.cs" Inherits="app_CarritoCompras.CarritoDeArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
<%@ Import Namespace="Dominio" %>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
    <%
        List<ArticulosCarrito> listadoCarrito = Session["listadoCarrito"] as List<ArticulosCarrito>;
        List<int> idsMostrados = new List<int>();
        foreach (Dominio.ArticulosCarrito art in listadoCarrito)
        {
            int id = art.idArticulo;
            int cantidadmostrada = cantidadArticulos(art.idArticulo);
            decimal total = totalCompra(art.idArticulo);
            if (!idsMostrados.Contains(art.idArticulo))
            {
                idsMostrados.Add(art.idArticulo);
            %>
    
     <div class="row">
         <div class="card mx-auto">
                <div class="card-body">
                    <h1 class="card-title"><%:art.nombre%></h1>
                    <h4 class="card-text">Total de la compra: </h4>
                    <h5 class="card-text">$ <%:total%></h5>
                    <h4 class="card-text">Cantidad del articulo en el carrito:</h4>
                    <h5 class="card-text"><%:cantidadmostrada%></h5>
                    <p class="card-text">Quitar del carrito</p>
                    <asp:Button ID="Button1" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" CommandArgument='<%:id.ToString() %>' />
                 </div>
          </div>
    </div>

            <%}
      }%>

    <%      if (listadoCarrito.Count > 0)
        { %>
        <div class="row justify-content-center">
            <div class="col-4">
                <h3 class="card-footer">Total hasta el momento de la compra: $</h3>
                <asp:Label runat="server" ID="lblTotal">$</asp:Label>
                <h5 class="card-text">¿Desea quitar del carrito?</h5>
               <asp:Button runat="server" Text="Atrás" CssClass="btn btn-outline-primary" ID="btnVolver" OnClick="btnVolver_Click" />
            </div>
        </div>
    <%}
        else
        { %>
         <div class="row justify-content-center">
            <div class="col-4">
               <h1 class ="card-body">Su carrito no tiene articulos aun.</h1>
               <asp:Button runat="server" Text="Atrás" CssClass="btn btn-outline-primary" ID="btnVolverSin" OnClick="btnVolverSin_Click" />
            </div>
        </div>
      <% }%>
        </ContentTemplate>
   </asp:UpdatePanel>
</asp:Content>
