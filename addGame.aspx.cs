using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CVGS_DAL;
using System.Windows.Forms;
using CVGS_FunctionAssembley;

public partial class addGame : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CVGS_SQL"].ConnectionString;
        CVGS_DAL.Shared.Connection = new System.Data.SqlClient.SqlConnection(connectionString);

    }

    private bool Valadate(out string errorMessage)
    {
        //bool valid = true;
        errorMessage = "";

        if (txtGameTitle.Text.Length < CVGS_Shared.MINIMUM_STRING_LENGTH)
        {
            errorMessage += "Game Title must be at least " + CVGS_Shared.MINIMUM_STRING_LENGTH + " in length\r\n";
        }

        if (!CVGS_Function.IsNumber(txtPrice.Text)) 
        {
            errorMessage += "Price must be a number";
        }

        return errorMessage == "";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string errorMessage;
        if (Valadate(out errorMessage))
        {
            try
            {

                DateTime releaseDate;
                try
                {
                    releaseDate = new DateTime(
                    int.Parse(ddlReleaseYear.Text),
                    int.Parse(ddlReleaseMonth.SelectedValue),
                    int.Parse(ddlReleaseDay.Text));
                }
                catch
                {
                    releaseDate = new DateTime();
                }
                CVGS_DAL.ProductDAL_SQL productDAL_SQL = new CVGS_DAL.ProductDAL_SQL();
                productDAL_SQL.Insert(
                    CVGS_Function.sqlEscape(txtGameTitle.Text),
                    int.Parse(ddlPlatform.SelectedValue),
                    int.Parse(ddlPublisher.SelectedValue),
                    decimal.Parse(txtPrice.Text.ToString()),
                    int.Parse(ddlCategory.SelectedValue),
                    int.Parse(ddlRating.SelectedValue),
                    releaseDate,
                    "");
                MessageBox.Show("Game Added");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Failed to add game\r\n" + exception.Message);
            }
        }
        else
        {
            MessageBox.Show(errorMessage);
        }

    }
}