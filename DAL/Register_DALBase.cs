using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Healthify1.Models;

namespace Healthify1.DAL
{
    public class Register_DALBase : DAL_Helpers
    {
        public bool API_PR_USER_INSERT(RegistrationModel RegistrationModel)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConnString);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_PR_USER_INSERT");
                sqldb.AddInParameter(cmd, "@FirstName", SqlDbType.VarChar, RegistrationModel.FirstName);
                sqldb.AddInParameter(cmd, "@LastName", SqlDbType.VarChar, RegistrationModel.LastName);
                sqldb.AddInParameter(cmd, "@UserName", SqlDbType.VarChar, RegistrationModel.UserName);
                sqldb.AddInParameter(cmd, "@Password", SqlDbType.VarChar, RegistrationModel.Password);
                sqldb.AddInParameter(cmd, "@Email", SqlDbType.VarChar, RegistrationModel.Email);
                sqldb.AddInParameter(cmd, "@IsActive", SqlDbType.Bit, RegistrationModel.IsActive);
                sqldb.AddInParameter(cmd, "@IsAdmin", SqlDbType.Bit, RegistrationModel.IsAdmin);

                if (Convert.ToBoolean(sqldb.ExecuteNonQuery(cmd)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
    }
}