<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createReport.aspx.cs" Inherits="createReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style59
    {
        text-align: left;
    }
    .style60
    {
        text-align: center;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p class="style60">
    Create Report</p>
<p class="style59">
    &nbsp;</p>
<p class="style59">
    Report Type:
    <asp:DropDownList ID="ddlReportList" runat="server" OnSelectedIndexChanged="ddlReportList_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem>Game List Report</asp:ListItem>
        <asp:ListItem>Game Detail Report</asp:ListItem>
        <asp:ListItem>Member List Report</asp:ListItem>
        <asp:ListItem>Member Detail Report</asp:ListItem>
        <asp:ListItem>Wish List Report</asp:ListItem>
        <asp:ListItem>Sales Report</asp:ListItem>
        <asp:ListItem>New Reviews</asp:ListItem>
        <asp:ListItem>All Reviews</asp:ListItem>
    </asp:DropDownList>
</p>
<p class="style59">
    Date: From
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp; To
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
</p>
    <p class="style59">
        &nbsp;</p>
<p class="style59">
    <asp:ObjectDataSource ID="odsGame" runat="server" DeleteMethod="Delete" SelectMethod="GetData" TypeName="CVGS_DAL.ProductDAL_SQL">
        <DeleteParameters>
            <asp:Parameter Name="gameID" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsDetailGame" runat="server" SelectMethod="GetData" TypeName="CVGS_DAL.ProductDAL_SQL" UpdateMethod="Update">
        <SelectParameters>
            <asp:ControlParameter ControlID="gvGames" DefaultValue="0" Name="gameID" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="gameID" Type="Int32" />
            <asp:Parameter Name="gameTitle" Type="String" />
            <asp:Parameter Name="gamePlatformID" Type="Int32" />
            <asp:Parameter Name="publisherID" Type="Int32" />
            <asp:Parameter Name="price" Type="Decimal" />
            <asp:Parameter Name="categoryID" Type="Int32" />
            <asp:Parameter Name="ESRB_RatingID" Type="Int32" />
            <asp:Parameter Name="releaseDate" Type="DateTime" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMembers" runat="server" SelectMethod="GetData" TypeName="CVGS_DAL.MemberDAL_SQL"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMemberDetails" runat="server" SelectMethod="GetData" TypeName="CVGS_DAL.MemberDAL_SQL">
        <SelectParameters>
            <asp:ControlParameter ControlID="gvMembers" DefaultValue="1" Name="memberID" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsNewReviews" runat="server" SelectMethod="GetUnapprovedReview" TypeName="CVGS_DAL.ProductReviewDAL_SQL"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsAllReview" runat="server" SelectMethod="GetData" TypeName="CVGS_DAL.ProductReviewDAL_SQL"></asp:ObjectDataSource>
    <asp:GridView ID="gvGames" runat="server" AutoGenerateColumns="False" DataKeyNames="product_id" DataSourceID="odsGame" OnSelectedIndexChanged="gvGames_SelectedIndexChanged" Visible="False" OnRowDeleting="gvGames_RowDeleting">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
            <asp:BoundField DataField="product_name" HeaderText="Product Name" />
            <asp:BoundField DataField="platform_name" HeaderText="Platform" />
            <asp:BoundField DataField="company_name" HeaderText="Publisher" />
            <asp:BoundField DataField="price" DataFormatString="{0:c}" HeaderText="Price" />
            <asp:BoundField DataField="category_name" HeaderText="Category" />
            <asp:BoundField DataField="ESRB_Rating_name" HeaderText="ESRB Rating" />
            <asp:BoundField DataField="release_date" DataFormatString="{0:d}" HeaderText="Release Date" />
            <asp:BoundField DataField="rating" DataFormatString="{0:f2}" HeaderText="Rating" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnAddGame" runat="server" OnClick="btnAddGame_Click" Text="Add Game" />
</p>
    <p class="style59">
        <asp:DetailsView ID="dvGames" runat="server" AutoGenerateRows="False" DataSourceID="odsDetailGame" Height="50px" Width="608px" Visible="False">
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
        <asp:Button ID="btnEditGame" runat="server" OnClick="btnEditGame_Click" Text="Edit" />
        <asp:Button ID="btnGameDelete" runat="server" OnClick="btnGameDelete_Click" Text="Delete" />
        <asp:Button ID="btnBackToGameGride" runat="server" OnClick="btnBackToGameGride_Click" Text="Back" Visible="False" />
</p>
    <p class="style59">
        <asp:GridView ID="gvMembers" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="odsMembers" OnSelectedIndexChanged="gvMembers_SelectedIndexChanged" Visible="False">
            <Columns>
                <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
                <asp:BoundField DataField="first_name" HeaderText="First Name" />
                <asp:BoundField DataField="last_name" HeaderText="Last Name" />
                <asp:BoundField DataField="username" HeaderText="User Name" />
                <asp:BoundField DataField="phone" HeaderText="Phone" />
                <asp:BoundField DataField="role" HeaderText="Role" />
                <asp:BoundField DataField="email" HeaderText="Email" />
            </Columns>
        </asp:GridView>
</p>
    <p class="style59">
        <asp:DetailsView ID="dvMember" runat="server" DataSourceID="odsMemberDetails" Height="50px" Width="526px" AutoGenerateRows="False" Visible="False">
            <Fields>
                <asp:BoundField DataField="member_id" HeaderText="ID" />
                <asp:BoundField DataField="first_name" HeaderText="First Name" />
                <asp:BoundField DataField="last_name" HeaderText="Last Name" />
                <asp:BoundField DataField="username" HeaderText="Username" />
                <asp:BoundField DataField="phone" HeaderText="Phone Number" />
                <asp:BoundField DataField="is_locked" HeaderText="Is Locked" />
                <asp:BoundField DataField="password_attempt_count" HeaderText="password_attempt_count" />
                <asp:BoundField DataField="promotional_emails" HeaderText="promotional_emails" />
                <asp:BoundField DataField="role" HeaderText="role" />
            </Fields>
        </asp:DetailsView>
        <asp:Button ID="btnBackToMemberGrid" runat="server" OnClick="btnBackToMemberGrid_Click" Text="Back" Visible="False" />
</p>
    <asp:GridView ID="gvNewReviews" runat="server" AutoGenerateColumns="False" DataSourceID="odsNewReviews" Visible="False" Width="702px" DataKeyNames="review_id" OnSelectedIndexChanged="gvNewReviews_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            <asp:BoundField DataField="username" HeaderText="username" />
            <asp:BoundField DataField="product_name" HeaderText="Game" />
            <asp:BoundField DataField="platform_name" HeaderText="Platform" />
            <asp:BoundField DataField="review_text" HeaderText="Review Text" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:GridView ID="gvAllReviews" runat="server" AutoGenerateColumns="False" DataSourceID="odsAllReview" Visible="False" Width="702px" DataKeyNames="review_id" OnSelectedIndexChanged="gvAllReviews_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
            <asp:BoundField DataField="username" HeaderText="username" />
            <asp:BoundField DataField="product_name" HeaderText="Game" />
            <asp:BoundField DataField="platform_name" HeaderText="Platform" />
            <asp:BoundField DataField="approved" HeaderText="Approved" />
            <asp:BoundField DataField="review_text" HeaderText="Review Text" />
        </Columns>
    </asp:GridView>
    <br />
</asp:Content>

