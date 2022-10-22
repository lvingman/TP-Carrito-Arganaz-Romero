<%@ Page Title="Catalogo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Carrito._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    

    <br />
    <h1 class="title"> Catalogo de Articulos</h1>
    <hr />
      <div class="d-flex" role="search">
          <asp:TextBox ID="txtFiltro" runat="server"></asp:TextBox>
        <asp:Button ID="btnFiltro" runat="server" Text="Buscar" OnClick="btnFiltro_Click" />
      </div>    

        <div class="row row-cols-1 row-cols-md-4 g-4">
        <asp:Repeater ID="Repeter" runat="server">
            <ItemTemplate>
                <div class="col p-3">
                        <div class="card pb-1" style="height:100%;" > 
                            <img src="<%#Eval("URLImagen")%>" alt="Articulo" class="card-img-top p-3" />
                            <div class="card-body">
                                <h4 class="card-title"><%#Eval("Nombre")%></h4>
                                <p class="card-text"><%#Eval("Descripcion")%></p>
                                <p class="card-text"> $<%#Eval("Precio")%></p>
                                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modal<%#Eval("Id")%>">
                                  Agregar a Carrito
                                </button>
                                <div class="modal fade" data-keyboard="false" id="modal<%#Eval("Id")%>" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true" data-backdrop="static">
                                  <div class="modal-dialog">
                                    <div class="modal-content">
                                    
                                      <div class="modal-body" style="color:green">
                                       Articulo agregado con exito
                                       <i class="fa fa-check-circle" aria-hidden="true"></i>
                                      </div>
                                      <div class="modal-footer">
                                        <asp:Button ID="btnAgregarCarrito" CssClass="btn btn-primary" runat="server" Text="Continuar aqui" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnAgregarCarrito_Click"/>
                                        <asp:Button ID="btnAgregarCarritoRedirect" CssClass="btn btn-primary" runat="server" Text="Ir a Carrito" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloId" OnClick="btnAgregarCarritoRedirect_Click"/>
                                      </div>
                                    </div>
                                  </div>
                                </div>            
                            </div>                                                         
                        </div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>

        </div>

</asp:Content>
