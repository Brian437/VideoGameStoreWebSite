using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class review : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        CVGS_DAL.ProductReviewDAL_SQL productReview = new CVGS_DAL.ProductReviewDAL_SQL();
        productReview.Approve(int.Parse(Request.QueryString["id"]));
        Response.Redirect("./createReport.aspx?id=" + Request.QueryString["report_index"]);
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {
        CVGS_DAL.ProductReviewDAL_SQL productReview = new CVGS_DAL.ProductReviewDAL_SQL();
        productReview.Delete(int.Parse(Request.QueryString["id"]));
        Response.Redirect("./createReport.aspx?id="+Request.QueryString["report_index"]);
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("./createReport.aspx?id=" + Request.QueryString["report_index"]);
    }
}