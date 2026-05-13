using System;
using System.Data;
using System.Data.SqlClient;
namespace EmployeeManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string conString =
                "server=ICS-LT-27W37V3\\SQLEXPRESS;database=Employeemanagement;integrated security=true";

            SqlConnection con = new SqlConnection(conString);

            try
            {
                con.Open();
                Console.WriteLine("Database Connected Successfully");
                SqlCommand cmd = new SqlCommand("sp_InsertEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                Console.Write("Enter Employee Name : ");
                string name = Console.ReadLine();
                Console.Write("Enter Employee Salary : ");
                decimal salary = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter Employee Type (F/P) : ");
                char type =  Convert.ToChar(Console.ReadLine());
                cmd.Parameters.AddWithValue("@EmpName", name);
                cmd.Parameters.AddWithValue("@Empsal", salary);
                cmd.Parameters.AddWithValue("@Emptype", type);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Employee Inserted Successfully");
                SqlCommand cmd2 =
                    new SqlCommand(
                        "SELECT * FROM Employee_Details",
                        con);

                SqlDataReader dr = cmd2.ExecuteReader();
                Console.WriteLine();
                Console.WriteLine("Employee Details");
                Console.WriteLine("--------------------------------");
                while (dr.Read())
                {
                    Console.WriteLine(
                        dr["Empno"] + "   " +
                        dr["EmpName"] + "   " +
                        dr["Empsal"] + "   " +
                        dr["Emptype"]);
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}