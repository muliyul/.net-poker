<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Website.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <h2 class="text-center">Registration</h2>

    <div role="form" class="col-xs-8 col-xs-offset-2">

        <div class="form-group">
            <asp:TextBox runat="server" ID="usernameTF" MaxLength="20" CssClass="form-control input-md glowing border" placeholder="username"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:TextBox runat="server" ID="passwordTF" MaxLength="20" TextMode="Password" CssClass="form-control input-md glowing border" placeholder="password"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:TextBox runat="server" ID="passwordTF2" MaxLength="20" TextMode="Password" CssClass="form-control input-md glowing border" placeholder="verify password"></asp:TextBox>
        </div>

        <div>
            <asp:Label runat="server" ID="errorLbl"></asp:Label>
        </div>

        <div class="text-center">
            <asp:Button runat="server" OnClick="Submit" CssClass="btn btn-lg btn-primary" Text="Submit" />
        </div>
    </div>
</asp:Content>
