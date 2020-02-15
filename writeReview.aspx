<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="writeReview.aspx.cs" Inherits="WriteReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ObjectDataSource ID="odsGame" runat="server" SelectMethod="GetData" TypeName="CVGS_DAL.ProductDAL_SQL">
        <SelectParameters>
            <asp:QueryStringParameter Name="gameID" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:DropDownList ID="ddlMember" runat="server" DataSourceID="odsMember" DataTextField="username" DataValueField="member_id">
    </asp:DropDownList>
    <asp:ObjectDataSource ID="odsMember" runat="server" SelectMethod="GetData" TypeName="CVGS_DAL.MemberDAL_SQL"></asp:ObjectDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="odsGame" Height="50px" Width="125px">
        <Fields>
            <asp:BoundField DataField="product_name" HeaderText="Game Title" />
            <asp:BoundField DataField="platform_name" HeaderText="Platform" />
            <asp:BoundField DataField="company_name" HeaderText="Company" />
            <asp:BoundField DataField="rating" HeaderText="Rating" />
        </Fields>
    </asp:DetailsView>
    Write a review for this game<br />
    <asp:TextBox ID="txtReview" runat="server" Height="178px" TextMode="MultiLine" Width="624px"></asp:TextBox>
    <br />
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
    <asp:Button ID="btnCancle" runat="server" OnClick="btnCancle_Click" Text="Cancle" />
</asp:Content>

