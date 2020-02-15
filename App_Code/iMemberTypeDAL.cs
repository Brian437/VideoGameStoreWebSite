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
    public interface iMemberTypeDAL
    {
        void Insert(string positionName);
        void Update(int positionID,string positionName);
        void Delete(int positionID);
        DataTable GetData();
        DataTable GetData(int PositionID);
    }
}
