<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaDeArticulos.aspx.cs" Inherits="app_CarritoCompras.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de articulos</h1>
    <asp:GridView ID="dgvArticulos" cssClass="table table-dark" runat="server"></asp:GridView>
    <a href="Default.aspx">Regresar al inicio</a>
</asp:Content>