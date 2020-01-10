<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="State.aspx.cs" Inherits="WebAplication.State" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="container">

        <div>
            <h3 class="text-center mt-2">Prueba de ViewState</h3>

            <div class="form-group">
                <asp:Label Text="Numero" runat="server" CssClass="form-control" />
                <asp:TextBox runat="server" ID="NumeroTextBox" CssClass="form-control" />
                <asp:Button Text="Aumentar" ID="AumentarButton" runat="server" CssClass="btm btn-primary" OnClick="AumentarButton_Click" />
            </div>


        </div>


    </section>



</asp:Content>
