<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Naver_Music_Web.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/inicio.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>★ Lo que más te gusta ★</h1>
    <h2>Canciones</h2>
    <asp:Panel ID="panelCanciones" runat="server" CssClass="wrappercanciones"></asp:Panel>
    <h2>Álbumes</h2>
    <asp:Panel ID="panelAlbumes" runat="server" CssClass="wrappercanciones"></asp:Panel>
    <h2>Artistas</h2>
    <asp:Panel ID="panelArtistas" runat="server" CssClass="wrappercanciones"></asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="AudioPlayerCPH" runat="server">
    <div class="wrapper-musicinfo">
        <asp:Image ID="miniaturaCover" runat="server" CssClass="miniaturaCover" ImageUrl="~/assets/music.png" />
        <div class="miniwrapper-musicinfo">
            <asp:Label ID="miniNombreCancion" runat="server" Text="Puedes escuchar" CssClass="miniNombreCancion"></asp:Label>
            <asp:Label ID="miniNombreArtista" runat="server" Text="hasta 30 segundos" CssClass="miniNombreArtista"></asp:Label>
        </div>
    </div>
    <audio id="Reproductor" src="" controls class="audio-player" autoplay runat="server"></audio>
</asp:Content>
