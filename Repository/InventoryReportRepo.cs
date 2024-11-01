using Microsoft.Data.Sqlite;
using WebApplication1.Database;

namespace WebApplication1.Repository
{
    public class InventoryReportRepo:IInventoryReportRepo
    {
        private readonly string _connectionString;

        public InventoryReportRepo(string connectionString)
        { 
            _connectionString = connectionString;
        }

        public IEnumerable<InventoryReport> GetAll()
        {
            var inventoryReport = new List<InventoryReport>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT BookId,Title,TotalCopies,AvailableCopies FROM InventoryReport";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        inventoryReport.Add(new InventoryReport
                        {
                            BookId = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            TotalCopies = reader.GetInt32(2),
                            AvailableCopies = reader.GetInt32(3)
                        });
                    }
                }
            }
            return inventoryReport;
        }
        public InventoryReport GetById(int BookId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT BookId,Title,TotalCopies,AvailableCopies FROM InventoryReport WHERE BookId = @BookId";
                command.Parameters.AddWithValue("@BookId", BookId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new InventoryReport
                        {

                            BookId = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            TotalCopies = reader.GetInt32(2),
                            AvailableCopies = reader.GetInt32(3),

                        };
                    }
                }
            }
            return null;
        }

        public void Add(InventoryReport inventoryReport)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO InventoryReport (Title,TotalCopies,AvailableCopies) VALUES (@Title,@TotalCopies,@AvailableCopies)";
                command.Parameters.AddWithValue("@Title", inventoryReport.Title);
                command.Parameters.AddWithValue("@TotalCopies", inventoryReport.TotalCopies);
                command.Parameters.AddWithValue("@AvailableCopies", inventoryReport.AvailableCopies);

                command.ExecuteNonQuery();
            }
        }


        public void Update(InventoryReport inventoryReport)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE InventoryReport SET Title = @Title, TotalCopies = @TotalCopies,AvailableCopies = @AvailableCopies  WHERE BookId = @BookId";
                command.Parameters.AddWithValue("@Title", inventoryReport.Title);
                command.Parameters.AddWithValue("@TotalCopies", inventoryReport.TotalCopies);
                command.Parameters.AddWithValue("@AvailableCopies", inventoryReport.AvailableCopies);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int BookId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM InventoryReport WHERE BookId = @BookId";
                command.Parameters.AddWithValue("@BookId", BookId);
                command.ExecuteNonQuery();
            }
        }
    }
}
