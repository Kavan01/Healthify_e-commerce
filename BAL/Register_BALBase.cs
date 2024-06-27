using Microsoft.AspNetCore.Mvc;
using Healthify1.DAL;
using Healthify1.Models;

namespace Healthify1.BAL
{
    public class Register_BALBase
    {
        public bool API_PR_USER_INSERT(RegistrationModel RegistrationModel)
        {
            try
            {
                Register_DALBase reg_DALBase = new Register_DALBase();
                if (reg_DALBase.API_PR_USER_INSERT(RegistrationModel))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
