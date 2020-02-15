using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class viewGames : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void gvGames_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void odsGames_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CVGS_SQL"].ConnectionString;
        CVGS_DAL.Shared.Connection = new System.Data.SqlClient.SqlConnection(connectionString);
    }
    protected void gvGames_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("./viewGame.aspx?id=" + gvGames.SelectedValue);
    }
}