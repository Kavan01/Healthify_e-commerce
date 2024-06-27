using Healthify1.DAL;
using Healthify1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Healthify1.BAL
{
    public class Login_BALBase
    {
        public RegistrationModel API_Login_Check(string UserName, string Password)
        {
            try
            {
                Login_DALBase login_DALBase = new Login_DALBase();
                RegistrationModel loginModels = login_DALBase.API_Login_Check(UserName, Password);
                return loginModels;
            }
            catch
            {
                return null;
            }
        }
    }
}
