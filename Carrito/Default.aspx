<%@ Page Title="Catalogo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Carrito._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1 class="title"> Catalogo de Articulos</h1>
    <hr />
        <%-- 
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
         --%>

        <div class="row row-cols-1 row-cols-md-4 g-4">
        <asp:Repeater ID="Repeter" runat="server">
            <ItemTemplate>
                <div class="col p-3">
                        <div class="card pb-1" style="height:100%;" > 
                            <img src="<%#Eval("URLImagen")%>" alt="Articulo" style="card-img-top" class="p-3" />
                            <div class="card-body">
                                <h4 class="card-title"><%#Eval("Nombre")%></h4>
                                <p class="card-text"><%#Eval("Descripcion")%></p>
                            </div>                             
                            <asp:Button ID="btnAgregarCarrito" CssClass="btn btn-primary mx-2 my-1" runat="server" Text="Agregar a Carrito" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnAgregarCarrito_Click"/>
                        </div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>

        </div>

</asp:Content>
