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
                    <asp:Label ID="lblName1" runat="server" Text="Canción" CssClass="lblName"></asp:Label>
                    <asp:Label ID="lblArtist1" runat="server" Text="Artista" CssClass="lblArtist" ></asp:Label>
                </div>
                <asp:ImageButton ID="playSong1" runat="server" ImageUrl="~/assets/playcover.png" CssClass="cover-top" />
            </div>
            <asp:Button ID="btnVotarSong1" runat="server" Text="♥ 122,500" CssClass="btn-rate" />
        </div>
        <div class="wrapper-top">
            <div class="wrapper-topimages top-two">
                <img src="assets/Rank2.png" class="img-top" />
                <div class="wrapper-topinfo">
                    <asp:Label ID="lblName2" runat="server" Text="Canción" CssClass="lblName"></asp:Label>
                    <asp:Label ID="lblArtist2" runat="server" Text="Artista" CssClass="lblArtist" ></asp:Label>
                </div>
                <asp:ImageButton ID="playSong2" runat="server" ImageUrl="~/assets/playcover.png" CssClass="cover-top" />
            </div>
            <asp:Button ID="btnVotarSong2" runat="server" Text="♥ 120,500" CssClass="btn-rate" />
        </div>
        <div class="wrapper-top">
            <div class="wrapper-topimages top-three">
                <img src="assets/Rank3.png" class="img-top" />
                <div class="wrapper-topinfo">
                    <asp:Label ID="lblName3" runat="server" Text="Canción" CssClass="lblName"></asp:Label>
                    <asp:Label ID="lblArtist3" runat="server" Text="Artista" CssClass="lblArtist" ></asp:Label>
                </div>
                <asp:ImageButton ID="playSong3" runat="server" ImageUrl="~/assets/playcover.png" CssClass="cover-top" />
            </div>
            <asp:Button ID="btnVotarSong3" runat="server" Text="♥ 22,500" CssClass="btn-rate" />
        </div>
    </div>
    <h2>Álbumes</h2>
    <h2>Artistas</h2>
</asp:Content>
