using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FoodOrderManagement
{
    public partial class OrderStats : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["FoodDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            lblVisitors.Text =
                "Total Visitors: " + Application["TotalVisitors"];

            lblUsers.Text =
                "Active Users: " + Application["ActiveUsers"];

            LoadCategoryStats();
        }

        void LoadCategoryStats()
        {
            DataTable dt;

            if (Cache["FoodCategoryStats"] == null)
            {
                SqlConnection con = new SqlConnection(cs);

                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Category, COUNT(*) TotalItems FROM MenuItems GROUP BY Category",
                    con);

                dt = new DataTable();

                da.Fill(dt);

                Cache.Insert(
                    "FoodCategoryStats",
                    dt,
                    null,
                    DateTime.Now.AddMinutes(5),
                    System.Web.Caching.Cache.NoSlidingExpiration);
            }
            else
            {
                dt = (DataTable)Cache["FoodCategoryStats"];
            }

            gvStats.DataSource = dt;
            gvStats.DataBind();
        }
    }
}