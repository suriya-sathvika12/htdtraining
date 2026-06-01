using System;
using System.Data.SqlClient;
class RailwayApp
{
    static string connStr = "Server=ICS-LT-27W37V3\\SQLEXPRESS;Database=RailwaySystemDB;Trusted_Connection=True;";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1.Admin\n2.User\n3.Exit");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1) AdminLogin();
            else if (choice == 2) UserAuth();
            else break;
        }
    }

    //ADMIN LOGIN
    static void AdminLogin()
    {
        Console.Write("Username: ");
        string u = Console.ReadLine();

        Console.Write("Password: ");
        string p = Console.ReadLine();

        if (u == "admin" && p == "1234")
            AdminMenu();
        else
            Console.WriteLine("Invalid Admin");
    }

    //USER AUTH
    static void UserAuth()
    {
        Console.WriteLine("1.Login\n2.Register");
        int ch = int.Parse(Console.ReadLine());

        if (ch == 1) UserLogin();
        else RegisterUser();
    }

    static void RegisterUser()
    {
        SqlConnection con = new SqlConnection(connStr);

        Console.Write("Username: ");
        string u = Console.ReadLine();

        Console.Write("Password: ");
        string p = Console.ReadLine();

        con.Open();
        SqlCommand cmd = new SqlCommand(
        "INSERT INTO UserAccounts VALUES(@u,@p)", con);

        cmd.Parameters.AddWithValue("@u", u);
        cmd.Parameters.AddWithValue("@p", p);

        cmd.ExecuteNonQuery();
        con.Close();

        Console.WriteLine("User Registered");
    }

    static void UserLogin()
    {
        SqlConnection con = new SqlConnection(connStr);

        Console.Write("Username: ");
        string u = Console.ReadLine();

        Console.Write("Password: ");
        string p = Console.ReadLine();

        con.Open();

        SqlCommand cmd = new SqlCommand(
        "SELECT COUNT(*) FROM UserAccounts WHERE UserName=@u AND UserPassword=@p", con);

        cmd.Parameters.AddWithValue("@u", u);
        cmd.Parameters.AddWithValue("@p", p);

        int count = (int)cmd.ExecuteScalar();
        con.Close();

        if (count > 0) UserMenu();
        else Console.WriteLine("Invalid Login");
    }

    //MENUS
    static void AdminMenu()
    {
        while (true)
        {
            Console.WriteLine("\n1.Add Train\n2.Delete Train\n3.Cancel Train\n4.View Trains\n5.Back");

            int ch = int.Parse(Console.ReadLine());

            if (ch == 1) AddTrain();
            else if (ch == 2) DeleteTrain();
            else if (ch == 3) CancelTrain();
            else if (ch == 4) ViewTrains();
            else break;
        }
    }

    static void UserMenu()
    {
        while (true)
        {
            Console.WriteLine("\n1.Search Trains\n2.Book Ticket\n3.Cancel Ticket\n4.Back");

            int ch = int.Parse(Console.ReadLine());

            if (ch == 1) SearchTrains();
            else if (ch == 2) BookTicket();
            else if (ch == 3) CancelTicket();
            else break;
        }
    }

    // ADD TRAIN
    static void AddTrain()
    {
        SqlConnection con = new SqlConnection(connStr);

        Console.Write("Train ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Train Name: ");
        string name = Console.ReadLine();

        Console.Write("Source: ");
        string src = Console.ReadLine();

        Console.Write("Destination: ");
        string dest = Console.ReadLine();

        Console.Write("Time (HH:mm): ");
        TimeSpan time = TimeSpan.Parse(Console.ReadLine());

        Console.Write("Sleeper Seats: ");
        int s = int.Parse(Console.ReadLine());

        Console.Write("AC2 Seats: ");
        int a2 = int.Parse(Console.ReadLine());

        Console.Write("AC3 Seats: ");
        int a3 = int.Parse(Console.ReadLine());

        Console.Write("Sleeper Fare: ");
        decimal sf = decimal.Parse(Console.ReadLine());

        Console.Write("AC2 Fare: ");
        decimal a2f = decimal.Parse(Console.ReadLine());

        Console.Write("AC3 Fare: ");
        decimal a3f = decimal.Parse(Console.ReadLine());

        SqlCommand cmd = new SqlCommand(
        @"INSERT INTO TrainMaster
        (TrainID, TrainName, SourceStation, DestinationStation, DepartureTime,
        SleeperSeats, AC2Seats, AC3Seats, SleeperFare, AC2Fare, AC3Fare, IsRemoved)
        VALUES
        (@id,@name,@src,@dest,@time,@s,@a2,@a3,@sf,@a2f,@a3f,0)", con);

        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@src", src);
        cmd.Parameters.AddWithValue("@dest", dest);
        cmd.Parameters.AddWithValue("@time", time);
        cmd.Parameters.AddWithValue("@s", s);
        cmd.Parameters.AddWithValue("@a2", a2);
        cmd.Parameters.AddWithValue("@a3", a3);
        cmd.Parameters.AddWithValue("@sf", sf);
        cmd.Parameters.AddWithValue("@a2f", a2f);
        cmd.Parameters.AddWithValue("@a3f", a3f);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();

        Console.WriteLine("Train Added");
    }

    //SEARCH TRAINS 
    static void SearchTrains()
    {
        SqlConnection con = new SqlConnection(connStr);

        Console.Write("Source: ");
        string src = Console.ReadLine();

        Console.Write("Destination: ");
        string dest = Console.ReadLine();

        con.Open();

        SqlCommand cmd = new SqlCommand(
        "SELECT * FROM TrainMaster WHERE SourceStation=@s AND DestinationStation=@d AND IsRemoved=0",
        con);

        cmd.Parameters.AddWithValue("@s", src);
        cmd.Parameters.AddWithValue("@d", dest);

        var dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            Console.WriteLine($"{dr["TrainID"]} | {dr["TrainName"]} | {dr["DepartureTime"]}");
        }

        con.Close();
    }

    //BOOK
    static void BookTicket()
    {
        SqlConnection con = new SqlConnection(connStr);

        Console.Write("Train ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Journey Date: ");
        DateTime jdate = DateTime.Parse(Console.ReadLine());

        Console.Write("Class (Sleeper/2AC/3AC): ");
        string cls = Console.ReadLine();

        Console.Write("Passengers (max 3): ");
        int p = int.Parse(Console.ReadLine());

        decimal amount = p * 100; 

        con.Open();

        SqlCommand cmd = new SqlCommand(
        "INSERT INTO TicketBookings(JourneyDate,TrainID,ClassType,TotalPassengers,TotalAmount) VALUES(@d,@id,@c,@p,@a)",
        con);

        cmd.Parameters.AddWithValue("@d", jdate);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@c", cls);
        cmd.Parameters.AddWithValue("@p", p);
        cmd.Parameters.AddWithValue("@a", amount);

        cmd.ExecuteNonQuery();
        con.Close();

        Console.WriteLine("Ticket Booked");
    }

    //CANCEL
    static void CancelTicket()
    {
        SqlConnection con = new SqlConnection(connStr);

        Console.Write("Booking ID: ");
        int id = int.Parse(Console.ReadLine());

        con.Open();

        SqlCommand cmd = new SqlCommand(
        "INSERT INTO TicketCancellation(BookingID,RefundAmount) VALUES(@id,100)", con);

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();

        con.Close();

        Console.WriteLine("Ticket Cancelled");
    }

    //VIEW
    static void ViewTrains()
    {
        SqlConnection con = new SqlConnection(connStr);

        con.Open();

        var dr = new SqlCommand(
        "SELECT * FROM TrainMaster WHERE IsRemoved=0", con)
        .ExecuteReader();

        while (dr.Read())
        {
            Console.WriteLine($"{dr["TrainID"]} | {dr["TrainName"]} | {dr["SourceStation"]} -> {dr["DestinationStation"]}");
        }

        con.Close();
    }

    //DELETE 
    static void DeleteTrain()
    {
        SqlConnection con = new SqlConnection(connStr);

        Console.Write("Train ID: ");
        int id = int.Parse(Console.ReadLine());

        con.Open();

        new SqlCommand(
        "UPDATE TrainMaster SET IsRemoved=1 WHERE TrainID=@id", con)
        { Parameters = { new SqlParameter("@id", id) } }
        .ExecuteNonQuery();

        con.Close();
        Console.WriteLine("Train Deleted");
    }

    //CANCEL TRAIN
    static void CancelTrain()
    {
        SqlConnection con = new SqlConnection(connStr);

        Console.Write("Train ID: ");
        int id = int.Parse(Console.ReadLine());

        con.Open();

        new SqlCommand(
        "UPDATE TrainMaster SET SleeperSeats=0,AC2Seats=0,AC3Seats=0 WHERE TrainID=@id",
        con)
        { Parameters = { new SqlParameter("@id", id) } }
        .ExecuteNonQuery();

        con.Close();

        Console.WriteLine("Train Cancelled");
    }
}