<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="Naver_Music_Web.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Usuario.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Tu cuenta</h1>
    <div class ="wrapper-row">
        <div class="wrapper-column">
            <asp:Image ID="userImage" runat="server" CssClass="userImage" />
            <asp:Label ID="userName" runat="server" Text="" CssClass="userName"></asp:Label>
        </div>
        <div class="wrapper-column user-data">
            <asp:Label ID="lblCorreo" runat="server" Text="" CssClass="lbl"></asp:Label>
            <asp:Label ID="lblTelefono" runat="server" Text="" CssClass="lbl"></asp:Label>
            <asp:Label ID="lblSexo" runat="server" Text="" CssClass="lbl"></asp:Label>
            <asp:Label ID="lblEstatus" runat="server" Text="" CssClass="lbl"></asp:Label>
            <br />
            <asp:Label ID="lblVotos" runat="server" Text="" CssClass="lbl"></asp:Label>
            <span class="lbl">Puedes votar hasta 100 veces cada día</span>
        </div>
    </div>
    <asp:Button ID="btnCerrarSesión" runat="server" Text="Cerrar Sesión" CssClass="btn" OnClick="btnCerrarSesión_Click"></asp:Button>

</asp:Content>
