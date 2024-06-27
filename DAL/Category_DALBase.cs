using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using Healthify1.Models;

namespace Healthify1.DAL
{
    public class Category_DALBase : DAL_Helpers
    {
        #region API_PR_CATEGORY_SELECT_ALL

        public List<CategoryModel> API_PR_CATEGORY_SELECT_ALL()
        {

            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PR_CATEGORY_SELECT_ALL");
                List<CategoryModel> catModels = new List<CategoryModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        CategoryModel catModel = new CategoryModel();
                        catModel.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());
                        catModel.CategoryName = dr["CategoryName"].ToString();
                        catModels.Add(catModel);
                    }
                }
                return catModels;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region API_PR_CATEGORY_SELECT_BY_PK

        public CategoryModel API_PR_CATEGORY_SELECT_BY_PK(int CategoryID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PR_CATEGORY_SELECT_BY_PK");
                sqlDatabase.AddInParameter(dbCommand, "@CategoryID", SqlDbType.Int, CategoryID);
                CategoryModel catModel = new CategoryModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        catModel.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());
                        catModel.CategoryName = dr["CategoryName"].ToString();

                    }
                }
                return catModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region API_PR_CATEGORY_DELETE

        public bool API_PR_CATEGORY_DELETE(int CategoryID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PR_CATEGORY_DELETE");
                sqlDatabase.AddInParameter(dbCommand, "@CategoryID", SqlDbType.Int, CategoryID);
                CategoryModel catModel = new CategoryModel();
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

        #region API_PR_CATEGORY_INSERT

        public bool API_PR_CATEGORY_INSERT(CategoryModel CategoryModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PR_CATEGORY_INSERT");
                sqlDatabase.AddInParameter(dbCommand, "@CategoryName", SqlDbType.VarChar, CategoryModel.CategoryName);
                CategoryModel catModel = new CategoryModel();
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

        #region API_PR_CATEGORY_UPDATE

        public bool API_PR_CATEGORY_UPDATE(int CategoryID, CategoryModel CategoryModel)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("API_PR_CATEGORY_UPDATE");
                sqlDatabase.AddInParameter(dbCommand, "@CategoryID", SqlDbType.Int, CategoryModel.CategoryID);
                sqlDatabase.AddInParameter(dbCommand, "@CategoryName", SqlDbType.VarChar, CategoryModel.CategoryName);
                CategoryModel catModel = new CategoryModel();
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