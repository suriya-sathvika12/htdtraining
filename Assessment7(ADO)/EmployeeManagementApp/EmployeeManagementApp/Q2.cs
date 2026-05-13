using System;
using System.Data;
using System.Data.SqlClient;
namespace EmployeeManagementApp
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            string conString = "server=ICS-LT-27W37V3\\SQLEXPRESS;database=Employeemanagement;integrated security=true";
            SqlConnection con = new SqlConnection(conString);
            try
            {
                con.Open();
                Console.WriteLine("Database Connected Successfully");
                SqlCommand cmd = new SqlCommand("sp_UpdateSalary", con);
                cmd.CommandType =  CommandType.StoredProcedure;
                Console.Write("Enter Employee ID : ");
                int empid = Convert.ToInt32(Console.ReadLine());
                cmd.Parameters.AddWithValue("@Empid", empid);
                SqlParameter outputParam =
                    new SqlParameter(
                        "@UpdatedSalary",
                        SqlDbType.Decimal);
                outputParam.Direction = ParameterDirection.Output;
                outputParam.Precision = 10;
                outputParam.Scale = 2;
                cmd.Parameters.Add(outputParam);
                cmd.ExecuteNonQuery();
                Console.WriteLine();
                Console.WriteLine(
                    "Updated Salary : " +
                    outputParam.Value);
                SqlCommand cmd2 =
                    new SqlCommand(
                        "SELECT * FROM Employee_Details WHERE Empno=@id",
                        con);
                cmd2.Parameters.AddWithValue("@id", empid);
                SqlDataReader dr =
                    cmd2.ExecuteReader();
                Console.WriteLine();
                Console.WriteLine("Updated Employee Record");
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