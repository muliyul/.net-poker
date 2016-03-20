<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Website.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="jumbotron">
        <h2 class="text-center">Welcome <%: player?.Username %></h2>
    </div>

    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" EmptyDataText="No stats... Go play some hands!" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Rank">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>

                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="col-xs-1"></ItemStyle>

            </asp:TemplateField>
            <asp:BoundField DataField="PlayedOn" HeaderText="PlayedOn" SortExpression="PlayedOn"  />
            <asp:BoundField DataField="Winnings" HeaderText="Winnings" SortExpression="Winnings" />
            <asp:BoundField DataField="Blackjacks" HeaderText="Blackjacks" SortExpression="Blackjacks" />
            <asp:BoundField DataField="WonHands" HeaderText="WonHands" SortExpression="WonHands" />
            <asp:BoundField DataField="LostHands" HeaderText="LostHands" SortExpression="LostHands" />
            <asp:TemplateField HeaderText="Win/Lose Ratio">
                <ItemTemplate>
                    <asp:Label runat="server" ID="wlr"></asp:Label>
                </ItemTemplate>

                <HeaderStyle CssClass="text-center"></HeaderStyle>

                <ItemStyle CssClass="col-xs-1"></ItemStyle>

            </asp:TemplateField>
        </Columns>
    </asp:GridView>


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" SelectCommand="SELECT Games.PlayedOn, Games.Winnings, Games.Blackjacks, Games.WonHands, Games.LostHands FROM Games INNER JOIN Players ON Games.PlayerId = Players.Id" />


    <div class="text-right">
        <asp:Button runat="server" ID="logoutBtn" OnClick="Logout" Text="Logout" CssClass="btn btn-lg btn-danger" />
    </div>
</asp:Content>
