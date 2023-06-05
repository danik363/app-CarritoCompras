<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CarritoDeArticulos.aspx.cs" Inherits="app_CarritoCompras.CarritoDeArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
    .divBtn {
        margin-top: 10px;
    }
</style>
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
                    <div class="row justify-content-center">
                        <div class="col-sm-4">
                            <div class="card-body">
                                <asp:HiddenField ID="hfIdArticulo" runat="server" Value='<%# Eval("idArticulo") %>' />
                                <h2 class="card-title"><%# Eval("nombre") %></h2>
                                <h5 class="card-text">Total de la compra:</h5>
                                <h5 class="card-text">$ <%# totalCompra(Convert.ToInt32(Eval("idArticulo"))) %></h5>
                                <h5 class="card-text">Cantidad del artículo en el carrito:</h5>
                                <h5 class="card-text"><%# cantidadArticulos(Convert.ToInt32(Eval("idArticulo"))) %></h5>
                                <p class="card-text" style="color: red" >¿Desea quitarlo del carrito?</p>
                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Eliminar" CommandArgument='<%# Eval("idArticulo") %>' />
                            </div>
                        </div>
                    </div>
                   <hr />
                </ItemTemplate>
            </asp:Repeater>

            <% if (rptCarrito.Items.Count > 0) { %>
                <div class="row justify-content-center">
                    <div class="col-4">
                        <h3 class="card-footer">Total hasta el momento de la compra:</h3>
                      <span>
                       <em>$<em>
                     <asp:Label runat="server" ID="lblTotal" CssClass="mb-3"></asp:Label>
                    </span>
                     <div class="divBtn">                        
                        <asp:Button runat="server" Text="Atrás" CssClass="btn btn-outline-primary" ID="btnVolver" OnClick="btnVolver_Click" />
                      </div> 
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
