<%@ Page Title="" Language="C#" MasterPageFile="~/Landing.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Naver_Music_Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/sublanding.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Login</h2>
    <div class="info-wrapper">
        <span>E-mail:</span>
        <asp:TextBox ID="txbEmail" runat="server" CssClass="txb" TextMode="Email" ValidateRequestMode="Inherit"></asp:TextBox>
        <span>Contraseña:</span>
        <asp:TextBox ID="txbContrasena" runat="server" CssClass="txb" TextMode="Password"></asp:TextBox>
        <asp:CheckBox ID="chbAuto" runat="server" Text="Recordarme" CssClass="CheckBox" />
        <asp:Label ID="lblInfo" runat="server" Text="" CssClass="lblInfo"></asp:Label>
        <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn foot" OnClick="btnLogin_Click" />
    </div>
</asp:Content>
