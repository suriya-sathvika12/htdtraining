using System;
using System.Configuration;
using System.Data.SqlClient;

namespace FoodOrderManagement
{
    public partial class AddEditMenu : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["FoodDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["MenuId"] != null)
                {
                    GetMenuById();
                }
            }
        }

        void GetMenuById()
        {
            int id = Convert.ToInt32(Request.QueryString["MenuId"]);

            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd =
                new SqlCommand("SELECT * FROM MenuItems WHERE MenuId=@id", con);

            cmd.Parameters.AddWithValue("@id", id);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtItemName.Text = dr["ItemName"].ToString();
                txtCategory.Text = dr["Category"].ToString();
                ddlFoodType.Text = dr["FoodType"].ToString();
                txtPrice.Text = dr["Price"].ToString();
                txtQty.Text = dr["AvailableQuantity"].ToString();
                chkAvailable.Checked = Convert.ToBoolean(dr["IsAvailable"]);
            }

            con.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd;

            if (Request.QueryString["MenuId"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["MenuId"]);

                cmd = new SqlCommand(
                "UPDATE MenuItems SET ItemName=@name,Category=@cat,FoodType=@ftype,Price=@price,AvailableQuantity=@qty,IsAvailable=@avail WHERE MenuId=@id",
                con);

                cmd.Parameters.AddWithValue("@id", id);
            }
            else
            {
                cmd = new SqlCommand(
                "INSERT INTO MenuItems VALUES(@name,@cat,@ftype,@price,@qty,@avail,GETDATE())",
                con);
            }

            cmd.Parameters.AddWithValue("@name", txtItemName.Text);
            cmd.Parameters.AddWithValue("@cat", txtCategory.Text);
            cmd.Parameters.AddWithValue("@ftype", ddlFoodType.Text);
            cmd.Parameters.AddWithValue("@price", txtPrice.Text);
            cmd.Parameters.AddWithValue("@qty", txtQty.Text);
            cmd.Parameters.AddWithValue("@avail", chkAvailable.Checked);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Redirect("MenuList.aspx");
        }
    }
}