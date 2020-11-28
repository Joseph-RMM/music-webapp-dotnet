﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="Naver_Music_Web.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Usuario.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Tu cuenta</h1>
    <div class="wrapper-row user-img">
        <asp:Image ID="imgFotoUsuario" runat="server" ImageUrl="~/assets/nouser.png" CssClass="imgperfil" />
        <div class="wrapper-cambiarimg">
            <h3>Cambia tu foto de perfil</h3>
            <asp:FileUpload ID="FileUploadImg" runat="server" />
            <asp:Button ID="btnFoto" runat="server" Text="Cambiar" CssClass="btn" />
            <asp:Label ID="lblMsgFoto" runat="server" Text="" CssClass="lblinfo"></asp:Label>
        </div>
    </div>
    <div class="wrapper-row user-info">
        <div class="wrapper-column">
            <div class="wrapper-userinfo">
                <h3>Tu cuenta</h3>
                <table>
                    <tr>
                        <td><span>Nombre de Usuario:</span></td>
                        <td><asp:TextBox ID="txbUserName" runat="server" CssClass="textbox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><span>Nombre:</span></td>
                        <td><asp:TextBox ID="txbNombre" runat="server" CssClass="textbox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><span>Apellidos:</span></td>
                        <td><asp:TextBox ID="txbApellidos" runat="server" CssClass="textbox"></asp:TextBox></td>
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
                        <td><asp:TextBox ID="txbContraActual" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><span>Nueva contraseña:</span></td>
                        <td><asp:TextBox ID="txbContraNueva" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox></td>
                    </tr>
                </table>
                <asp:Button ID="btnCambioContra" runat="server" Text="Confirmar cambio" CssClass="btn" />
                <asp:Label ID="lblMsgContra" runat="server" Text="" CssClass="lblinfo"></asp:Label>
            </div>

        </div>

        <div class="wrapper-column">
            <h3>Tus artistas favoritos</h3>
            <asp:GridView ID="gvArtistas" runat="server"></asp:GridView>
            <div class="wrapper-row">
                <asp:TextBox ID="txbNuevoArtista" runat="server" CssClass="textbox"></asp:TextBox>
                <asp:Button ID="btnAdd" runat="server" Text="Añadir" CssClass="btn no-margin"></asp:Button>
            </div>
        </div>
        
    </div>
        <br /> <br />
        <asp:Button ID="btnCerrarSesión" runat="server" Text="Cerrar Sesión" CssClass="btn" OnClick="btnCerrarSesión_Click"></asp:Button>

</asp:Content>
