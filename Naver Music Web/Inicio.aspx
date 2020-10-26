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
    <div class="wrappercanciones">
        <div class="wrappermusicitem">
            <img src="assets/music.png" alt="" class="imgcovermusic">
            <span class="songname">Nombre De La Canción</span>
            <span class="artistname">Artista</span>
            <div class="wrapper-ratefav">
                <button class="btn rate">♥ 7,500</button>
                <button class="btn fav">★</button>
            </div>
        </div>
        <div class="wrappermusicitem">
            <img src="assets/music.png" alt="" class="imgcovermusic">
            <span class="songname">Nombre De La Canción</span>
            <span class="artistname">Artista</span>
            <div class="wrapper-ratefav">
                <button class="btn rate">♥ 7,500</button>
                <button class="btn fav">★</button>
            </div>
        </div>
        <div class="wrappermusicitem">
            <img src="assets/music.png" alt="" class="imgcovermusic">
            <span class="songname">Nombre De La Canción</span>
            <span class="artistname">Artista</span>
            <div class="wrapper-ratefav">
                <button class="btn rate">♥ 7,500</button>
                <button class="btn fav">★</button>
            </div>
        </div>
        <div class="wrappermusicitem">
            <img src="assets/music.png" alt="" class="imgcovermusic">
            <span class="songname">Nombre De La Canción</span>
            <span class="artistname">Artista</span>
            <div class="wrapper-ratefav">
                <button class="btn rate">♥ 7,500</button>
                <button class="btn fav">★</button>
            </div>
        </div>
        <div class="wrappermusicitem">
            <img src="assets/music.png" alt="" class="imgcovermusic">
            <span class="songname">Nombre De La Canción</span>
            <span class="artistname">Artista</span>
            <div class="wrapper-ratefav">
                <button class="btn rate">♥ 7,500</button>
                <button class="btn fav">★</button>
            </div>
        </div>
        <div class="wrappermusicitem">
            <img src="assets/music.png" alt="" class="imgcovermusic">
            <span class="songname">Nombre De La Canción</span>
            <span class="artistname">Artista</span>
            <div class="wrapper-ratefav">
                <button class="btn rate">♥ 7,500</button>
                <button class="btn fav">★</button>
            </div>
        </div>
        <div class="wrappermusicitem">
            <img src="assets/music.png" alt="" class="imgcovermusic">
            <span class="songname">Nombre De La Canción</span>
            <span class="artistname">Artista</span>
            <div class="wrapper-ratefav">
                <button class="btn rate">♥ 7,500</button>
                <button class="btn fav">★</button>
            </div>
        </div>
        <div class="wrappermusicitem">
            <img src="assets/music.png" alt="" class="imgcovermusic">
            <span class="songname">Nombre De La Canción</span>
            <span class="artistname">Artista</span>
            <div class="wrapper-ratefav">
                <button class="btn rate">♥ 7,500</button>
                <button class="btn fav">★</button>
            </div>
        </div>
    </div>
</asp:Content>
