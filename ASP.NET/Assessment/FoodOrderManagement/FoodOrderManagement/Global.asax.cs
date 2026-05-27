using System;

namespace FoodOrderManagement
{
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            Application["TotalVisitors"] = 0;
            Application["ActiveUsers"] = 0;
        }

        void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();

            Application["TotalVisitors"] =
                (int)Application["TotalVisitors"] + 1;

            Application["ActiveUsers"] =
                (int)Application["ActiveUsers"] + 1;

            Application.UnLock();
        }

        void Session_End(object sender, EventArgs e)
        {
            Application.Lock();

            Application["ActiveUsers"] =
                (int)Application["ActiveUsers"] - 1;

            Application.UnLock();
        }
    }
}