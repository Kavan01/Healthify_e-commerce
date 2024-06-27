using Healthify1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace Healthify1.DAL
{
    public class Login_DALBase : DAL_Helpers
    {
        public RegistrationModel API_Login_Check (string UserName, string Password)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_Login_Check");
                sqlDatabase.AddInParameter(dbCommand, "@UserName", SqlDbType.VarChar, UserName);
                sqlDatabase.AddInParameter(dbCommand, "@Password", SqlDbType.VarChar, Password);
                RegistrationModel regModel = new RegistrationModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        regModel.UserID = Convert.ToInt32(dr["UserID"].ToString());
                        regModel.FirstName = dr["FirstName"].ToString();
                        regModel.LastName = dr["LastName"].ToString();
                        regModel.UserName = dr["UserName"].ToString();
                        regModel.Password = dr["Password"].ToString();
                        regModel.Email = dr["Email"].ToString();
                        regModel.IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
                        regModel.IsAdmin = Convert.ToBoolean(dr["IsAdmin"].ToString());
                    }
                }
                return regModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
