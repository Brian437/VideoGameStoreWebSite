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
    public interface iMemberAddressDAL
    {
        void Insert(int memberID,int addressID, int addressTypeID);
        void Update(int memberID, int addressID, int addressTypeID);
        void Delete(int memberID, int addressID);
        DataTable GetData();
        DataTable GetData(int memberID, int addressID);
    }
}
