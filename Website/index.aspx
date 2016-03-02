<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Website.Views.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="jumbotron text-center">
        <h2>Welcome to Blackjack!</h2>
    </div>

    <h3 class="text-center">Top players</h3>
    <div class="table-responsive">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="No players in the system. Be the first?" CssClass="table table-striped table-bordered table-hover text-center" DataSourceID="PlayerDataSource">
            <Columns>
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="Bank" HeaderText="Bank" SortExpression="Bank" DataFormatString="{0:d}$" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="PlayerDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:default %>" SelectCommand="SELECT DISTINCT [Username], [Bank] FROM [Player] ORDER BY [Bank] DESC" ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
    </div>
</asp:Content>
