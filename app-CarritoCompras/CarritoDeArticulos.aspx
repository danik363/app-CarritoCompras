<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CarritoDeArticulos.aspx.cs" Inherits="app_CarritoCompras.CarritoDeArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <style>
                .txbId {
                    display: none;
                }
            </style>
            <asp:Repeater ID="rptCarrito" runat="server" OnItemCommand="rptCarrito_ItemCommand">
                <ItemTemplate>
                    <div class="row">
                        <div class="card mx-auto">
                            <div class="card-body">
                                <asp:HiddenField ID="hfIdArticulo" runat="server" Value='<%# Eval("idArticulo") %>' />
                                <h1 class="card-title"><%# Eval("nombre") %></h1>
                                <h4 class="card-text">Total de la compra:</h4>
                                <h5 class="card-text">$ <%# totalCompra(Convert.ToInt32(Eval("idArticulo"))) %></h5>
                                <h4 class="card-text">Cantidad del artículo en el carrito:</h4>
                                <h5 class="card-text"><%# cantidadArticulos(Convert.ToInt32(Eval("idArticulo"))) %></h5>
                                <p class="card-text">Quitar del carrito</p>
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Eliminar" CommandArgument='<%# Eval("idArticulo") %>' />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <% if (rptCarrito.Items.Count > 0) { %>
                <div class="row justify-content-center">
                    <div class="col-4">
                        <h3 class="card-footer">Total hasta el momento de la compra: $</h3>
                        <asp:Label runat="server" ID="lblTotal">$</asp:Label>
                        <h5 class="card-text">¿Desea quitar del carrito?</h5>
                        <asp:Button runat="server" Text="Atrás" CssClass="btn btn-outline-primary" ID="btnVolver" OnClick="btnVolver_Click" />
                    </div>
                </div>
            <% } else { %>
                <div class="row justify-content-center">
                    <div class="col-4">
                        <h1 class="card-body">Su carrito no tiene artículos aún.</h1>
                        <asp:Button runat="server" Text="Atrás" CssClass="btn btn-outline-primary" ID="btnVolverSin" OnClick="btnVolverSin_Click" />
                    </div>
                </div>
            <% } %>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
