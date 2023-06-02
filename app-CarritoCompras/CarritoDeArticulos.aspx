<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CarritoDeArticulos.aspx.cs" Inherits="app_CarritoCompras.CarritoDeArticulos" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <% foreach (string id in listId)
		{%>
            <p><%: id %></p>
		<% }%> 

</asp:Content>
