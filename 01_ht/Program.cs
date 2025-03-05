using System;
using System.Data.SqlClient;

internal class Program
{
    static string conn_ = @"Data Source = DESKTOP-F5EBSVM\SQLEXPRESS; Initial Catalog = Hospital; Integrated Security=True; Connect Timeout = 2";

    static void GetDepartmentPlaces(string departmentName)
    {
        SqlConnection conn = new SqlConnection(conn_);
        conn.Open();
        string query = $"select sum(Places) from Wards where DepartmentId = (select Id from Departments where Name = '{departmentName}')";
        SqlCommand com = new SqlCommand(query, conn);
        object result = com.ExecuteScalar();
        Console.WriteLine($"Seats in the department {departmentName}: {result}");
        conn.Close();
    }

    static void GetAllExaminations()
    {
        SqlConnection conn = new SqlConnection(conn_);
        conn.Open();
        string query = "select Name from Examinations";
        SqlCommand command = new SqlCommand(query, conn);
        SqlDataReader reader = command.ExecuteReader();
        Console.WriteLine("Examination list:");
        while (reader.Read())
        {
            Console.WriteLine(reader[0]);
        }
        reader.Close();
        conn.Close();
    }

    static void DeleteOldExaminations(string date)
    {
        SqlConnection conn = new SqlConnection(conn_);
        conn.Open();
        string query = $"delete from DoctorsExaminations where StartTime < '{date}'";
        SqlCommand command = new SqlCommand(query, conn);
        int res = command.ExecuteNonQuery();
        Console.WriteLine($"Deleted {res} old examinations");
        conn.Close();
    }

    static void GetDoctorsBySalary(double minSalary)
    {
        SqlConnection conn = new SqlConnection(conn_);
        conn.Open();
        string query = $"select Name, Surname, Salary from Doctors where Salary > {minSalary}";
        SqlCommand command = new SqlCommand(query, conn);
        SqlDataReader reader = command.ExecuteReader();
        Console.WriteLine("Doctors with salaryes bigger than  " + minSalary + ":");
        while (reader.Read())
        {
            Console.WriteLine($"{reader[0]} {reader[1]} - {reader[2]}");
        }
        reader.Close();
        conn.Close();
    }

    static void GetLargestDonation()
    {
        SqlConnection conn = new SqlConnection(conn_);
        conn.Open();
        string query = "select max(Amount) from Donations";
        SqlCommand command = new SqlCommand(query, conn);
        object res = command.ExecuteScalar();
        Console.WriteLine($"The biggest donation: {res}");
        conn.Close();
    }

    static void AddExamination(string name)
    {
        SqlConnection conn = new SqlConnection(conn_);
        conn.Open();
        string query = $"insert into Examinations (Name) values ('{name}')";
        SqlCommand command = new SqlCommand(query, conn);
        int res = command.ExecuteNonQuery();
        Console.WriteLine($"Added new examination: {name}");
        conn.Close();
    }

    static void DeleteInactiveSponsors()
    {
        SqlConnection conn = new SqlConnection(conn_);
        conn.Open();
        string query = "delete from Sponsors where Id not in ( select SponsorId from Donations)";
        SqlCommand command = new SqlCommand(query, conn);
        int res = command.ExecuteNonQuery();
        Console.WriteLine($"deltes {res} sponsors without donations");
        conn.Close();
    }
    private static void Main(string[] args)
    {
        Console.Write("Enter the name of department: ");
        string department = Console.ReadLine();
        GetDepartmentPlaces(department);

        GetAllExaminations();

        Console.Write("Enter date to which to remove examination: ");
        string date = Console.ReadLine();
        DeleteOldExaminations(date);

        Console.Write("Enter min salary: ");
        double minSalary = double.Parse(Console.ReadLine());
        GetDoctorsBySalary(minSalary);

        GetLargestDonation();

        Console.Write("Enter name of new examination: ");
        string examName = Console.ReadLine();
        AddExamination(examName);

        DeleteInactiveSponsors();
    }
}