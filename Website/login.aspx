<%@ Page Title="Login" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Website.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <h2 class="text-center">Please sign in</h2>
    <div role="form" class="col-xs-8 col-xs-offset-2">
        <small>Need an <a href="register.aspx">account</a>?</small>

        <div class="form-group">
            <label for="username" class="sr-only">Email address</label>
            <asp:TextBox runat="server" ID="usernameTF" CssClass="form-control input-md glowing border" placeholder="username"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="inputPassword" class="sr-only">
                Password</label>
            <asp:TextBox runat="server" ID="passwordTF" MaxLength="20" TextMode="Password" CssClass="form-control input-md glowing border" placeholder="password"></asp:TextBox>
        </div>

        <asp:Label runat="server" ID="errorLbl"></asp:Label>

        <div class="text-center">
            <asp:Button runat="server" OnClick="Submit" CssClass="btn btn-lg btn-primary" Text="Sign in" />
        </div>
    </div>
</asp:Content>
