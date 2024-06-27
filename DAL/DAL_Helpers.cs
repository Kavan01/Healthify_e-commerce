using Microsoft.AspNetCore.Mvc;

namespace Healthify1.DAL
{
    public class DAL_Helpers
    {
        public static string ConnString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build
            ().GetConnectionString("Mystring");
    }
}