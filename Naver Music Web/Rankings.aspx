<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rankings.aspx.cs" Inherits="Naver_Music_Web.Rankings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Rankings.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lo más votado</h1>
    <h2>Canciones</h2>
    <div class="wrapper-top3">
        <div class="wrapper-top">
            <div class="wrapper-topimages top-one">
                <img src="assets/Rank1.png" class="img-top" />
                <div class="wrapper-topinfo">
                    <asp:Label ID="lblSName1" runat="server" Text="Canción" CssClass="lblName"></asp:Label>
                    <asp:Label ID="lblSArtist1" runat="server" Text="Artista" CssClass="lblArtist" ></asp:Label>
                </div>
                <asp:ImageButton ID="playSong1" runat="server" ImageUrl="~/assets/playcover.png" CssClass="cover-top" />
            </div>
            <asp:Button ID="btnRateSong1" runat="server" Text="♥ 122,500" CssClass="btn-rate" />
        </div>
        <div class="wrapper-top">
            <div class="wrapper-topimages top-two">
                <img src="assets/Rank2.png" class="img-top" />
                <div class="wrapper-topinfo">
                    <asp:Label ID="lblSName2" runat="server" Text="Canción" CssClass="lblName"></asp:Label>
                    <asp:Label ID="lblSArtist2" runat="server" Text="Artista" CssClass="lblArtist" ></asp:Label>
                </div>
                <asp:ImageButton ID="playSong2" runat="server" ImageUrl="~/assets/playcover.png" CssClass="cover-top" />
            </div>
            <asp:Button ID="btnRateSong2" runat="server" Text="♥ 120,500" CssClass="btn-rate" />
        </div>
        <div class="wrapper-top">
            <div class="wrapper-topimages top-three">
                <img src="assets/Rank3.png" class="img-top" />
                <div class="wrapper-topinfo">
                    <asp:Label ID="lblSName3" runat="server" Text="Canción" CssClass="lblName"></asp:Label>
                    <asp:Label ID="lblSArtist3" runat="server" Text="Artista" CssClass="lblArtist" ></asp:Label>
                </div>
                <asp:ImageButton ID="playSong3" runat="server" ImageUrl="~/assets/playcover.png" CssClass="cover-top" />
            </div>
            <asp:Button ID="btnRateSong3" runat="server" Text="♥ 22,500" CssClass="btn-rate" />
        </div>
    </div>
    <h2>Álbumes</h2>
    <div class="wrapper-top3">
        <div class="wrapper-top">
            <div class="wrapper-topimages top-one">
                <img src="assets/Rank1.png" class="img-top" />
                <div class="wrapper-topinfo">
                    <asp:Label ID="lblAlbumName1" runat="server" Text="Álbum" CssClass="lblName"></asp:Label>
                    <asp:Label ID="lblAlbumArtist1" runat="server" Text="Artista" CssClass="lblArtist" ></asp:Label>
                </div>
                <asp:Image ID="albumCover1" runat="server" CssClass="cover-top" ImageUrl="~/assets/music.png" />
            </div>
            <asp:Button ID="btnRateAlbum1" runat="server" Text="♥ 122,500" CssClass="btn-rate" />
        </div>
        <div class="wrapper-top">
            <div class="wrapper-topimages top-two">
                <img src="assets/Rank2.png" class="img-top" />
                <div class="wrapper-topinfo">
                    <asp:Label ID="lblAlbumName2" runat="server" Text="Álbum" CssClass="lblName"></asp:Label>
                    <asp:Label ID="lblAlbumArtist2" runat="server" Text="Artista" CssClass="lblArtist" ></asp:Label>
                </div>
                <asp:Image ID="albumCover2" runat="server" CssClass="cover-top" ImageUrl="~/assets/music.png" />
            </div>
            <asp:Button ID="btnRateAlbum2" runat="server" Text="♥ 120,500" CssClass="btn-rate" />
        </div>
        <div class="wrapper-top">
            <div class="wrapper-topimages top-three">
                <img src="assets/Rank3.png" class="img-top" />
                <div class="wrapper-topinfo">
                    <asp:Label ID="lblAlbumName3" runat="server" Text="Canción" CssClass="lblName"></asp:Label>
                    <asp:Label ID="lblAlbumArtist3" runat="server" Text="Artista" CssClass="lblArtist" ></asp:Label>
                </div>
                <asp:Image ID="albumCover3" runat="server" CssClass="cover-top" ImageUrl="~/assets/music.png" />
            </div>
            <asp:Button ID="btnRateAlbum3" runat="server" Text="♥ 22,500" CssClass="btn-rate" />
        </div>
    </div>
    <h2>Artistas</h2>
     <div class="wrapper-top3">
        <div class="wrapper-top">
            <div class="wrapper-topimages top-one">
                <img src="assets/Rank1.png" class="img-top" />
                <div class="wrapper-topinfo">
                    <asp:Label ID="lblArtistName1" runat="server" Text="Artista" CssClass="lblName"></asp:Label>
                </div>
                <asp:Image ID="artistPhoto1" runat="server" CssClass="cover-top" ImageUrl="~/assets/music.png" />
            </div>
            <asp:Button ID="btnRateArtist1" runat="server" Text="♥ 122,500" CssClass="btn-rate" />
        </div>
        <div class="wrapper-top">
            <div class="wrapper-topimages top-two">
                <img src="assets/Rank2.png" class="img-top" />
                <div class="wrapper-topinfo">
                    <asp:Label ID="lblArtistName2" runat="server" Text="Artista" CssClass="lblName"></asp:Label>
                </div>
                <asp:Image ID="artistPhoto2" runat="server" CssClass="cover-top" ImageUrl="~/assets/music.png" />
            </div>
            <asp:Button ID="btnRateArtist2" runat="server" Text="♥ 120,500" CssClass="btn-rate" />
        </div>
        <div class="wrapper-top">
            <div class="wrapper-topimages top-three">
                <img src="assets/Rank3.png" class="img-top" />
                <div class="wrapper-topinfo">
                    <asp:Label ID="lblArtistName3" runat="server" Text="Artista" CssClass="lblName"></asp:Label>
                </div>
                <asp:Image ID="artistPhoto3" runat="server" CssClass="cover-top" ImageUrl="~/assets/music.png" />
            </div>
            <asp:Button ID="btnRateArtist3" runat="server" Text="♥ 22,500" CssClass="btn-rate" />
        </div>
    </div>
</asp:Content>
