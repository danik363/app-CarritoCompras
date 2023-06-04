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
            if (!idsMostrados.Contains(art.idArticulo)){
                 idsMostrados.Add(art.idArticulo);
        %>
            <div class="col w-auto">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title"><%:art.nombre%></h5>
                        <p class="card-text"><%:art.precio%></p>
                        <p class="card-text"><%:cantidadmostrada%></p>
                    </div>
                </div>
        </div>
       <%}
      }%>
</asp:Content>
