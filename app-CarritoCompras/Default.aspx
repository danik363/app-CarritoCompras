<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="app_CarritoCompras.Default" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .card {
            max-width: 250px;
            margin: 0 auto;
        }

        .cardsContainer {
            padding-top: 40px;
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
    </style>
    <div class="cardsContainer row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="reRepiter" runat="server">
            <ItemTemplate>
                <div class="col w-auto">
                    <div class="card">
                        <img src="<%# Eval("Imagen.Url") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                        </div>
                        <div class="card__footer">
                            <a href="DetallesDeArticulo.aspx/?id=<%# Eval("Id") %>" class="btn btn-info card__button">Ver Detalle</a>
                            <asp:button  CssClass="btn btn-success card__button" runat="server" Text="Agregar al carrito"></asp:button>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

