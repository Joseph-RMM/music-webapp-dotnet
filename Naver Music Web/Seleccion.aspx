﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Landing.Master" AutoEventWireup="true" CodeBehind="Seleccion.aspx.cs" Inherits="Naver_Music_Web.Seleccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/sublanding.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registro</h2>
    <div class="info-wrapper">
        <span>Elige tu foto de perfil</span>
        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="fileUp" />
        <asp:Label ID="lblInfo" runat="server" Text="" CssClass="lblInfo" ></asp:Label>
        <asp:Button ID="btnRegistrar" runat="server" Text="Registrarme" CssClass="btn foot"/>
    </div>
</asp:Content>