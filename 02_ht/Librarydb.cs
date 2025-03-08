using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ht
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    public class Librarydb
    {
        private SqlConnection connection;

        public Librarydb()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Librarydb"].ConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open(); 
            Console.WriteLine("Connected to database");
        }

        public void AddBook(string title)
        {
            string query = "insert into Books (Title) values (@Title)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@Title", System.Data.SqlDbType.NVarChar).Value = title;
            command.ExecuteNonQuery();  
        }
        public int GetRegisteredUsersCount()
        {
            string query = "select count(*) from Visitors";
            SqlCommand command = new SqlCommand(query, connection);
            int userCount = (int)command.ExecuteScalar();
            return userCount;
        }

        public void GetDebtors()
        {
            string query = "select Name from Visitors where IsDebtor = 1";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Debtors:");
            while (reader.Read())
            {
                Console.WriteLine(reader["Name"]);
            }
            reader.Close(); 
        }
        public void GetAuthorsByBook(string bookTitle)
        {
            string query = @"
            select a.Name 
            from Authors a
            join BookAuthors ba on a.Id = ba.AuthorId
            join Books b on b.Id = ba.BookId
            where b.Title = @BookTitle";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@BookTitle", System.Data.SqlDbType.NVarChar).Value = bookTitle;
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine($"Authors of '{bookTitle}':");
            while (reader.Read())
            {
                Console.WriteLine(reader["Name"]);
            }
            reader.Close();  
        }

        public void GetAvailableBooks()
        {
            string query = @"
            select b.Title 
            from Books b
            left join BorrowedBooks bb on b.Id = bb.BookId
            where bb.BookId is null";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Available Books:");
            while (reader.Read())
            {
                Console.WriteLine(reader["Title"]);
            }
            reader.Close();  
        }
        public void GetBooksByUser(int userId)
        {
            string query = @"
            select b.Title
            from BorrowedBooks bb
            join Books b on bb.BookId = b.Id
            where bb.VisitorId = @VisitorId and bb.ReturnDate is null";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@VisitorId", System.Data.SqlDbType.Int).Value = userId;
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine($"Books borrowed by user {userId}:");
            while (reader.Read())
            {
                Console.WriteLine(reader["Title"]);
            }
            reader.Close();  
        }

        public void ClearAllDebts()
        {
            string query = "update Visitors set IsDebtor = 0 where IsDebtor = 1";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();  
        }

        public void UpdateBookTitle(int bookId, string newTitle)
        {
            string query = "update Books set Title = @NewTitle where Id = @BookId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@NewTitle", System.Data.SqlDbType.NVarChar).Value = newTitle;
            command.Parameters.Add("@BookId", System.Data.SqlDbType.Int).Value = bookId;
            command.ExecuteNonQuery(); 
        }

        public void UpdateUserDebtorStatus(int userId, bool isDebtor)
        {
            string query = "update Visitors set IsDebtor = @IsDebtor where Id = @UserId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@IsDebtor", System.Data.SqlDbType.Bit).Value = isDebtor;
            command.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = userId;
            command.ExecuteNonQuery(); 
        }

        public void CloseConnection()
        {
            connection.Close();  
            Console.WriteLine("Connection closed");
        }
    }


}
