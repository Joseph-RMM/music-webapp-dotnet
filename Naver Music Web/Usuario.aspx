<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="Naver_Music_Web.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Usuario.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Tu cuenta</h1>
    <div class="wrapper-userimg">
        <asp:Image ID="imgFotoUsuario" runat="server" ImageUrl="~/assets/nouser.png" CssClass="imgperfil" />
        <div class="wrapper-cambiarimg">
            <h3>Cambia tu foto de perfil</h3>
            <asp:FileUpload ID="FileUploadImg" runat="server" />
            <asp:Button ID="btnFoto" runat="server" Text="Cambiar" CssClass="btn" />
            <asp:Label ID="lblMsgFoto" runat="server" Text="" CssClass="lblinfo"></asp:Label>
        </div>
    </div>
    <center>
    <div class="wrapper-userinfo">
        <h3>Tu información</h3>
        <table>
            <tr>
                <td><span>Nombre de Usuario:</span></td>
                <td><asp:TextBox ID="txbUserName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><span>Nombre:</span></td>
                <td><asp:TextBox ID="txbNombre" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><span>Apellidos:</span></td>
                <td><asp:TextBox ID="txbApellidos" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <asp:Button ID="btnActualizarInfo" runat="server" Text="Actualizar Información" CssClass="btn" />
        <asp:Label ID="lblMsgInfo" runat="server" Text="" CssClass="lblinfo"></asp:Label>
    </div>
    <div class="wrapper-password">
        <h3>Cambiar contraseña</h3>
        <table>
            <tr>
                <td><span>Contraseña actual:</span></td>
                <td><asp:TextBox ID="txbContraActual" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td><span>Nueva contraseña:</span></td>
                <td><asp:TextBox ID="txbContraNueva" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
        </table>
        <asp:Button ID="btnCambioContra" runat="server" Text="Confirmar cambio" CssClass="btn" />
        <asp:Label ID="lblMsgContra" runat="server" Text="" CssClass="lblinfo"></asp:Label>
    </div>
    </center>
</asp:Content>
