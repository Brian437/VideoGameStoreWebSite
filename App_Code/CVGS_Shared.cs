using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CVGS_Shared
/// </summary>
public static class CVGS_Shared
{
    public static void StartUp()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CVGS_SQL"].ConnectionString;
        CVGS_DAL.Shared.Connection = new System.Data.SqlClient.SqlConnection(connectionString);
    }
    public const int MINIMUM_STRING_LENGTH = 2;
}