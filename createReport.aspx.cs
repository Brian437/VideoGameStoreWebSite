using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using CVGS_DAL;

public partial class createReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CVGS_SQL"].ConnectionString;
        CVGS_DAL.Shared.Connection = new System.Data.SqlClient.SqlConnection(connectionString);
        if (Request.QueryString["id"] != null && !IsPostBack)
        {
            ddlReportList.SelectedIndex = int.Parse(Request.QueryString["id"]);
        }
        ShowRecord();
    }
    protected void odsGames_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {

    }
    protected void gvGames_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowRecord(1);
    }
    protected void btnGetRecord_Click(object sender, EventArgs e)
    {
        ShowRecord();
    }

    private void ShowRecord()
    {
        if (ddlReportList.Text.ToUpper() == "GAME DETAIL REPORT" && gvGames.SelectedIndex == -1)
        {
            ShowRecord(0);
            MessageBox.Show("Select a game from game list first");
        }
        if (ddlReportList.Text.ToUpper() == "MEMBER DETAIL REPORT" && gvMembers.SelectedIndex == -1)
        {
            ShowRecord(2);
            MessageBox.Show("Select a member from member list first");
        }
        gvGames.Visible = ddlReportList.Text.ToUpper() == "GAME LIST REPORT";
        btnAddGame.Visible = ddlReportList.Text.ToUpper() == "GAME LIST REPORT";
        dvGames.Visible = ddlReportList.Text.ToUpper() == "GAME DETAIL REPORT";
        btnBackToGameGride.Visible = ddlReportList.Text.ToUpper() == "GAME DETAIL REPORT";
        btnEditGame.Visible = ddlReportList.Text.ToUpper() == "GAME DETAIL REPORT";
        btnGameDelete.Visible = ddlReportList.Text.ToUpper() == "GAME DETAIL REPORT";
        gvMembers.Visible = ddlReportList.Text.ToUpper() == "MEMBER LIST REPORT";
        dvMember.Visible = ddlReportList.Text.ToUpper() == "MEMBER DETAIL REPORT";
        btnBackToMemberGrid.Visible = ddlReportList.Text.ToUpper() == "MEMBER DETAIL REPORT";
        gvNewReviews.Visible = ddlReportList.Text.ToUpper() == "NEW REVIEWS";
        gvAllReviews.Visible = ddlReportList.Text.ToUpper() == "ALL REVIEWS";

    }

    private void ShowRecord(int index)
    {
        ddlReportList.SelectedIndex = index;
        ShowRecord();
    }

    protected void gvMembers_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowRecord(3);
    }
    protected void btnBackToGameGride_Click(object sender, EventArgs e)
    {
        ShowRecord(0);
    }
    protected void btnBackToMemberGrid_Click(object sender, EventArgs e)
    {
        ShowRecord(2);
    }
    protected void ddlReportList_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowRecord();
        DateTime dateTime = new DateTime();
    }
    protected void btnEditGame_Click(object sender, EventArgs e)
    {
        Response.Redirect("./editGame.aspx?id=" + gvGames.SelectedValue);
    }
    protected void gvGames_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }
    private void DeleteGame()
    {
    }
    protected void btnGameDelete_Click(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show("Are you sure you want to delete this?", "Delete", MessageBoxButtons.YesNo);
        if(result==DialogResult.Yes)
        {
            try
            {
                ProductDAL_SQL productDAL = new ProductDAL_SQL();
                productDAL.Delete((int)gvGames.SelectedValue);
                gvGames.SelectedIndex = -1;
                MessageBox.Show("game Deleted");
                ShowRecord(0);
            }
            catch
            {
                MessageBox.Show("failed to delete game");
            }
        }
    }
    protected void btnAddGame_Click(object sender, EventArgs e)
    {
        Response.Redirect("./addGame.aspx");
    }
    protected void gvNewReviews_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("./review.aspx?id=" + gvNewReviews.SelectedValue+"&report_index=6");
    }
    protected void gvAllReviews_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("./review.aspx?id=" + gvAllReviews.SelectedValue+"&report_index=7");
    }
}