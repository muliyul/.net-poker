<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Website.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="row jumbotron">
        <h2 class="text-center">Welcome <%: player?.Username %></h2>
    </div>

    <h2>Your rank:
        <asp:Label runat="server" ID="rankLbl"></asp:Label>
    </h2>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>"></asp:SqlDataSource>

    <h2>Game History</h2>

    <div class="row">
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" EmptyDataText="No stats... Go play some hands!" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" CssClass="table table-striped table-bordered table-hover text-center table-condensed" AllowPaging="True" AllowSorting="True">
            <Columns>
                <asp:TemplateField HeaderText="#">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>

                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="col-xs-1"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="PlayedOn" HeaderText="Played On" SortExpression="PlayedOn" DataFormatString="{0:HH:mm dd.MM.yyyy}">
                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="col-xs-6"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Winnings" HeaderText="Winnings" SortExpression="Winnings" DataFormatString="{0}$">
                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="col-xs-1"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Blackjacks" HeaderText="Blackjacks" SortExpression="Blackjacks">
                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="col-xs-1"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="WonHands" HeaderText="Hands Won" SortExpression="WonHands">
                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="col-xs-1"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="LostHands" HeaderText="Hands Lost" SortExpression="LostHands">
                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="col-xs-1"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Win Ratio">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="wlr"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle CssClass="text-center"></HeaderStyle>

                    <ItemStyle CssClass="col-xs-1"></ItemStyle>

                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnectionString %>" />


    <div class="text-right">
        <asp:Button runat="server" ID="logoutBtn" OnClick="Logout" Text="Logout" CssClass="btn btn-lg btn-danger" />
    </div>
</asp:Content>
