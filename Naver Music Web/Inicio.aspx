<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Naver_Music_Web.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/inicio.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Naver Music</h1>
    <p>Work in progress!</p>
    <div class="buscar">
        <h3>Buscar</h3>
        <asp:TextBox ID="txbBuscar" runat="server" CssClass="textboxbuscar" placeholder="🔎 Canción, Artista, Álbum..."></asp:TextBox>
    </div>

    <h3>Nuevos Lanzamientos</h3>
    <asp:Panel ID="panelMusic" runat="server" CssClass="wrappercanciones">

    </asp:Panel>
</asp:Content>
