<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Album.aspx.cs" Inherits="Naver_Music_Web.Album" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Album.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper-volver">
        <a href="Inicio.aspx" class="backTxt">🡸 Volver</a>
    </div>
    <div class="wrapper-albumTittle">
        <asp:Image runat="server" ID="albumCover" CssClass="albumCover" ImageUrl="~/assets/music.png" ></asp:Image>
        <div class="wrapper-albumInfo">
            <asp:Label runat="server" ID="lblTitulo" Text="Título del álbum" CssClass="lblTitulo"></asp:Label>
            <asp:Label runat="server" ID="lblArtistas" Text="Artista(s)" CssClass="lblArtistas"></asp:Label>
            <div class="wrapper-votefav">
                <asp:Button runat="server" ID="btnVote" Text="♥ votos" CssClass="btnVote nobtn" OnClick="btnVote_Click" />
                <asp:Button runat="server" ID="btnFav" Text="☆" CssClass="btnFav nobtn" />
            </div>
        </div>
    </div>
    <asp:GridView runat="server" ID="gvCanciones" CssClass="gv" AutoGenerateColumns="False" OnRowCommand="gvCanciones_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="id" />
            <asp:BoundField DataField="preview" HeaderText="MP3" />
            <asp:BoundField HeaderText="Canción" DataField="tittle" >
            <ControlStyle CssClass="gvData" />
            <HeaderStyle CssClass="gvHead" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Artista(s)" DataField="artist">
            <ControlStyle CssClass="gvData" />
            <HeaderStyle CssClass="gvHead" />
            </asp:BoundField>
            <asp:ButtonField ButtonType="Button" HeaderText="♥" DataTextField="votes" CommandName="Vote">
            <ControlStyle CssClass="btnVote nobtn gvbtn" />
            <HeaderStyle CssClass="gvHead" />
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Button" HeaderText="☆" DataTextField="favs" CommandName="Fav">
            <ControlStyle CssClass="btnFav nobtn gvbtn" />
            <HeaderStyle CssClass="gvHead" />
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Button" HeaderText="►" Text="►" CommandName="Play">
            <ControlStyle CssClass="btnPlay gvbtn" />
            <HeaderStyle CssClass="gvHead" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AudioPlayerCPH" runat="server">
    <div class="wrapper-musicinfo">
        <asp:Image ID="miniaturaCover" runat="server" CssClass="miniaturaCover" ImageUrl="~/assets/music.png" />
        <div class="miniwrapper-musicinfo">
            <asp:Label ID="miniNombreCancion" runat="server" Text="Puedes escuchar" CssClass="miniNombreCancion"></asp:Label>
            <asp:Label ID="miniNombreArtista" runat="server" Text="hasta 30 segundos" CssClass="miniNombreArtista"></asp:Label>
        </div>
    </div>
    <audio id="Reproductor" src="" controls class="audio-player" autoplay runat="server"></audio>


</asp:Content>