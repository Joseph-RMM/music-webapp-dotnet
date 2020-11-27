<%@ Page Title="" Language="C#" MasterPageFile="~/Landing.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Naver_Music_Web.Registrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/sublanding.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Crea una cuenta</h2>
    <div class="info-wrapper">
        <span>Nombre de Usuario:</span>
        <asp:TextBox ID="txbUsuario" runat="server" CssClass="txb"></asp:TextBox>
        <span>E-mail:</span>
        <asp:TextBox ID="txbEmail" runat="server" CssClass="txb" TextMode="Email"></asp:TextBox>
        <span>Contraseña:</span>
        <asp:TextBox ID="txbContrasena" runat="server" CssClass="txb" TextMode="Password"></asp:TextBox>
        <asp:Label ID="lblInfo" runat="server" Text="" CssClass="lblInfo"></asp:Label>
        <asp:Button ID="btnRegistrar" runat="server" Text="Siguiente" CssClass="btn foot" OnClick="btnRegistrar_Click" />
    </div>
</asp:Content>
