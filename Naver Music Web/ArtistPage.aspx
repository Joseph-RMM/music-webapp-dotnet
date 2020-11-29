<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArtistPage.aspx.cs" Inherits="Naver_Music_Web.ArtistPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Artist.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AudioPlayerCPH" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper-volver">
        <a href="Inicio.aspx" class="backTxt">🡸 Volver</a>
    </div>
    <div class="wrapper-albumTittle">
        <asp:Image runat="server" ID="artistImg" CssClass="artistImg" ImageUrl="~/assets/music.png" ></asp:Image>
        <div class="wrapper-albumInfo">
            <asp:Label runat="server" ID="lblNombre" Text="Nombre del artista" CssClass="lblTitulo"></asp:Label>
            <div class="wrapper-votefav">
                <asp:Button runat="server" ID="btnVote" Text="♥ votos" CssClass="btnVote nobtn" OnClick="btnVote_Click" />
                <asp:Button runat="server" ID="btnFav" Text="☆" CssClass="btnFav nobtn" OnClick="btnFav_Click" />
            </div>
        </div>
    </div>
    <br />
    <h2>Álbumes</h2>
    <asp:Panel ID="panelAlbumes" runat="server" CssClass="wrappercanciones" ></asp:Panel>
</asp:Content>
