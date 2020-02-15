using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class WriteReview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CVGS_SQL"].ConnectionString;
        CVGS_DAL.Shared.Connection = new System.Data.SqlClient.SqlConnection(connectionString);
    }
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("./viewGame.aspx?id="+Request.QueryString["id"]);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        CVGS_DAL.ProductReviewDAL_SQL productReview = new CVGS_DAL.ProductReviewDAL_SQL();
        bool reviewAddedSuccess = false;

        try
        {
            productReview.Insert(
                txtReview.Text,
                false,
                int.Parse(ddlMember.SelectedValue),
                int.Parse(Request.QueryString["id"]));
            reviewAddedSuccess = true;
        }
        catch(Exception exception)
        {
            MessageBox.Show("Failed to write review \r\n" + exception.Message);
            reviewAddedSuccess = false;
        }

        if (reviewAddedSuccess)
        {
            MessageBox.Show("Review sent");
            Response.Redirect("viewGame.aspx?id="+Request.QueryString["id"]);
        }
    }
}