<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Website.Views.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="jumbotron text-center">
        <h2>Welcome to Blackjack</h2>
    </div>

    <h3 class="text-center">Top players</h3>
    <div class="table-responsive">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Username" DataSourceID="SqlDataSource1" EmptyDataText="No players in the system. Be the first?" CssClass="table table-striped table-bordered table-hover">
            <Columns>
                <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True" SortExpression="Username" />
                <asp:BoundField DataField="Bank" HeaderText="Bank" SortExpression="Bank" DataFormatString="{0}$" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:projectdbConnectionString %>" SelectCommand="SELECT DISTINCT [Username], [Bank] FROM [Player] ORDER BY [Bank] DESC"></asp:SqlDataSource>
    </div>
</asp:Content>
