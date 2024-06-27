using Healthify1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace Healthify1.DAL
{
    public class Dashboard_DALBase : DAL_Helpers
    {
        public List<DashboardModel> PR_Healthify_Dashboard_Counts()
        {

            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_Healthify_Dashboard_Counts");
                List<DashboardModel> dashModels = new List<DashboardModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        DashboardModel dashModel = new DashboardModel();
                        dashModel.CustomerCount = Convert.ToInt32(dr["CustomerCount"].ToString());
                        dashModel.ProductCount = Convert.ToInt32(dr["ProductCount"].ToString());
                        dashModel.CategoryCount = Convert.ToInt32(dr["CategoryCount"].ToString());
                        dashModels.Add(dashModel);
                    }
                }
                return dashModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
