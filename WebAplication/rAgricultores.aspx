<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rAgricultores.aspx.cs" Inherits="WebAplication.rAgricultores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="container">

        <h3 class="text-center mt-2">
            Registro de Clientes
        </h3>

        <div>

            <div class="form-group  ">
                <asp:Label Text="Id" runat="server" />
                <asp:TextBox ID="IdTextBoxt" CssClass="form-control " TextMode="Number"  Text="0" runat="server" />
                <asp:Button ID="BuscarButton" CssClass="btn btn-primary " Text="Buscar" runat="server" OnClick="BuscarButton_Click" />
            </div>

            <div class="form-group">
                <asp:Label Text="Nombre" runat="server" />
                <asp:TextBox ID="NombreTextBox" CssClass="form-control" runat="server" />
            </div>

            <div class="form-group">
                <asp:Label Text="Cedula" runat="server" />
                <asp:TextBox ID="CedulaTextBox" CssClass="form-control" runat="server" />
            </div>

            <div class="form-group">
                <asp:Label Text="Direccion" runat="server" />
                <asp:TextBox ID="DireccionTextBox" CssClass="form-control" runat="server" />
            </div>

            <div class="form-group">
                <asp:Label Text="Telefono" runat="server" />
                <asp:TextBox ID="TelefonoTextBox" CssClass="form-control" runat="server" />
            </div>

            <div class="form-group">
                <asp:Label Text="Celular" runat="server" />
                <asp:TextBox ID="CelularTextBox" CssClass="form-control" runat="server" />
            </div>


            <div class="form-group">
                <asp:Label Text="Fecha de Nacimiento" runat="server" />
                <asp:Calendar ID="NacimientoCalendar" runat="server"></asp:Calendar>
            </div>


            <asp:Button ID="GuardarButton" Text="Guardar" CssClass="btn btn-primary" runat="server" OnClick="GuardarButton_Click"  />
            <asp:Button ID="LimpiarButton" Text="Limpiar" CssClass="btn btn-secondary" runat="server" OnClick="LimpiarButton_Click"  />
            <asp:Button ID="EliminarButton" Text="Eliminar" CssClass="btn btn-danger" runat="server" OnClick="EliminarButton_Click"  />

        </div>


    </section>
</asp:Content>
