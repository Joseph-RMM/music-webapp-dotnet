<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Naver_Music_Web.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/inicio.css">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Oxanium:wght@500&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper-linea-m">
        <h1 class="titulo">NAVER MUSIC</h1>
        <h1 class="frase">&nbsp - ¡A votar!</h1>
        <a href="Usuario.aspx"><asp:Image ID="mobileUserImg" runat="server"  CssClass="mobileUserImg" ImageUrl="~/assets/nouser.png" /></a>
    </div>
    <div class="buscar">
        <h3>Buscar</h3>
        <div class="wrapper-linea">
            <asp:TextBox ID="txbBuscar" runat="server" CssClass="textboxbuscar" placeholder="🔎 Canción, Artista, Álbum..."></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btnverde" />
        </div>
        <asp:Panel ID="divBuscar" runat="server" Visible="False">
            <h4>Resultados de búsqueda</h4>
            <h5>Canciones</h5>
            <asp:Panel ID="panelResultados" runat="server" CssClass="wrappercanciones"></asp:Panel>
            <h5>Álbumes</h5>
            <asp:Panel ID="panelResultAlbums" runat="server" CssClass="wrappercanciones"></asp:Panel>
            <h4></h4>
        </asp:Panel>
    </div>

    <h3>Destacados</h3>
    <asp:Panel ID="panelMusic" runat="server" CssClass="wrappercanciones">

    </asp:Panel>
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
