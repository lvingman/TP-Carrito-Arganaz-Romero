<%@ Page Title="Catalogo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Carrito._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="title"> Catalogo de Articulos</h1>
    <hr />
    <div class="container">
        <div class="row">
            <% int i = 1;
                foreach (dominio.Articulo item in listaArticulos)
               { %>
                    <div class="col-3">
                        <div class="card mb-5 p-3" style="height:90%" > 
                            <img src="<%= item.URLImagen %>" alt="Articulo"  />
                            <div class="card-body">
                                <h4 class="card-title"><%= item.Nombre %></h4>
                                <p class="card-text"><%= item.Descripcion %></p>
                            </div>
                            <a class="btn btn-primary mx-2 my-1" href="Carrito?id=<%= item.Id %>">Agregar</a>
                        </div>
                    </div>


            <% } %>
        </div>
    </div>

</asp:Content>
