using Microsoft.Data.Sqlite;
using WebApplication1.Database;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebApplication1.Repository
{
    public class BookCategoryRepo :IBookCategoryRepo
    {
        private readonly string _connectionString;

        public BookCategoryRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<BookCategories> GetAll()
        {
            var books = new List<BookCategories>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT CategoryId, CategoryName FROM BookCategories";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new BookCategories
                        {
                            CategoryId = reader.GetInt32(0),
                            CategoryName = reader.GetString(1),

                        });
                    }
                }
            }
            return books;
        }
        public BookCategories GetById(int CategoryId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT CategoryId, CategoryName FROM BookCategories WHERE CategoryId = @CategoryId";
                command.Parameters.AddWithValue("@CategoryId", CategoryId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new BookCategories
                        {
                            CategoryId = reader.GetInt32(0),
                            CategoryName = reader.GetString(1)
                           
                        };
                    }
                }
            }
            return null;
        }

        public void Add(BookCategories bookCategories)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO BookCategories (CategoryName) VALUES (@CatogeryName)";
                command.Parameters.AddWithValue("@CatogeryName", bookCategories.CategoryName);
               
                command.ExecuteNonQuery();
            }
        }

        public void Update(BookCategories bookCategories)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE BookCategories SET CategoryName = @CategoryName  WHERE CategoryId = @CategoryId";
                command.Parameters.AddWithValue("@CategoryId", bookCategories.CategoryId);
                command.Parameters.AddWithValue("@CategoryName", bookCategories.CategoryName);
                
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int CategoryId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM BookCategories WHERE CategoryId = @CategoryId";
                command.Parameters.AddWithValue("@CategoryId", CategoryId);
                command.ExecuteNonQuery();
            }
        }
    }
}

   
