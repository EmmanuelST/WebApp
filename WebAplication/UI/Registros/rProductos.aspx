<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rProductos.aspx.cs" Inherits="WebAplication.UI.Registros.rProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="container">

        <h3 class="text-center mt-2">Registro de Productos</h3>

        <div>

            <div class="form-group  ">
                <asp:Label Text="Id" runat="server" />
                <asp:TextBox ID="IdTextBoxt" CssClass="form-control " TextMode="Number"  Text="0" runat="server" />
                <asp:Button ID="BuscarButton" CssClass="btn btn-primary " Text="Buscar" runat="server" OnClick="BuscarButton_Click" />
            </div>
            <div class="form-group">
                <asp:Label Text="Descripción" runat="server" />
                <asp:TextBox ID="DescripcionTextBox" CssClass="form-control" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label Text="Unidad de medida" runat="server" />
                <asp:DropDownList ID="UnidadMedidaDropDownList" CssClass="form-control" runat="server">
                    <asp:ListItem Selected="True">Sacos</asp:ListItem>
                    <asp:ListItem>Libras</asp:ListItem>
                    <asp:ListItem>Fundas</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label Text="Costo" runat="server" />
                <asp:TextBox ID="CostoTextBox" CssClass="form-control" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label Text="Precio" runat="server" />
                <asp:TextBox ID="PrecioTextBox" TextMode="Number"  CssClass="form-control" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label Text="Existencia" runat="server" />
                <asp:TextBox ID="ExistenciaTextBox" TextMode="Number"  CssClass="form-control" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label Text="Observaciones" runat="server" />
                <asp:TextBox ID="ObservacionesTextBox" CssClass="form-control  " Rows="3" runat="server" />
            </div>

           

            <asp:Button ID="GuardarButton" CssClass="btn btn-primary" Text="Guardar" runat="server" OnClick="GuardarButton_Click" />
            <asp:Button ID="EliminarButton" Text="Eliminar" CssClass="btn btn-danger" runat="server" OnClick="EliminarButton_Click"  />
            

        </div>
        
    </section>

    

</asp:Content>

