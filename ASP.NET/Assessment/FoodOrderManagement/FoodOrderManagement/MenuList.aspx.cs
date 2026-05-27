using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FoodOrderManagement
{
    public partial class MenuList : System.Web.UI.Page
    {
        SqlConnection con =
            new SqlConnection(
            ConfigurationManager.ConnectionStrings["FoodDB"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            SqlDataAdapter da =
                new SqlDataAdapter(
                "SELECT * FROM MenuItems", con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            GridView1.DataSource = dt;

            GridView1.DataBind();
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            string id =
                ((System.Web.UI.WebControls.LinkButton)sender)
                .CommandArgument;

            SqlCommand cmd =
                new SqlCommand(
                "DELETE FROM MenuItems WHERE MenuId=@MenuId",
                con);

            cmd.Parameters.AddWithValue("@MenuId", id);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            LoadData();
        }
    }
}