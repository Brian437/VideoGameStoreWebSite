<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="searchGames.aspx.cs" Inherits="viewGames" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Search Games:<asp:TextBox ID="txtSearchGames" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" />
    </p>
    <p>
        <asp:ObjectDataSource ID="odsGames" runat="server" OnSelecting="odsGames_Selecting" SelectMethod="SearchGame" TypeName="CVGS_DAL.ProductDAL_SQL">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtSearchGames" Name="searchString" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
    <asp:GridView ID="gvGames" runat="server" AutoGenerateColumns="False" DataKeyNames="product_id" DataSourceID="odsGames" OnSelectedIndexChanged="gvGames_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" />
            <asp:BoundField DataField="product_name" HeaderText="Product Name" />
            <asp:BoundField DataField="platform_name" HeaderText="Platform" />
            <asp:BoundField DataField="company_name" HeaderText="Publisher" />
            <asp:BoundField DataField="price" DataFormatString="{0:c}" HeaderText="Price" />
            <asp:BoundField DataField="category_name" HeaderText="Category" />
            <asp:BoundField DataField="ESRB_Rating_name" HeaderText="ESRB Rating" />
            <asp:BoundField DataField="release_date" DataFormatString="{0:d}" HeaderText="Release Date" />
            <asp:BoundField DataField="rating" DataFormatString="{0:F2}" HeaderText="Rating" />
        </Columns>
    </asp:GridView>
</asp:Content>