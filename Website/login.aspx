<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Website.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <h2 class="text-center">Please sign in</h2>
    <div class="col-xs-6 col-xs-offset-3">
        <small>Need an <a href="register.aspx">account</a>?</small>

        <div class="form-group">
            <label for="inputEmail" class="sr-only">Email address</label>
            <input type="email" id="inputEmail" class="form-control" placeholder="Email address" required="" autofocus="" />
        </div>
        <div class="form-group">
            <label for="inputPassword" class="sr-only">
                Password</label>
            <input type="password" id="inputPassword" class="form-control" placeholder="Password" required="" />
        </div>
        <div class="form-group checkbox">
            <label>
                <input type="checkbox" value="remember-me" />
                Remember me
            </label>
        </div>
        <button class="btn btn-lg btn-primary" type="submit">Sign in</button>

    </div>
</asp:Content>
