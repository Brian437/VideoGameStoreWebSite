<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="viewGame.aspx.cs" Inherits="viewGame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DropDownList ID="ddlMember" runat="server" DataSourceID="odsMember" DataTextField="username" DataValueField="member_id">
    </asp:DropDownList>
    <asp:DetailsView ID="dvGames" runat="server" AutoGenerateRows="False" DataSourceID="odsGameDetail" Height="50px" Width="608px">
        <Fields>
            <asp:BoundField DataField="product_id" HeaderText="ID" />
            <asp:BoundField DataField="product_name" HeaderText="Product Name" />
            <asp:BoundField DataField="platform_name" HeaderText="Platform" />
            <asp:BoundField DataField="company_name" HeaderText="Publisher" />
            <asp:BoundField DataField="price" DataFormatString="{0:c}" HeaderText="Price" />
            <asp:BoundField DataField="category_name" HeaderText="Category" />
            <asp:BoundField DataField="esrb_Rating_name" HeaderText="ESRB Rating" />
            <asp:BoundField DataField="release_date" DataFormatString="{0:d}" HeaderText="Release Date" />
            <asp:BoundField DataField="rating" DataFormatString="{0:f2}" HeaderText="Rating" />
            <asp:BoundField DataField="description" HeaderText="Description" />
        </Fields>
    </asp:DetailsView>
    <asp:ObjectDataSource ID="odsGameDetail" runat="server" SelectMethod="GetData" TypeName="CVGS_DAL.ProductDAL_SQL">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="1" Name="gameID" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMember" runat="server" SelectMethod="GetData" TypeName="CVGS_DAL.MemberDAL_SQL"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsGameReview" runat="server" SelectMethod="GetApprovedReview" TypeName="CVGS_DAL.ProductReviewDAL_SQL">
        <SelectParameters>
            <asp:QueryStringParameter Name="productID" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:Button ID="btnAdd" runat="server" Text="Add To Cart" />
    <asp:Button ID="btnWriteReview" runat="server" Text="Write Review" OnClick="btnWriteReview_Click" />
    <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="odsGameReview">
        <Columns>
            <asp:BoundField DataField="username" HeaderText="username" />
            <asp:BoundField DataField="review_text" HeaderText="Review" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:DropDownList ID="ddlRateGame" runat="server">
        <asp:ListItem Value="1">1/5</asp:ListItem>
        <asp:ListItem Value="2">2/5</asp:ListItem>
        <asp:ListItem Value="3">3/5</asp:ListItem>
        <asp:ListItem Value="4">4/5</asp:ListItem>
        <asp:ListItem Value="5">5/5</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="btnRateGame" runat="server" OnClick="btnRateGame_Click" Text="Rate Game" />
</asp:Content>

