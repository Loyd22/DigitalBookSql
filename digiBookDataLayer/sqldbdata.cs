using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using digiBookModel;

namespace digiBookDataLayer
{
    public class sqldbdata
    {
        private readonly string connectionString  //"Data Source=YEL\\SQLEXPRESS;Initial Catalog=Digibook;Integrated Security=True;";
        = "Server=tcp:20.2.64.131,1433;Database=BookDatabase;User Id=sa;Password=Qwerty123@;MultipleActiveResultSets=True";

        SqlConnection sqlConnection;

        public sqldbdata()
        {
            sqlConnection = new SqlConnection(connectionString);
        }
        public List<bookss> GetBooks()
        {
            List<bookss> books = new List<bookss>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string selectStatement = "SELECT Title, Author, Summary FROM Books";
                SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

                sqlConnection.Open();

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new bookss
                        {
                            title = reader["Title"].ToString(),
                            author = reader["Author"].ToString(),
                            summary = reader["Summary"].ToString()
                        });
                    }
                }
            }

            return books;
        }

        public bool AddBook(bookss book)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string insertStatement = "INSERT INTO Books (Title, Author, Summary) VALUES (@Title, @Author, @Summary)";
                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

                insertCommand.Parameters.AddWithValue("@Title", book.title);
                insertCommand.Parameters.AddWithValue("@Author", book.author);
                insertCommand.Parameters.AddWithValue("@Summary", book.summary);

                sqlConnection.Open();
                int success = insertCommand.ExecuteNonQuery();
                return success > 0;
            }
        }

        public bool UpdateBook(bookss book)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string updateStatement = "UPDATE Books SET Author = @Author, Summary = @Summary WHERE Title = @Title";
                SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

                updateCommand.Parameters.AddWithValue("@Title", book.title);
                updateCommand.Parameters.AddWithValue("@Author", book.author);
                updateCommand.Parameters.AddWithValue("@Summary", book.summary);

                sqlConnection.Open();
                int success = updateCommand.ExecuteNonQuery();
                return success > 0;
            }
        }
    }
}