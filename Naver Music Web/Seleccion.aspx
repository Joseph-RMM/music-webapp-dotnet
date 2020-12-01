<%@ Page Title="" Language="C#" MasterPageFile="~/Landing.Master" AutoEventWireup="true" CodeBehind="Seleccion.aspx.cs" Inherits="Naver_Music_Web.Seleccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/sublanding.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registro</h2>
    <div class="info-wrapper">
        <span>Elige tu foto de perfil</span>
        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="fileUp" accept=".jpg,.png" />
        <br />
        <span>Datos opcionales:</span>
        <br />
        <span>Teléfono:</span>
        <asp:TextBox ID="txbTelefono" runat="server" CssClass="txb" TextMode="Phone"></asp:TextBox>
        <span>Sexo:</span>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem Selected="True" Value="NE">No Especificar</asp:ListItem>
            <asp:ListItem Value="M">Masculino</asp:ListItem>
            <asp:ListItem Value="F">Femenino</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        <asp:CheckBox ID="chbAuto" runat="server" Text="Recordarme" CssClass="CheckBox" />
        <asp:Label ID="lblInfo" runat="server" Text="" CssClass="lblInfo" ></asp:Label>
        <asp:Button ID="btnRegistrar" runat="server" Text="Registrarme" CssClass="btn foot" OnClick="btnRegistrar_Click"/>
    </div>
</asp:Content>
