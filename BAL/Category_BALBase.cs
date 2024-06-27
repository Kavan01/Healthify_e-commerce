using Microsoft.AspNetCore.Mvc;
using Healthify1.DAL;
using Healthify1.Models;

namespace Healthify1.BAL
{
    public class Category_BALBase
    {
        #region API_PR_CATEGORY_SELECT_ALL
        public List<CategoryModel> API_PR_CATEGORY_SELECT_ALL()
        {
            try
            {
                Category_DALBase cat_DALBase = new Category_DALBase();
                List<CategoryModel> catModels = cat_DALBase.API_PR_CATEGORY_SELECT_ALL();
                return catModels;
            }
            catch
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
                Category_DALBase cat_DALBase = new Category_DALBase();
                CategoryModel catModels = cat_DALBase.API_PR_CATEGORY_SELECT_BY_PK(CategoryID);
                return catModels;
            }
            catch
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
                Category_DALBase cat_DALBase = new Category_DALBase();
                if (cat_DALBase.API_PR_CATEGORY_DELETE(CategoryID))
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
                Category_DALBase cat_DALBase = new Category_DALBase();
                if (cat_DALBase.API_PR_CATEGORY_INSERT(CategoryModel))
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
                Category_DALBase cat_DALBase = new Category_DALBase();
                if (cat_DALBase.API_PR_CATEGORY_UPDATE(CategoryID, CategoryModel))
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
