using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic;
using WebApplication1.Database;

namespace WebApplication1.Repository
{
    public class BorrowingReportRepo : IBorrowingReportRepo
    {
        private readonly string _connectionString;
        public BorrowingReportRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<BorrowingReport> GetAll()
        {
            var borrowing = new List<BorrowingReport>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT LendingId , MemberName,BookTitle,LendingDate,DueDate,ReturnDate ";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                            borrowing.Add(new BorrowingReport
                            {
                                LendingId = reader.GetInt32(0),
                                MemberName = reader.GetString(1),
                                BookTitle = reader.GetString(2),
                                LendingDate = reader.GetDateTime(3),
                                DueDate = reader.GetDateTime(4),
                                ReturnDate = reader.GetDateTime(5),
                            });
                        
                    }
                }

            }
            return borrowing;
        }

        public BorrowingReport GetById(int LendingId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT LendingId, MemberName,BookTitle , LendingDate , DueDate ,ReturnDate FROM BorrowingReport WHERE LendingId = @LendingId";
                command.Parameters.AddWithValue("@LendingId", LendingId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new BorrowingReport
                        {
                            LendingId = reader.GetInt32(0),
                            MemberName = reader.GetString(1),
                            BookTitle = reader.GetString(2),
                            LendingDate = reader.GetDateTime(3),
                            DueDate = reader.GetDateTime(4),
                            ReturnDate = reader.GetDateTime(5)


                        };
                    }
                }
                return null;
            }
        }

        public void Add(BorrowingReport borrowing)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO BorrowingReport (LendingId, MemberName,BookTitle , LendingDate , DueDate ,ReturnDate) VALUES (@LendingId, @MemberName, @BookTitle , @LendingDate , @DueDate ,ReturnDate)";
                command.Parameters.AddWithValue("@LendingDate", borrowing.MemberName);
                command.Parameters.AddWithValue("@LendingDate", borrowing.BookTitle);
                command.Parameters.AddWithValue("@LendingDate", borrowing.LendingDate);
                command.Parameters.AddWithValue("@DueDate", borrowing.DueDate);
                command.Parameters.AddWithValue("@ReturnDate", borrowing.ReturnDate);



                command.ExecuteNonQuery();
            }
        }


        public void Update(BorrowingReport borrowing)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Lending SET LendingDate = @LendingDate, DueDate = @DueDate,Email = @Email,ReturnDate = @ReturnDate  WHERE LendingId = @LendingId";
                command.Parameters.AddWithValue("@LendingId", borrowing.LendingId);
                command.Parameters.AddWithValue("@LendingDate", borrowing.LendingDate);
                command.Parameters.AddWithValue("@DueDate", borrowing.DueDate);
                command.Parameters.AddWithValue("@ReturnDate", borrowing.ReturnDate);



                command.ExecuteNonQuery();
            }
        }

        public void Delete(int LendingId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM BorrowingReport WHERE LendingId = @LendingId";
                command.Parameters.AddWithValue("@LendingId", LendingId);
                command.ExecuteNonQuery();
            }
        }

    }
}
