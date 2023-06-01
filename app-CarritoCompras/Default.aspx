<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="app_CarritoCompras.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .card {
            max-width: 200px;
            margin: 0 auto;
        }

        .cardsContainer {
            padding-top: 40px;
        }
    </style>
    <div class="cardsContainer row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="reRepiter" runat="server">
            <ItemTemplate>
                <a href="/" class="col w-auto text-decoration-none text-reset">
                    <div class="card">
                        <img src="<%# Eval("Imagen.Url") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                        </div>
                    </div>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

