/*
 * Brian Chaves
 * December 7,2013
 * DALs
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVGS_DAL
{
    public interface iPublisherDAL
    {
        void Insert(
            string company_Name,
            string company_Contact,
            string phone,
            string email);
        void Update(
            int publisher_ID,
            string company_Name,
            string company_Contact,
            string phone,
            string email);
        void Delete(int publisherID);
        DataTable GetData();
        DataTable GetData(int publisherID);
    }
}
