<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="play.aspx.cs" Inherits="Website.Views.play" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="jumbotron text-center">
        <h2>Welcome to Blackjack!</h2>
    </div>

    <h3 class="text-center">Tables</h3>

    <asp:Table runat="server" ID="blackJackTables">
        
    </asp:Table>
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
