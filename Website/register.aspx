<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Website.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <h2 class="text-center">Register</h2>

    <div role="form" class="col-xs-6 col-xs-offset-3">

        <div class="form-group">
            <input type="text" name="last_name" id="last_name" class="form-control input-md glowing border" placeholder="username" />
        </div>

        <div class="form-group">
            <input type="password" name="password" id="password" class="form-control input-md glowing border" placeholder="password" />
        </div>

        <div class="form-group">
            <input type="password" name="password2" id="password2" class="form-control input-md glowing border" placeholder="verify password" />
        </div>

        <input type="submit" value="Register" class="btn btn-info btn-block"/>
    </div>
</asp:Content>
