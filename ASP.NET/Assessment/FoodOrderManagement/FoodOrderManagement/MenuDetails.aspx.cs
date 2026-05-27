using System;
using System.Configuration;
using System.Data.SqlClient;

namespace FoodOrderManagement
{
    public partial class MenuDetails : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["FoodDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            int id = Convert.ToInt32(Request.QueryString["MenuId"]);

            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd =
                new SqlCommand("SELECT * FROM MenuItems WHERE MenuId=@id", con);

            cmd.Parameters.AddWithValue("@id", id);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Response.Write("<h2>Menu Details</h2>");
                Response.Write("Item Name: " + dr["ItemName"] + "<br/>");
                Response.Write("Category: " + dr["Category"] + "<br/>");
                Response.Write("Price: " + dr["Price"] + "<br/>");
            }

            con.Close();
        }
    }
}