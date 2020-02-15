<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="review.aspx.cs" Inherits="review" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ObjectDataSource ID="odsReview" runat="server" SelectMethod="GetData" TypeName="CVGS_DAL.ProductReviewDAL_SQL">
        <SelectParameters>
            <asp:QueryStringParameter Name="reviewID" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="odsReview" Height="295px" Width="630px">
        <Fields>
            <asp:BoundField DataField="review_id" HeaderText="Review ID" />
            <asp:BoundField DataField="username" HeaderText="username" />
            <asp:BoundField DataField="product_name" HeaderText="Game Title" />
            <asp:BoundField DataField="platform_name" HeaderText="Platform" />
            <asp:BoundField DataField="review_text" HeaderText="Review" />
        </Fields>
    </asp:DetailsView>
    <br />
    <asp:Button ID="btnApprove" runat="server" OnClick="btnApprove_Click" Text="Approve" />
&nbsp;<asp:Button ID="btnReject" runat="server" OnClick="btnReject_Click" Text="Remove" />
&nbsp;<asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
</asp:Content>

