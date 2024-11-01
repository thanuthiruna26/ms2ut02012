using Microsoft.Data.Sqlite;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using WebApplication1.Database;

namespace WebApplication1.Repository
{
    public class LendingRepo : ILendingRepo
    {
        private readonly string _connectionString;

        public LendingRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Lending> GetAll()
        {
            var lending = new List<Lending>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT LendingId,LendingDate,DueDate,ReturnDate FROM Members";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lending.Add(new Lending
                        {
                            LendingId = reader.GetInt32(0),
                            MemberId = reader.GetInt32(0),
                            BookId = reader.GetInt32(0),
                            LendingDate = reader.GetDateTime(0),
                            DueDate = reader.GetDateTime(0),
                            ReturnDate = reader.GetDateTime(0)

                        });
                    }
                }
            }
            return lending;
        }
        public Lending GetById(int LendingId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT LendingId, Name FROM Lending WHERE LendingId = @LendingId";
                command.Parameters.AddWithValue("@LendingId", LendingId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Lending
                        {
                            LendingId = reader.GetInt32(0),
                            MemberId = reader.GetInt32(0),
                            BookId = reader.GetInt32(0),
                            LendingDate = reader.GetDateTime(0),
                            DueDate = reader.GetDateTime(0),
                            ReturnDate = reader.GetDateTime(0)


                        };
                    }
                }
                return null;
            }
        }

            public void Add(Lending lending)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO Members (LendingDate,DueDate,ReturnDate) VALUES (@LendingDate,@DueDate,@ReturnDate)";
                    command.Parameters.AddWithValue("@LendingDate", lending.LendingDate);
                    command.Parameters.AddWithValue("@DueDate", lending.DueDate);
                    command.Parameters.AddWithValue("@ReturnDate", lending.ReturnDate);
                    


                    command.ExecuteNonQuery();
                }
            }


            public void Update(Lending lending)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "UPDATE Lending SET LendingDate = @LendingDate, DueDate = @DueDate,Email = @Email,ReturnDate = @ReturnDate  WHERE LendingId = @LendingId";
                    command.Parameters.AddWithValue("@LendingId", lending.LendingId);
                    command.Parameters.AddWithValue("@LendingDate", lending.LendingDate);
                    command.Parameters.AddWithValue("@DueDate", lending.DueDate);
                    command.Parameters.AddWithValue("@ReturnDate", lending.ReturnDate);
                    


                    command.ExecuteNonQuery();
                }
            }

            public void Delete(int LendingId)
            {
                using (var connection = new SqliteConnection(_connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM Lending WHERE LendingId = @LendingId";
                    command.Parameters.AddWithValue("@LendingId", LendingId);
                    command.ExecuteNonQuery();
                }
            }
        }
    } 

    

