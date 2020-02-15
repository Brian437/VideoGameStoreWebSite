using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viewGame : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CVGS_SQL"].ConnectionString;
        CVGS_DAL.Shared.Connection = new System.Data.SqlClient.SqlConnection(connectionString);
    }
    protected void btnRateGame_Click(object sender, EventArgs e)
    {
        CVGS_DAL.ProductRatingDAL_SQL productRating = new CVGS_DAL.ProductRatingDAL_SQL();

        productRating.Delete(
            int.Parse(ddlMember.SelectedValue),
            int.Parse(Request.QueryString["id"]));

        productRating.Insert(
            int.Parse(ddlMember.SelectedValue),
            int.Parse(Request.QueryString["id"]),
            int.Parse(ddlRateGame.SelectedValue));

        Response.Redirect(Request.RawUrl);
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("searchGames.aspx");
    }
    protected void btnWriteReview_Click(object sender, EventArgs e)
    {
        Response.Redirect("writeReview.aspx?id=" + Request.QueryString["id"]);
    }
}