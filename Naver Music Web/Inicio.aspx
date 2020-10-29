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
