using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CVGS_DAL;
using System.Windows.Forms;
using System.Data;
using CVGS_FunctionAssembley;

public partial class addGame : System.Web.UI.Page
{
    DataTable productData;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bool nullReleaseDate;
            string connectionString = ConfigurationManager.ConnectionStrings["CVGS_SQL"].ConnectionString;
            CVGS_DAL.Shared.Connection = new System.Data.SqlClient.SqlConnection(connectionString);

            ProductDAL_SQL productDAL = new ProductDAL_SQL();
            productData = productDAL.GetData(int.Parse(Request.QueryString["id"]));
            txtGameTitle.Text = productData.Rows[0]["product_name"].ToString();
            ddlPublisher.SelectedValue = productData.Rows[0]["publisher_id"].ToString();
            ddlRating.SelectedValue = productData.Rows[0]["esrbRating_Id"].ToString();
            ddlPlatform.SelectedValue = productData.Rows[0]["platform_id"].ToString();
            ddlCategory.SelectedValue = productData.Rows[0]["category_id"].ToString();
            txtPrice.Text = productData.Rows[0]["price"].ToString();
            txtPrice.Text = txtPrice.Text.Substring(0, txtPrice.Text.Length - 2);
            DateTime releaseDate;
            try
            {
                releaseDate = (DateTime)productData.Rows[0]["release_date"];
                nullReleaseDate = false;
            }
            catch
            {
                releaseDate = new DateTime();
                nullReleaseDate = true;
            }

            if (!nullReleaseDate)
            {
                ddlReleaseYear.SelectedValue = releaseDate.Year.ToString();
                ddlReleaseDay.SelectedValue = releaseDate.Day.ToString();
                ddlReleaseMonth.SelectedValue = releaseDate.Month.ToString();
            }
        }

    }

    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("./createReport.aspx");
    }

    private bool Validate(out string errorMessage)
    {
        errorMessage = "";
        if (txtGameTitle.Text.Length < CVGS_Shared.MINIMUM_STRING_LENGTH)
        {
            errorMessage += "Game Title must be at least " + CVGS_Shared.MINIMUM_STRING_LENGTH + " in length\r\n";
        }

        if(!CVGS_Function.IsNumber(txtPrice.Text))
        {
            errorMessage+="Price must be a number";
        }
        return errorMessage == "";
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        bool updateSuccessful = false;
        try
        {
            DateTime releaseDate ;
            try
            {
                releaseDate = new DateTime(
                    int.Parse(ddlReleaseYear.Text),
                    int.Parse(ddlReleaseMonth.Text),
                    int.Parse(ddlReleaseDay.Text));
            }
            catch
            {
                releaseDate = new DateTime();
            }
            CVGS_DAL.ProductDAL_SQL productDAL = new CVGS_DAL.ProductDAL_SQL();
            productDAL.Update(
                int.Parse(Request.QueryString["id"]),
                CVGS_Function.sqlEscape(txtGameTitle.Text),
                int.Parse(ddlPlatform.SelectedValue),
                int.Parse(ddlPublisher.SelectedValue),
                decimal.Parse(txtPrice.Text),
                int.Parse(ddlCategory.SelectedValue),
                int.Parse(ddlRating.SelectedValue),
                releaseDate,
                txtDecription.Text);
            updateSuccessful = true;
        }
        catch (Exception exception)
        {
            MessageBox.Show("Failed to update Game \r\n" + exception.Message);
        }
        if (updateSuccessful)
        {
            MessageBox.Show("Update Successful");
            Response.Redirect("./createReport.aspx");
        }
    }
}