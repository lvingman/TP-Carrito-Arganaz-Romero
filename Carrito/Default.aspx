<%@ Page Title="Catalogo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Carrito._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="title"> Catalogo de Articulos</h1>

    <div class="container">
        <% foreach (dominio.Articulo item in listaArticulos)
           { %>

                <div class="card"> 
                    <img src="<%= item.URLImagen %>" alt="Articulo" />
                    <h4><%= item.Nombre %></h4>
                    <p><%= item.Descripcion %></p>
                    <a href="Carrito?id=<%= item.Id %>">Agregar</a>
                </div>


        <% } %>
    </div>

</asp:Content>
