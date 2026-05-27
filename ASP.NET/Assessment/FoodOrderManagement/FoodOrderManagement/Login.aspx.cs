using System;

namespace FoodOrderManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" &&
                txtPassword.Text == "food@123")
            {
                Session["Username"] = txtUsername.Text;

                Session["Role"] = "Admin";

                Response.Redirect("MenuList.aspx");
            }
            else
            {
                lblMessage.Text =
                    "Invalid login. You are not authorized.";
            }
        }
    }
}
