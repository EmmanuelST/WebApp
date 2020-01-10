<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rVentas.aspx.cs" Inherits="WebAplication.rVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="container">

        <div class="form-group  ">
            <asp:Label Text="Id" runat="server" />
            <asp:TextBox ID="IdVentaTextBoxt" CssClass="form-control " TextMode="Number"  Text="0" runat="server" />
            <asp:Button ID="BuscarButton" CssClass="btn btn-outline-secondary " Text="Buscar" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label Text="Fecha" runat="server" />
            <asp:Calendar ID="FechaCalendar" runat="server" OnLoad="FechaCalendar_Load" OnSelectionChanged="FechaCalendar_SelectionChanged"></asp:Calendar>
        </div>

        <div class="form-group  ">
            <asp:Label Text="ClienteId" runat="server" />
            <asp:TextBox ID="IdClienteTextBox" CssClass="form-control " TextMode="Number" Text="0" runat="server"  />
            <asp:Button ID="ClienteBuscarButton" CssClass="btn btn-outline-secondary " Text="Buscar" runat="server" OnClick="ClienteBuscarButton_Click" />
        </div>

        <div class="form-group">
            <asp:Label Text="Cliente" runat="server" />
            <asp:TextBox ID="ClienteTextBox" CssClass="form-control" ReadOnly="True" runat="server" />
        </div>

        <div class="form-group  ">
            <asp:Label Text="VendedorId" runat="server" />
            <asp:TextBox ID="IdVendedorTextBox" CssClass="form-control " TextMode="Number"  Text="0" runat="server" />
            <asp:Button ID="VendedorBuscarButton" CssClass="btn btn-outline-secondary " Text="Buscar" runat="server" OnClick="VendedorBuscarButton_Click" />
        </div>

        <div class="form-group">
            <asp:Label Text="Vendedor" runat="server" />
            <asp:TextBox ID="VendedorTextBox" CssClass="form-control" ReadOnly="true" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label Text="Tipo de Venta" runat="server" />
            <asp:DropDownList ID="TipoVentaDropDownList" CssClass="form-control" runat="server">
                <asp:ListItem Selected="True">Contado</asp:ListItem>
                <asp:ListItem>Credito</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label Text="% interes" runat="server" />
            <asp:TextBox ID="InteresTextBox" CssClass="form-control" runat="server" />
        </div>

        <div class="form-group">
            <asp:Label Text="Vencimiento" runat="server" />
            <asp:Calendar ID="VencimientoCalendar" runat="server" OnSelectionChanged="VencimientoCalendar_SelectionChanged"></asp:Calendar>
        </div>

    </section>

    <section class="container">

        <div class="form-group  ">
            <asp:Label Text="ProductoId:" runat="server" />
            <asp:TextBox ID="ProductoIdTextBox" TextMode="Number"  CssClass="form-control " Text="0" runat="server" />
            <asp:Button ID="BuscarProductoButton" CssClass="btn btn-outline-secondary " Text="Buscar" runat="server" OnClick="BuscarProductoButton_Click" />
            <asp:Label Text="Producto:" runat="server" />
            <asp:TextBox ID="ProductoNombreTextBox" CssClass="form-control " ReadOnly="true" Text="" runat="server" />
            <asp:Label Text="Existencia:" runat="server" />
            <asp:TextBox ID="ExistenciaTextBox" CssClass="form-control " TextMode="Number" Text="0" runat="server" />
            <asp:Label Text="Cantidad:" runat="server" />
            <asp:TextBox ID="CantidadTextBox" TextMode="Number"  CssClass="form-control " Text="0" runat="server" />
            <asp:Button Text="Agregar" ID="AgregarButton" CssClass="btn btn-outline-secondary" runat="server" OnClick="AgregarButton_Click" />
        </div>

        <div class="table-responsive container">
            <asp:GridView ID="ProductosGridView" CssClass="table table-condensed  table-responsive" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="ProductosGridView_SelectedIndexChanged" OnRowCommand="ProductosGridView_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:ButtonField Text="Eliminar" CommandName="EliminarButton"  ItemStyle-CssClass="btn btn-danger btn-sm"  />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:TextBox ID="TotalTextBox" Text="0" CssClass="form-control" runat="server" />  
        </div>

        <div class="container">

            <asp:Button Text="Eliminar" CssClass="btn btn-danger" ID="EliminarTablaButton" runat="server" />
        </div>

        <div class="form-group container">
            <asp:Label Text="Comentario" runat="server" />
            <asp:TextBox ID="ComentarioTextBox" CssClass="form-control" Text="" runat="server" TextMode="MultiLine" />  

        </div>

        <div class="form-group">

            <asp:Button Text="Guardar" ID="GuardarButton" CssClass="btn btn-primary" runat="server" OnClick="GuardarButton_Click" />
            <asp:Button Text="Limpiar" ID="LimpiarButton" CssClass="btn btn-success" runat="server" OnClick="LimpiarButton_Click" />
            <asp:Button Text="Eliminar" ID="EliminarButton" CssClass="btn btn-danger" runat="server" />

        </div>

    </section>

</asp:Content>
