using Microsoft.Data.Sqlite;
using System.Data;
using System.Net;
using WebApplication1.Database;

namespace WebApplication1.Repository
{
    public class BooksRepo:IBooksRepo
    {
        private readonly string _connectionString;

        public BooksRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Books> GetAll()
        {   
            var books = new List<Books>();
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT BookId, Title ,Author , Genre , PublicationDate , TotalCopies , AvailableCopies From Books";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Books
                        {
                            BookId = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Author = reader.GetString(2),
                            Genre = reader.GetString(3),
                            PublicationDate = reader.GetDateTime(4),
                            TotalCopies = reader.GetInt32(5),
                            AvailableCopies = reader.GetInt32(6)

                        });
                    }
                }
            }
            return books;
        }

        public Books GetById(int BookId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT BookId, Title ,Author , Genre , PublicationDate , TotalCopies , AvailableCopies From Books WHERE BookId = @BookId";
                command.Parameters.AddWithValue("@BookId", BookId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Books
                        {
                            BookId = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Author = reader.GetString(2),
                            Genre = reader.GetString(3),
                            PublicationDate = reader.GetDateTime(4),
                            TotalCopies = reader.GetInt32(5),
                            AvailableCopies = reader.GetInt32(6)

                        };
                    }
                }
            }
            return null;
        }

        public void Add(Books books)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Books (Title ,Author , Genre , PublicationDate , TotalCopies , AvailableCopies) VALUES (@Title ,@Author , @Genre , @PublicationDate , @TotalCopies , @AvailableCopies)";
                command.Parameters.AddWithValue("@Title", books.Title);
                command.Parameters.AddWithValue("@Author", books.Author);
                command.Parameters.AddWithValue("@Genre", books.Genre);
                command.Parameters.AddWithValue("@PublicationDate", books.PublicationDate);
                command.Parameters.AddWithValue("@TotalCopies", books.TotalCopies);
                command.Parameters.AddWithValue("@AvailableCopies", books.AvailableCopies);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Books books)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Books SET Title = @Title , Author = @Author , Genre=@Genre , PublicationDate = @PublicationDate , TotalCopies = @TotalCopies , AvailableCopies = @AvailableCopies WHERE BookId = @BookId";
                command.Parameters.AddWithValue("@CategoryId", books.BookId);
                command.Parameters.AddWithValue("@Title", books.Title);
                command.Parameters.AddWithValue("@Author", books.Author);
                command.Parameters.AddWithValue("@Genre", books.Genre);
                command.Parameters.AddWithValue("@PublicationDate", books.PublicationDate);
                command.Parameters.AddWithValue("@TotalCopies", books.TotalCopies);
                command.Parameters.AddWithValue("@AvailableCopies", books.AvailableCopies);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int BookId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Books WHERE BookId = @BookId";
                command.Parameters.AddWithValue("@BookId", BookId);
                command.ExecuteNonQuery();
            }
        }
    }
}
