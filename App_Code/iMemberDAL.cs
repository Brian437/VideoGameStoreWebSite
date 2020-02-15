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
    public interface iMemberDAL
    {
        void Inseret(
            string firstName,
            string lastName,
            string userName,
            string phone,
            string email,
            string memberType,
            bool isLocked,
            int passwordAttemptCount,
            bool promotionalEmails,
            DateTime lastLoginAttempt);
        void Update(
            int memberID,
            string firstName,
            string lastName,
            string userName,
            string phone,
            string email,
            string memberType,
            bool isLocked,
            int passwordAttemptCount,
            bool promotionalEmails,
            DateTime lastLoginAttempt);
        void Delete(int memberID);
        DataTable GetData();
        DataTable GetData(int memberID);
        DataTable GetData(string username);
    }
}
