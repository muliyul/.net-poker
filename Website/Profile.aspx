<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Website.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="jumbotron">
        <h2 class="text-center">Welcome <%: player?.Username %></h2>
    </div>

    <div>
        Your balance is <%: player?.Bank %>$
    </div>

    <div class="text-right">
        <asp:Button runat="server" ID="logoutBtn" OnClick="Logout" Text="Logout" CssClass="btn btn-lg btn-danger" />
    </div>
</asp:Content>
