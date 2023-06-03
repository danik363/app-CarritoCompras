

<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CarritoDeArticulos.aspx.cs" Inherits="app_CarritoCompras.CarritoDeArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <div class="row row-cols-1 row-cols-md-2 g-4">    
<%--    <%  
        foreach(Dominio.ArticulosCarrito comprado in listado)

    { %>     
        <div class="col">
            <div class="card">
                <img src="..." class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title">Card title</h5>
                    <p class="card-text">This is a longer card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                </div>
            </div>
        </div>
    <% }%>--%>
        <asp:GridView ID="dgvCarrito" cssClass="table table-dark" runat="server">
        </asp:GridView>
    </div>
    <a href="/Default.aspx" class="btn btn-primary">Volver</a>
</asp:Content>
