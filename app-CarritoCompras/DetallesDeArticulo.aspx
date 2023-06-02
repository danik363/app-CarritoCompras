<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetallesDeArticulo.aspx.cs" Inherits="app_CarritoCompras.DetallesDeArticulo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .Details{
            width:100%;
            height: 100vh;
            display: flex;
            justify-content:center;
            align-items: center;
            
        }
        .Details__container{
            width: 70%;
            height: min-content;
            display: flex;
            justify-content:center;
            
        }
        .Details__carousel{
            max-width: 650px;
            margin-right: 3rem;
        }
        .Details__Information{
            text-align: center;
        }
        
    </style>
    <section class="Details">
        <div class="Details__container">
            <div id="carouselExampleIndicators" class="carousel slide Details__carousel">
                <div class="carousel-indicators">
                    <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                    <% if (ListaImagen.Count > 1)  //Si mas de una imagen para el articulo seleccionado se muestran los paginadores de la parte de abajo del carrusel
                        {%>
                    <%for (int i = 0; i < ListaImagen.Count - 1; i++) //Dibuja los botones dependiendo la cantidad de imagenes
                        {%>
                    <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="<%: i+1 %>"></button>
                    <%} %>
                    <%} %>
                </div>
                <div class="carousel-inner">
                    <%foreach (Dominio.Imagen img in ListaImagen)  //Dibuja las imagenes del articulo seleccionado
                        {%>
                    <div class="carousel-item <%if (ListaImagen.IndexOf(img) == 0){%> active <%}%>">
                        <img src="<%: img.Url %>" class="d-block w-100" alt="...">
                    </div>
                    <% }%>
                </div>
                <% if (ListaImagen.Count > 1) //Solo se muestran los botones para cambiar de imagen si hay mas de dos o mas imagenes para el articulo
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

            <div class="Details__Information">
                <h2><%: articulo.Nombre %></h2>
                <p><%: articulo.Descripcion %></p>
                <a href="/Default.aspx" class="btn btn-primary">Volver</a>
                <asp:Button ID="btnCarrito" CssClass="btn btn-danger" Text="Agregar al carrito" runat="server" OnClick="btnCarrito_Click"/>

            </div>


        </div>
    </section>
</asp:Content>
