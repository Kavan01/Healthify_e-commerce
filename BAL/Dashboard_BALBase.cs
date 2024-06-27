using Healthify1.DAL;
using Healthify1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Healthify1.Controllers
{
    public class Dashboard_BALBase
    {
        public List<DashboardModel> PR_Healthify_Dashboard_Counts()
        {
            try
            {
                Dashboard_DALBase dash_DALBase = new Dashboard_DALBase();
                List<DashboardModel> dashModels = dash_DALBase.PR_Healthify_Dashboard_Counts();
                return dashModels;
            }
            catch
            {
                return null;
            }
        }
    }
}