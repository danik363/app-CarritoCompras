<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="app_CarritoCompras.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .card {
            height: 100%;
            max-height: 500px;
            max-width: 250px;
            margin: 0 auto;
        }

        .cardsContainer {
            padding-top: 40px;
            width: 80%;

        }
        .card__footer{
            width: 100%;
            display:flex;
            justify-content: space-around;
            padding-bottom: 1rem;
        }
        .card__button{
            font-size: 0.8rem;
            font-weight: bold;
           
        }
        .Articles{
            width: 100%;
            display: flex;
            justify-content:center
        }
    </style>
    <asp:Label runat="server" Text="Buscar por nombre"></asp:Label>
    <asp:TextBox ID="TxtFiltro" runat="server" AutoPostBack="true" OnTextChanged="TxtFiltro_TextChanged" ></asp:TextBox>
    <section class="Articles">
        <div class="cardsContainer row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="reRepiter" runat="server">
                <ItemTemplate>
                    <div class="col w-auto">
                        <div class="card">
                            <img src="<%#Eval("Imagen.URL") %>" class="card-img-top" alt="..." onerror="this.src='https://media.istockphoto.com/id/1193046540/es/vector/foto-pr%C3%B3ximamente-icono-de-imagen-ilustraci%C3%B3n-vectorial-aislado-sobre-fondo-blanco-no-hay.jpg?s=612x612&w=0&k=20&c=sblCjtqWoLEpWnqGZMr5yuiltE2bsiuH-WwsecNGSIA=';"> 
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                            </div>
                            <div class="card__footer">
                                <a href="DetallesDeArticulo.aspx/?id=<%# Eval("Id") %>" class="btn btn-info card__button">Ver Detalle</a>
                                <asp:button ID="btnCarrito" CssClass="btn btn-success card__button" runat="server" Text="Agregar al carrito" OnClick="btnCarrito_Click" CommandName="id" CommandArgument='<%# Eval("Id")%>'></asp:button>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </section>
</asp:Content>
