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
    public interface iAddressDAL
    {
        void Insert(
            string address,
            string city,
            string provinceState,
            string country,
            string postalZIP_Code);
        void Update(
            int addressID,
            string address,
            string city,
            string provinceState,
            string country,
            string postalZIP_Code);
        void Delete(int addressID);
        DataTable GetData();
        DataTable GetData(int addressID);
    }
}
