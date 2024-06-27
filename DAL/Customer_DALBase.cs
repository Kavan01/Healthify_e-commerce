using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Healthify1.Models;

namespace Healthify1.DAL
{
    public class Customer_DALBase : DAL_Helpers
    {
        #region API_PR_CUSTOMER_SELECT_ALL

        public List<CustomerModel> API_PR_CUSTOMER_SELECT_ALL()
        {

            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PR_CUSTOMER_SELECT_ALL");
                List<CustomerModel> custModels = new List<CustomerModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        CustomerModel custModel = new CustomerModel();
                        custModel.CustomerID = Convert.ToInt32(dr["CustomerID"].ToString());
                        custModel.CustomerName = dr["CustomerName"].ToString();
                        custModel.Email = dr["Email"].ToString();
                        custModel.Password = dr["Password"].ToString();
                        custModel.Address = dr["Address"].ToString();
                        custModel.Contact = dr["Contact"].ToString();
                        custModels.Add(custModel);
                    }
                }
                return custModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region API_PR_CUSTOMER_SELECT_BY_PK

        public CustomerModel API_PR_CUSTOMER_SELECT_BY_PK(int CustomerID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PR_CUSTOMER_SELECT_BY_PK");
                sqlDatabase.AddInParameter(dbCommand, "@CustomerID", SqlDbType.Int, CustomerID);
                CustomerModel custModel = new CustomerModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        custModel.CustomerID = Convert.ToInt32(dr["CustomerID"].ToString());
                        custModel.CustomerName = dr["CustomerName"].ToString();
                        custModel.Email = dr["Email"].ToString();
                        custModel.Password = dr["Password"].ToString();
                        custModel.Address = dr["Address"].ToString();
                        custModel.Contact = dr["Contact"].ToString();
                    }
                }
                return custModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region API_PR_CUSTOMER_DELETE

        public bool API_PR_CUSTOMER_DELETE(int CustomerID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PR_CUSTOMER_DELETE");
                sqlDatabase.AddInParameter(dbCommand, "@CustomerID", SqlDbType.Int, CustomerID);
                CustomerModel custModel = new CustomerModel();
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region API_PR_CUSTOMER_INSERT

        public bool API_PR_CUSTOMER_INSERT(CustomerModel CustomerModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PR_CUSTOMER_INSERT");
                sqlDatabase.AddInParameter(dbCommand, "@CustomerName", SqlDbType.VarChar, CustomerModel.CustomerName);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, CustomerModel.Email);
                sqlDatabase.AddInParameter(dbCommand, "@Password", SqlDbType.VarChar, CustomerModel.Password);
                sqlDatabase.AddInParameter(dbCommand, "@Address", SqlDbType.VarChar, CustomerModel.Address);
                sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.VarChar, CustomerModel.Contact);
                CustomerModel custModel = new CustomerModel();
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region API_PR_CUSTOMER_UPDATE

        public bool API_PR_CUSTOMER_UPDATE(int CustomerID, CustomerModel CustomerModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PR_CUSTOMER_UPDATE");
                sqlDatabase.AddInParameter(dbCommand, "@CustomerID", SqlDbType.Int, CustomerModel.CustomerID);
                sqlDatabase.AddInParameter(dbCommand, "@CustomerName", SqlDbType.VarChar, CustomerModel.CustomerName);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, CustomerModel.Email);
                sqlDatabase.AddInParameter(dbCommand, "@Password", SqlDbType.VarChar, CustomerModel.Password);
                sqlDatabase.AddInParameter(dbCommand, "@Address", SqlDbType.VarChar, CustomerModel.Address);
                sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.VarChar, CustomerModel.Contact);
                CustomerModel custModel = new CustomerModel();
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}