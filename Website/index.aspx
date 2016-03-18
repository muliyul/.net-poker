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
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="col-md-4">
                </asp:BoundField>
                <asp:BoundField DataField="MemberSince" HeaderText="MemberSince" SortExpression="MemberSince" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="col-md-4">
                </asp:BoundField>
                <asp:BoundField DataField="Bank" HeaderText="Bank" SortExpression="Bank" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="col-md-4">
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="PlayerDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT DISTINCT [Username], [MemberSince], [Bank] FROM [Players] ORDER BY [Bank] DESC, [MemberSince]"></asp:SqlDataSource>
    </div>
</asp:Content>
