<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetallesDeArticulo.aspx.cs" Inherits="app_CarritoCompras.DetallesDeArticulo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .Details{
            width:100%;
            height: 100%;
            display: flex;
            justify-content:center;
            
        }
        .Details__container{
            width: 60%;
            height:auto;

        }
    </style>
    <section class="Details">
        <div class="Details__container">
            <div id="carouselExampleIndicators" class="carousel slide Details__carousel">
                <div class="carousel-indicators">
                    <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                    <% if (ListaImagen.Count > 1)
                        {%>
                    <%for (int i = 0; i < ListaImagen.Count - 1; i++)
                        {%>
                    <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="<%: i+1 %>"></button>
                    <%} %>
                    <%} %>
                </div>
                <div class="carousel-inner">
                    <%foreach (Dominio.Imagen img in ListaImagen)
                        {%>
                    <div class="carousel-item active">
                        <img src="<%: img.Url %>" class="d-block w-100" alt="...">
                    </div>
                    <% }%>
                </div>
                <% if (ListaImagen.Count > 1)
                    {%>
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
                <%} %>
            </div>

            <div>
                <h2><%: articulo.Nombre %></h2>
                <p><%: articulo.Descripcion %></p>
                <a href="/">Volver</a>
                <asp:Button CssClass="btn btn-primary" Text="Agregar al carrito" runat="server" />

            </div>


        </div>
    </section>
</asp:Content>
