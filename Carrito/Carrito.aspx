﻿<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Carrito.Contact" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />

    <asp:GridView ID="dgvCarrito" runat="server" AutoGenerateColumns="false" class="table table-bordered table-condensed table-hover " >

        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID Producto" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" >
                 <ItemStyle CssClass="text-center"></ItemStyle>
            </asp:BoundField>
            <asp:ImageField   ControlStyle-Width="50" ControlStyle-Height="50" ControlStyle-CssClass="rounded mx-auto d-block" DataImageUrlField="URLImagen" HeaderText="Imagen">
            </asp:ImageField> 
            <asp:BoundField DataField="Precio" HeaderText="Precio Unitario" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
        </Columns>

    </asp:GridView>

</asp:Content>
