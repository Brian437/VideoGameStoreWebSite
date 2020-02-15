<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="addGame.aspx.cs" Inherits="addGame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td colspan="2" width="100">
                Add New Game</td>
        </tr>
        <tr>
            <td width="100">
                Game ID</td>
            <td width="100">
                <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="100">
                Game Title</td>
            <td width="100">
                <asp:TextBox ID="txtGameTitle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="100">
                Publisher</td>
            <td width="100">
                <asp:DropDownList ID="ddlPublisher" runat="server" DataSourceID="odsPublisher" DataTextField="company_Name" DataValueField="publisher_ID">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="100">
                Rating</td>
            <td width="100">
                <asp:DropDownList ID="ddlRating" runat="server" DataSourceID="odsESRB_Rating" DataTextField="esrb_rating_name" DataValueField="esrb_rating_id">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Early Childhood</asp:ListItem>
                    <asp:ListItem>Everyone</asp:ListItem>
                    <asp:ListItem>Everyone 10+</asp:ListItem>
                    <asp:ListItem>Everyone 10+</asp:ListItem>
                    <asp:ListItem>Teen</asp:ListItem>
                    <asp:ListItem>Mature</asp:ListItem>
                    <asp:ListItem>Adults</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="100" class="auto-style1">
                Game Platform</td>
            <td width="100" class="auto-style1">
                <asp:DropDownList ID="ddlPlatform" runat="server" DataSourceID="odsPlatform" DataTextField="platform_name" DataValueField="platform_id">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>PS4</asp:ListItem>
                    <asp:ListItem>Xbox1</asp:ListItem>
                    <asp:ListItem>PS3</asp:ListItem>
                    <asp:ListItem>Xbox360</asp:ListItem>
                    <asp:ListItem>PSVITA</asp:ListItem>
                    <asp:ListItem>Wii</asp:ListItem>
                    <asp:ListItem>Nintendo 3DS</asp:ListItem>
                    <asp:ListItem>PC</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="100" class="auto-style1">
                Category</td>
            <td width="100" class="auto-style1">
                <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="odsCategory" DataTextField="category_name" DataValueField="category_id">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="100">
                Release Date</td>
            <td width="100">
            <asp:DropDownList ID="ddlReleaseMonth" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="0">-</asp:ListItem>
                        <asp:ListItem Value="1">January</asp:ListItem>
                        <asp:ListItem Value="2">February</asp:ListItem>
                        <asp:ListItem Value="3">March</asp:ListItem>
                        <asp:ListItem Value="4">April</asp:ListItem>
                        <asp:ListItem Value="5">May</asp:ListItem>
                        <asp:ListItem Value="6">June</asp:ListItem>
                        <asp:ListItem Value="7">July</asp:ListItem>
                        <asp:ListItem Value="8">August</asp:ListItem>
                        <asp:ListItem Value="9">September</asp:ListItem>
                        <asp:ListItem Value="10">October</asp:ListItem>
                        <asp:ListItem Value="11">November</asp:ListItem>
                        <asp:ListItem Value="12">December</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlReleaseDay" runat="server" AutoPostBack="True">
                   <asp:ListItem Value="0">-</asp:ListItem>
                        <asp:ListItem Text="1"></asp:ListItem>
                        <asp:ListItem Text="2"></asp:ListItem>
                        <asp:ListItem Text="3"></asp:ListItem>
                        <asp:ListItem Text="4"></asp:ListItem>
                        <asp:ListItem Text="5"></asp:ListItem>
                        <asp:ListItem Text="6"></asp:ListItem>
                        <asp:ListItem Text="7"></asp:ListItem>
                        <asp:ListItem Text="8"></asp:ListItem>
                        <asp:ListItem Text="9"></asp:ListItem>
                        <asp:ListItem Text="10"></asp:ListItem>
                        <asp:ListItem Text="11"></asp:ListItem>
                        <asp:ListItem Text="12"></asp:ListItem>
                        <asp:ListItem Text="13"></asp:ListItem>
                        <asp:ListItem Text="14"></asp:ListItem>
                        <asp:ListItem Text="15"></asp:ListItem>
                        <asp:ListItem Text="16"></asp:ListItem>
                        <asp:ListItem Text="17"></asp:ListItem>
                        <asp:ListItem Text="18"></asp:ListItem>
                        <asp:ListItem Text="19"></asp:ListItem>
                        <asp:ListItem Text="20"></asp:ListItem>
                        <asp:ListItem Text="21"></asp:ListItem>
                        <asp:ListItem Text="22"></asp:ListItem>
                        <asp:ListItem Text="23"></asp:ListItem>
                        <asp:ListItem Text="24"></asp:ListItem>
                        <asp:ListItem Text="25"></asp:ListItem>
                        <asp:ListItem Text="26"></asp:ListItem>
                        <asp:ListItem Text="27"></asp:ListItem>
                        <asp:ListItem Text="28"></asp:ListItem>
                        <asp:ListItem Text="29"></asp:ListItem>
                        <asp:ListItem Text="30"></asp:ListItem>
                        <asp:ListItem Text="31"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlReleaseYear" runat="server" AutoPostBack="True">  
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="1990"></asp:ListItem>
                        <asp:ListItem Value="1991"></asp:ListItem>
                        <asp:ListItem Value="1992"></asp:ListItem>
                        <asp:ListItem Value="1993"></asp:ListItem>
                        <asp:ListItem Value="1994"></asp:ListItem>
                        <asp:ListItem Value="1995"></asp:ListItem>
                        <asp:ListItem Value="1996"></asp:ListItem>
                        <asp:ListItem Value="1997"></asp:ListItem>
                        <asp:ListItem Value="1998"></asp:ListItem>
                        <asp:ListItem Value="1999"></asp:ListItem>
                        <asp:ListItem Value="2000"></asp:ListItem>
                        <asp:ListItem Value="2001"></asp:ListItem>
                        <asp:ListItem Value="2002"></asp:ListItem>
                        <asp:ListItem Value="2003"></asp:ListItem>
                        <asp:ListItem Value="2004"></asp:ListItem>
                        <asp:ListItem Value="2005"></asp:ListItem>
                        <asp:ListItem Value="2006"></asp:ListItem>
                        <asp:ListItem Value="2007"></asp:ListItem>
                        <asp:ListItem Value="2008"></asp:ListItem>
                        <asp:ListItem Value="2009"></asp:ListItem>
                        <asp:ListItem Value="2010"></asp:ListItem>
                        <asp:ListItem Value="2011"></asp:ListItem>
                        <asp:ListItem Value="2012"></asp:ListItem>
                        <asp:ListItem Value="2013" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="2014"></asp:ListItem>
                        <asp:ListItem Value="2015"></asp:ListItem>
                        <asp:ListItem Value="2016"></asp:ListItem>
                        <asp:ListItem Value="2017"></asp:ListItem>
                        <asp:ListItem Value="2018"></asp:ListItem>
                        <asp:ListItem Value="2019"></asp:ListItem>
                        <asp:ListItem Value="2020"></asp:ListItem>
                    </asp:DropDownList>
                &nbsp;</td>
        </tr>
        <tr>
            <td width="100">
                Price</td>
            <td width="100">
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="100">
                Game Image</td>
            <td width="100">
            <input id="BUTTON4" type="file" value="Attachment"
                    class="BandBColorVerdanaBlack10px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>

                Description</td>
            <td>

                <asp:TextBox ID="txtDecription" runat="server" Height="127px" TextMode="MultiLine" Width="322px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td width="100">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </td>
            <td width="100">
                <asp:Button ID="btnReset" runat="server" Text="Reset" />
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="odsPublisher" runat="server" SelectMethod="GetData" TypeName="CVGS_DAL.PublisherDAL_SQL"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsPlatform" runat="server" SelectMethod="GetData" TypeName="CVGS_DAL.PlatformDAL_SQL"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsESRB_Rating" runat="server" SelectMethod="GetData" TypeName="CVGS_DAL.ESRB_RatingDAL_SQL"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsGames" runat="server" InsertMethod="Insert" SelectMethod="GetData" TypeName="CVGS_DAL.ProductDAL_SQL">
        <InsertParameters>
            <asp:Parameter Name="gameTitle" Type="String" />
            <asp:Parameter Name="gamePlatformID" Type="Int32" />
            <asp:Parameter Name="publisherID" Type="Int32" />
            <asp:Parameter Name="price" Type="Decimal" />
            <asp:Parameter Name="categoryID" Type="Int32" />
            <asp:Parameter Name="ESRB_RatingID" Type="Int32" />
            <asp:Parameter Name="releaseDate" Type="DateTime" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsCategory" runat="server" SelectMethod="GetData" TypeName="CVGS_DAL.CategoryDAL_SQL"></asp:ObjectDataSource>
    <br />
</asp:Content>

